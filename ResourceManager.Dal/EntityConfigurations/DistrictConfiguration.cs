﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManager.Core.Models;

namespace ResourceManager.Dal.EntityConfigurations
{
    internal class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasIndex(e => new { e.Name, e.CountryId })
                .HasName("DistrictInCountry_UC")
                .IsUnique();

            builder.HasIndex(e => e.CountryId)
                .HasName("DistrictsInCountry_IX");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.Country)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Districts_Countries_FK");
        }
    }
}
