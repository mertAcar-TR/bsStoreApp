using Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using Services.Contracts;
using System.Net;

namespace WebApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app,ILoggerService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;//hangi hata olursa olsun 500 hata kodlu kabul ettik.
                    context.Response.ContentType="application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();//hata varsa aldık

                    if (contextFeature is not null)
                    {
                        logger.LogError($"Something went wrong : {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatutCode= context.Response.StatusCode,
                            Message ="Internal Server Error"
                        }.ToString());
                    }
                });
            });
        }
    }
}
