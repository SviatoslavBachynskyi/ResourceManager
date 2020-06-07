using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManager.Core.Models;

namespace ResourceManager.Dal.EntityConfigurations
{
    internal class MeasuringUnitConfiguration : IEntityTypeConfiguration<MeasuringUnit>
    {
        public void Configure(EntityTypeBuilder<MeasuringUnit> builder)
        {
            builder.HasIndex(e => e.Name)
                .IsUnique();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
