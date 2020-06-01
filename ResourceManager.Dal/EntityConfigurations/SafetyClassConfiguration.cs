using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManager.Core.Models;

namespace ResourceManager.Dal.EntityConfigurations
{
    internal class SafetyClassConfiguration : IEntityTypeConfiguration<SafetyClass>
    {
        public void Configure(EntityTypeBuilder<SafetyClass> builder)
        {
            builder.Property(e => e.CodeName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
