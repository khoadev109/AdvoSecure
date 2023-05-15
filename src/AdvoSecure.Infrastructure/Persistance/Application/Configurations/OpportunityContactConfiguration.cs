using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Opportunities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvoSecure.Infrastructure.Persistance.Application.Configurations
{
    public class OpportunityContactConfiguration : IEntityTypeConfiguration<OpportunityContact>
    {
        public void Configure(EntityTypeBuilder<OpportunityContact> builder)
        {
            builder.HasKey(oc => new { oc.OpportunityId, oc.ContactId });

            builder.HasOne<Opportunity>(oc => oc.Opportunity)
                    .WithMany(o => o.OpportunityContacts)
                    .HasForeignKey(oc => oc.OpportunityId);


            builder.HasOne<Contact>(oc => oc.Contact)
                    .WithMany(c => c.OpportunityContacts)
                    .HasForeignKey(oc => oc.ContactId);
        }
    }
}
