using AdvoSecure.Domain.Entities.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvoSecure.Infrastructure.Persistance.Application.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasMany(c => c.AccountOpportunities)
                    .WithOne(o => o.Account)
                    .HasForeignKey(o => o.AccountId);
        }
    }
}
