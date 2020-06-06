using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResourceManager.Bll.Services;
using ResourceManager.Core.Services;

namespace ResourceManager.Injection
{
    internal static class BllInjection
    {
        internal static IServiceCollection AddBll(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices(configuration);

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<IResourceCategoryService, ResourceCategoryService>();
            services.AddScoped<IResourceSubCategoryService, ResourceSubCategoryService>();
            services.AddScoped<IMeasuringUnitService, MeasuringUnitService>();
            services.AddScoped<IEcologyClassService, EcologyClassService>();
            services.AddScoped<ISafetyClassService, SafetyClassService>();

            return services;
        }
    }
}
