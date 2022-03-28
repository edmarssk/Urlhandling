using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlHandling.API.AppConfig
{
    public static class SwaggerApiConfig
    {
        public static IServiceCollection AddSwaggerAppConfig(this IServiceCollection services, IConfiguration Configuration)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Api Creation Short Url",
                    Version = "v1",
                    Description = "API with resource to create and search short URL",
                    Contact = new OpenApiContact
                    {
                        Name = "Api Creation Short Url",
                        Email = String.Empty
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License Api Creation Short Url"
                    }
                }); ;
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerAppConfig(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            return app;
        }
    }
}