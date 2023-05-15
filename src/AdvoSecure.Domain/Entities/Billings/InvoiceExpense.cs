using System.ComponentModel.DataAnnotations;

namespace AdvoSecure.Domain.Entities.Billings
{
    public class InvoiceExpense
    {
        [Key]
        public Guid Id { get; set; }

        public Guid InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public Guid ExpenseId { get; set; }

        public Expense Expense { get; set; }

        public string Details { get; set; }
    }
}
