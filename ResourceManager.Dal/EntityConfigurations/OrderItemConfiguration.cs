using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManager.Core.Models;

namespace ResourceManager.Dal.EntityConfigurations
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(e => e.UnitPrice).HasColumnType("numeric(18, 2)");

            builder.HasOne(d => d.Order)
                .WithMany()
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("OrderItems_Orders_FK");

            builder.HasOne(d => d.Resource)
                .WithMany()
                .HasForeignKey(d => d.ResourceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("OrderItems_Resources_FK");
        }
    }
}
