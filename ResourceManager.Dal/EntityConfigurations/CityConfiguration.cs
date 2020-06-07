using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManager.Core.Models;

namespace ResourceManager.Dal.EntityConfigurations
{
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasIndex(e => new { e.Name, e.DistrictId })
                .HasName("CitiesInDistrict_UC")
                .IsUnique();

            builder.HasIndex(e => e.DistrictId)
                .HasName("CitiesInDistrict_IX");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.District)
                .WithMany(p => p.Cities)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Cities_Districts_FK");
        }
    }
}
