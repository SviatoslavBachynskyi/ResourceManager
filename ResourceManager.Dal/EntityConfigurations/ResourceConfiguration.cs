using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManager.Core.Models;

namespace ResourceManager.Dal.EntityConfigurations
{
    internal class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasIndex(e => e.Name)
                .IsUnique();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.ShelfLife).HasColumnType("datetime");

            builder.HasOne(d => d.EcologyClass)
                .WithMany()
                .HasForeignKey(d => d.EcologyClassId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Resources_EcologyClasses_FK");

            builder.HasOne(d => d.MeasuringUnit)
                .WithMany()
                .HasForeignKey(d => d.MeasuringUnitId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Resources_MeasuringUnits_FK");

            builder.HasOne(d => d.ResourceSubCategory)
                .WithMany()
                .HasForeignKey(d => d.ResourceSubCategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Resource_ResourceSubCategories_FK");

            builder.HasOne(d => d.SafetyClass)
                .WithMany()
                .HasForeignKey(d => d.SafetyClassId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Resources_SafetyClasses_FK");
        }
    }
}
