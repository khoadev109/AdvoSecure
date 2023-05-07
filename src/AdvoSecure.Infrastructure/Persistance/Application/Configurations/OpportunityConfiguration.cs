using AdvoSecure.Domain.Entities.Opportunities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvoSecure.Infrastructure.Persistance.Application.Configurations
{
    public class OpportunityConfiguration : IEntityTypeConfiguration<Opportunity>
    {
        public void Configure(EntityTypeBuilder<Opportunity> builder)
        {
            builder.HasMany(o => o.Contacts)
                   .WithMany(c => c.Opportunities);
        }
    }
}
