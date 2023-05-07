using AdvoSecure.Domain.Entities.Matters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvoSecure.Infrastructure.Persistance.Application.Configurations
{
    public class MatterConfiguration : IEntityTypeConfiguration<Matter>
    {
        public void Configure(EntityTypeBuilder<Matter> builder)
        {
            builder.HasMany(m => m.Notes)
                   .WithMany(n => n.Matters);

            builder.HasMany(m => m.Tasks)
                   .WithMany(t => t.Matters);
        }
    }
}
