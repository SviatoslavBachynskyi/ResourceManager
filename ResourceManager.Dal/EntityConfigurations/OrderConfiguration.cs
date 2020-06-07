using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManager.Core.Models;

namespace ResourceManager.Dal.EntityConfigurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasIndex(e => e.OrderNum)
                .IsUnique();

            builder.Property(e => e.OrderNum)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.CompleteDate).HasColumnType("datetime");

            builder.Property(e => e.OrderDate).HasColumnType("datetime");

            builder.Property(e => e.OrderPrice).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.ShipmentPrice).HasColumnType("numeric(18, 2)");

            builder.Property(e => e.TotalPrice).HasColumnType("numeric(18, 2)");

            builder.HasOne(d => d.OrderStatus)
                .WithMany()
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Orders_OrderStatuses_FK");

            builder.HasOne(d => d.OrderedBy)
                .WithMany()
                .HasForeignKey(d => d.OrderedById)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Workers_OrderedBy_FK");

            builder.HasOne(d => d.ApprovedBy)
                .WithMany()
                .HasForeignKey(d => d.ApprovedById)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Workers_ApprovedBy_FK");

            builder.HasOne(d => d.Supplier)
                .WithMany()
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Orders_Suppliers_FK");

            builder.HasOne(d => d.Supply)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.SupplyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Orders_Supplies_FK");
        }
    }
}
