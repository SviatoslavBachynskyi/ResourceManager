using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManager.Core.Models;

namespace ResourceManager.Dal.EntityConfigurations
{
    internal class InventoryGivingConfiguration : IEntityTypeConfiguration<InventoryGiving>
    {
        public void Configure(EntityTypeBuilder<InventoryGiving> builder)
        {
            builder.HasIndex(e => e.RequestDate)
                .HasName("InventoryGivingsByRequestDate_IX");

            builder.Property(e => e.RequestDate).HasColumnType("datetime");

            builder.Property(e => e.Description).HasMaxLength(1000);

            builder.Property(e => e.TakenById)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(e => e.ApprovedById)
                .HasMaxLength(450);

            builder.HasOne(d => d.ApprovedBy)
                .WithMany()
                .HasForeignKey(d => d.ApprovedById)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("InventoryGivings_ApprovedBy_FK");

            builder.HasOne(d => d.InventoryGivingStatus)
                .WithMany()
                .HasForeignKey(d => d.InventoryGivingStatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("InventoryGivings_InventoryGivingStatuses_FK ");

            builder.HasOne(d => d.Inventory)
                .WithMany()
                .HasForeignKey(d => d.InventoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("InventoryGivings_Inventory_FK");

            builder.HasOne(d => d.TakenBy)
                .WithMany()
                .HasForeignKey(d => d.TakenById)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("InventoryGivings_ToWhom_FK");
        }
    }
}
