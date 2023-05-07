using AdvoSecure.Domain.Entities.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvoSecure.Infrastructure.Persistance.Application.Configurations
{
    internal class TaskConfiguration : IEntityTypeConfiguration<InnerTask>
    {
        public void Configure(EntityTypeBuilder<InnerTask> builder)
        {
            builder.HasMany(t => t.Notes)
                   .WithMany(n => n.Tasks);

            builder.HasMany(t => t.Tags)
                   .WithMany(t => t.Tasks);

            builder.HasMany(t => t.Times)
                   .WithMany(t => t.Tasks);
        }
    }
}
