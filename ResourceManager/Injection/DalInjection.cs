using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResourceManager.Core;
using ResourceManager.Core.Models;
using ResourceManager.Core.Repositories;
using ResourceManager.Dal;
using ResourceManager.Dal.Repositories;
using System;

namespace ResourceManager.Injection
{
    internal static class DalInjection
    {
        internal static IServiceCollection AddDal(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddContext(configuration);

            services.AddRepositories(configuration);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ResourceManagerContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(nameof(ResourceManager))
               ));

            services.AddDefaultIdentity<Worker>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ResourceManagerContext>()
                ;

            services.Configure<IdentityOptions>((options) => { configuration.GetSection("IdentityOptions").Bind(options); });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IEcologyClassRepository, EcologyClassRepository>();
            services.AddScoped<IInventoryGivingStatusRepository, InventoryGivingStatusRepository>();
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

            return services;
        }

        public static IServiceProvider SeedEssentialData(this IServiceProvider provider)
        {
            var context = provider.GetRequiredService<ResourceManagerContext>();
            var userManager = provider.GetRequiredService<UserManager<Worker>>();
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var configuration = provider.GetRequiredService<IConfiguration>();

            DataSeeder.SeedEssentialDataAsync(
                context,
                userManager,
                roleManager,
                configuration["AdminPassword"]).Wait();

            return provider;
        }
    }
}
