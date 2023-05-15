using AdvoSecure.Domain.Entities.Billings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvoSecure.Infrastructure.Persistance.Application.Configurations
{
    public class InvoiceExpenseConfiguration : IEntityTypeConfiguration<InvoiceExpense>
    {
        public void Configure(EntityTypeBuilder<InvoiceExpense> builder)
        {
            builder.HasKey(ie => new { ie.InvoiceId, ie.ExpenseId });

            builder.HasOne<Invoice>(ie => ie.Invoice)
                    .WithMany(i => i.InvoiceExpenses)
                    .HasForeignKey(ie => ie.InvoiceId);


            builder.HasOne<Expense>(ie => ie.Expense)
                    .WithMany(e => e.InvoiceExpenses)
                    .HasForeignKey(ie => ie.ExpenseId);
        }
    }
}
