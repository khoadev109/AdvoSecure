using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Matters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvoSecure.Infrastructure.Persistance.Application.Configurations
{
    public class MatterContactConfiguration : IEntityTypeConfiguration<MatterContact>
    {
        public void Configure(EntityTypeBuilder<MatterContact> builder)
        {
            builder.HasKey(mc => new { mc.ContactId, mc.MatterId });

            builder.HasOne<Contact>(mc => mc.Contact)
                    .WithMany(c => c.MatterContacts)
                    .HasForeignKey(mc => mc.ContactId);


            builder.HasOne<Matter>(mc => mc.Matter)
                    .WithMany(m => m.MatterContacts)
                    .HasForeignKey(mc => mc.MatterId);
        }
    }
}
