using Entities;
using Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HogwartsSchoolAPI.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { });
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(opts =>
            {
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                    b =>
                    {
                        b.MigrationsAssembly("HogwartsSchoolAPI"); // We need to add this to specify that migrations will be in our main project from list of projects
                    });
            });
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "HogwartsAPI",
                        Version = "v1"
                    }
                 );

                var xmlFile = "HogwartsSchoolAPI.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

                var xmlEntitiesFile = "Entities.xml";
                var xmlEntitiesPath = Path.Combine(AppContext.BaseDirectory, xmlEntitiesFile);
                c.IncludeXmlComments(xmlEntitiesPath, includeControllerXmlComments: true);

                c.EnableAnnotations();
            });
        }
    }
}
