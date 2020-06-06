using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System.Reflection;
using System.Linq;
using ResourceManager.PageServices;

namespace ResourceManager.Injection
{
    public static class WebInjection
    {
        internal static IServiceCollection AddWeb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMapper(configuration);

            services.AddPageServices(configuration);

            return services;
        }

        private static IServiceCollection AddMapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(new[] { Assembly.GetExecutingAssembly() }, ServiceLifetime.Singleton);

            return services;
        }

        private static IServiceCollection AddPageServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IResourcePageService, ResourcePageService>();

            return services;
        }
    }
}
