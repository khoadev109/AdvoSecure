using AdvoSecure.Domain.Entities.Billings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvoSecure.Infrastructure.Persistance.Application.Configurations
{
    public class InvoiceFeeConfiguration : IEntityTypeConfiguration<InvoiceFee>
    {
        public void Configure(EntityTypeBuilder<InvoiceFee> builder)
        {
            builder.HasKey(ifee => new { ifee.InvoiceId, ifee.FeeId });

            builder.HasOne<Invoice>(ifee => ifee.Invoice)
                    .WithMany(i => i.InvoiceFees)
                    .HasForeignKey(ifee => ifee.InvoiceId);


            builder.HasOne<Fee>(ifee => ifee.Fee)
                    .WithMany(f => f.InvoiceFees)
                    .HasForeignKey(ifee => ifee.FeeId);
        }
    }
}
