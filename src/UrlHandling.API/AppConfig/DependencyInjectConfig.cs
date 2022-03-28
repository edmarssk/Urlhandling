using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlHandling.Business.Interfaces.Repository;
using UrlHandling.Business.Interfaces.Services;
using UrlHandling.Business.Notifications;
using UrlHandling.Business.Services;
using UrlHandling.Data.Context;
using UrlHandling.Data.Repository;
using UrlHandling.UrlResource.Services;

namespace UrlHandling.API.AppConfig
{
    public static class DependencyInjectConfig
    {
        public static IServiceCollection ExecuteDependencyInject(this IServiceCollection services)
        {
            services.AddScoped<IUrlLinkRepository, UrlLinkRepository>();
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IUrlService, UrlService>();
            services.AddScoped<IUrlLinkService, UrlLinkService>();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<MainUrlHandlingDbContext>();

            return services;
        }
    }
}
