﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EfCore;

namespace WebApi.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            //configurationBuilder
            var configuration = new ConfigurationBuilder().
            SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            //DbContextOptionsBuilder
            var builder = new DbContextOptionsBuilder<RepositoryContext>().UseNpgsql(configuration.GetConnectionString("sqlConnection"),prj=>prj.MigrationsAssembly("WebApi"));

            return new RepositoryContext(builder.Options);
        }
    }
}
