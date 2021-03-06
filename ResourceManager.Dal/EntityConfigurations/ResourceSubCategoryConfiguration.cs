﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManager.Core.Models;

namespace ResourceManager.Dal.EntityConfigurations
{
    internal class ResourceSubCategoryConfiguration : IEntityTypeConfiguration<ResourceSubCategory>
    {
        public void Configure(EntityTypeBuilder<ResourceSubCategory> builder)
        {
            builder.HasIndex(e => new { e.Name, e.ResourceCategoryId })
                .HasName("SubCategoriesInCategory_UC")
                .IsUnique();

            builder.HasIndex(e => e.ResourceCategoryId)
                .HasName("SubCategoriesInCategory_IX");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.ResourceCategory)
                .WithMany(p => p.ResourceSubCategories)
                .HasForeignKey(d => d.ResourceCategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ResourceSubCategories_ResourceCategories_FK");
        }
    }
}
