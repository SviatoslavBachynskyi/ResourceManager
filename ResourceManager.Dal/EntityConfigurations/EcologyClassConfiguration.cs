using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManager.Core.Models;

namespace ResourceManager.Dal.EntityConfigurations
{
    internal class EcologyClassConfiguration : IEntityTypeConfiguration<EcologyClass>
    {
        public void Configure(EntityTypeBuilder<EcologyClass> builder)
        {
            builder.HasIndex(e => e.CodeName)
                .IsUnique();

            builder.Property(e => e.CodeName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
