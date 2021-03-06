﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManager.Core.Models;

namespace ResourceManager.Dal.EntityConfigurations
{
    internal class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasIndex(e => e.Name)
                .IsUnique();

            builder.Property(e => e.Name).HasMaxLength(50);
        }
    }
}
