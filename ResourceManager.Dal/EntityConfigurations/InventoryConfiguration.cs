using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManager.Core.Models;

namespace ResourceManager.Dal.EntityConfigurations
{
    internal class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasIndex(e => e.InventoryNum)
                .IsUnique();

            builder.HasIndex(e => e.WareHouseId)
                .HasName("InventoryInWarehouse_IX");

            builder.HasIndex(e => e.ResourceId)
                .HasName("InventoryForResource_IX");

            builder.Property(e => e.InventoryNum)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.HasOne(d => d.OrderItem)
                .WithMany()
                .HasForeignKey(d => d.OrderItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Inventory_OrderItems_FK");

            builder.HasOne(d => d.Resource)
                .WithMany()
                .HasForeignKey(d => d.ResourceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Inventory_Resources_FK");

            builder.HasOne(d => d.WareHouse)
                .WithMany()
                .HasForeignKey(d => d.WareHouseId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Inventory_Warehouses_FK");
        }
    }
}
