using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManager.Core.Models;

namespace ResourceManager.Dal.EntityConfigurations
{
    internal class SupplyConfiguration : IEntityTypeConfiguration<Supply>
    {
        public void Configure(EntityTypeBuilder<Supply> builder)
        {
            builder.HasIndex(e => e.WayBillNumber)
                .IsUnique();

            builder.Property(e => e.ArrivalDate).HasColumnType("date");

            builder.Property(e => e.WayBillNumber)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.AcceptedById)
                .IsRequired()
                .HasMaxLength(450);

            builder.HasOne(d => d.AcceptedBy)
                .WithMany()
                .HasForeignKey(d => d.AcceptedById)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Supplies_Workers_FK");
        }
    }
}
