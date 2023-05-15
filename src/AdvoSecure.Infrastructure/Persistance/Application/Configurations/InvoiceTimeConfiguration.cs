using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Timing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvoSecure.Infrastructure.Persistance.Application.Configurations
{
    public class InvoiceTimeConfiguration : IEntityTypeConfiguration<InvoiceTime>
    {
        public void Configure(EntityTypeBuilder<InvoiceTime> builder)
        {
            builder.HasKey(it => new { it.InvoiceId, it.TimeId });

            builder.HasOne<Invoice>(it => it.Invoice)
                    .WithMany(i => i.InvoiceTimes)
                    .HasForeignKey(it => it.InvoiceId);


            builder.HasOne<Time>(it => it.Time)
                    .WithMany(t => t.InvoiceTimes)
                    .HasForeignKey(it => it.TimeId);
        }
    }
}
