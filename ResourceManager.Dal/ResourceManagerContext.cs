using Microsoft.EntityFrameworkCore;
using ResourceManager.Core.Models;
using ResourceManager.Dal.EntityConfigurations;

namespace ResourceManager.Dal
{
    public class ResourceManagerContext : DbContext
    {
        public ResourceManagerContext()
        {

        }

        public ResourceManagerContext(DbContextOptions<ResourceManagerContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<EcologyClass> EcologyClasses { get; set; }

        public DbSet<Inventory> Inventory { get; set; }

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

            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-FNNF1M3;Initial Catalog=ResourceManager3; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new DistrictConfiguration());
            modelBuilder.ApplyConfiguration(new EcologyClassConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
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
