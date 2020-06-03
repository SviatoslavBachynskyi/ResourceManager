using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResourceManager.Core;
using ResourceManager.Core.Repositories;
using ResourceManager.Dal;
using ResourceManager.Dal.Repositories;

namespace ResourceManager.Injection
{
    internal static class DalInjection
    {
        internal static void InjectDal(this IServiceCollection services, IConfiguration configuration)
        {
            services.InjectContext(configuration);

            services.InjectRepositories(configuration);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        private static void InjectContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ResourceManagerContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
        private static void InjectRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IEcologyClassRepository, EcologyClassRepository>();
            services.AddScoped<IInventoryGivingRepository, InventoryGivingRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IMeasuringUnitRepository, MeasuringUnitRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IResourceCategoryRepository, ResourceCategoryRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IResourceSubCategoryRepository, ResourceSubCategoryRepository>();
            services.AddScoped<ISafetyClassRepository, SafetyClassRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISupplyRepository, SupplyRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IWorkerRepository, WorkerRepository>();
        }
    }
}
