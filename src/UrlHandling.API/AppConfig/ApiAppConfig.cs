using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlHandling.API.AppConfig
{
    public static class ApiAppConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(opt =>
            {
                opt.AddPolicy("Development", builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

                opt.AddPolicy("Production", builder => builder
                .AllowAnyHeader()
               .WithOrigins("http://urllink.io")
               .SetIsOriginAllowedToAllowWildcardSubdomains()
               .WithMethods("GET"));
            });

            return services;
        }

        public static IApplicationBuilder UseApiAppConfig(this IApplicationBuilder app)
        {

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHttpsRedirection();

            return app;
        }
    }
}
