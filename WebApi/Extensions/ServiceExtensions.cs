﻿using AspNetCoreRateLimit;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Presentation.ActionFilters;
using Presentation.Controllers;
using Repositories.Contracts;
using Repositories.EfCore;
using Services;
using Services.Contracts;

namespace WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,IConfiguration configuration)=> services.AddDbContext<RepositoryContext>(options => options.UseNpgsql(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureRepositoryManager(this IServiceCollection services)=>services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerService, LoggerManager>();

        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddSingleton<LogFilterAttribute>();//Logger'ı kullandığın yerde ver.
            services.AddScoped<ValidateMediaTypeAttribute>();
            
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("X-Pagination"));
            });
        }

        public static void ConfigureDataShaper(this IServiceCollection services)
        {
            services.AddScoped<IDataShaper<BookDto>, DataShaper<BookDto>>();
        }

        public static void AddCustomMediaTypes(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(config =>
            {
                var systemTextJsonOutputFormatter = config
                .OutputFormatters
                .OfType<SystemTextJsonOutputFormatter>()?.FirstOrDefault();

                if (systemTextJsonOutputFormatter != null)
                {
                    systemTextJsonOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.btkakademi.hateoas+json");

                    systemTextJsonOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.btkakademi.apiroot+json");
                }

                var xmlOutputFormatter = config
                .OutputFormatters
                .OfType<XmlDataContractSerializerOutputFormatter>()?.FirstOrDefault();

                if (xmlOutputFormatter is not null)
                {
                    xmlOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.btkakademi.hateoas+xml");

                    xmlOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.btkakademi.apiroot+xml");
                }
            });
        }

        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;//header'a versiyon bilgisini ekledik
                opt.AssumeDefaultVersionWhenUnspecified = true;//talep yoksa default versiyon bilgisi
                opt.DefaultApiVersion = new ApiVersion(1,0);//Major değişiklikler 1,küçük değişiklikler sıfır
                opt.ApiVersionReader = new HeaderApiVersionReader("api-version");//header ile versiyonlama
                opt.Conventions.Controller<BooksController>().HasApiVersion(new ApiVersion(1,0));
                opt.Conventions.Controller<BooksV2Controller>().HasDeprecatedApiVersion(new ApiVersion(2,0));
            });
        }

        public static void ConfigureResponseCaching(this IServiceCollection services) => services.AddResponseCaching();//Expiration Model

        public static void ConfigureHttpCacheHeaders(this IServiceCollection services) => services.AddHttpCacheHeaders(exprationOp =>
        {
            exprationOp.MaxAge = 90;
            exprationOp.CacheLocation = Marvin.Cache.Headers.CacheLocation.Public;
        },
            validationOpt =>
            {
                validationOpt.MustRevalidate = false;
            }
            //Cache için Varnish,Apache Traffic Server,Squid,CDN kütüphaneleri kullanabilirsin..Net validation cache'de bozuk çalışıyor.
            );//Validation  Model

        public static void ConfigureRateLimitingOptions(this IServiceCollection services)
        {
            var rateLimitRules = new List<RateLimitRule>()
            {
                new RateLimitRule
                {
                    Endpoint="*",//hepsi
                    Limit=3,//dakikada max 3 istek
                    Period="1m"
                }
            };
            services.Configure<IpRateLimitOptions>(opt => { opt.GeneralRules = rateLimitRules; });
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy,AsyncKeyLockProcessingStrategy>();
        }
        
    }
}
