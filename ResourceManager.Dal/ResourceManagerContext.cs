using Microsoft.EntityFrameworkCore;
using ResourceManager.Core.Models;
using ResourceManager.Dal.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ResourceManager.Dal
{
    public class ResourceManagerContext : IdentityDbContext<Worker>
    {
        public ResourceManagerContext(DbContextOptions<ResourceManagerContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<EcologyClass> EcologyClasses { get; set; }

        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<InventoryGivingStatus> InventoryGivingStatuses { get; set; }

        public DbSet<InventoryGiving> InventoryGivings { get; set; }

        public DbSet<MeasuringUnit> MeasuringUnits { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<ResourceCategory> ResourceCategories { get; set; }

        public DbSet<ResourceSubCategory> ResourceSubCategories { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<SafetyClass> SafetyClasses { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Supply> Supplies { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new DistrictConfiguration());
            modelBuilder.ApplyConfiguration(new EcologyClassConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryGivingStatusConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryGivingConfiguration());
            modelBuilder.ApplyConfiguration(new MeasuringUnitConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceSubCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceConfiguration());
            modelBuilder.ApplyConfiguration(new SafetyClassConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new SupplyConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
        }
    }
}
