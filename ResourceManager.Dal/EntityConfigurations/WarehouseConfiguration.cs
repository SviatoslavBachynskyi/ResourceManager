using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManager.Core.Models;

namespace ResourceManager.Dal.EntityConfigurations
{
    internal class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasIndex(e => new { e.WarehouseNumber, e.CityId })
                .HasName("CityNumber_UC")
                .IsUnique();

            builder.Property(e => e.Address).HasMaxLength(200);

            builder.Property(e => e.Volume).HasColumnType("numeric(18, 3)");

            builder.HasOne(d => d.City)
                .WithMany()
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Warehouses_Cites_FK");
        }
    }
}
