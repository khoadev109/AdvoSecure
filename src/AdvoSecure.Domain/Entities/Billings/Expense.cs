using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Matters;

namespace AdvoSecure.Domain.Entities.Billings
{
    public class Expense : BaseGuidEntity
    {
        public DateTime Incurred { get; set; }

        public DateTime? Paid { get; set; }

        public string Vendor { get; set; }

        public decimal Amount { get; set; }

        public string Details { get; set; }

        public IList<InvoiceExpense> InvoiceExpenses { get; set; } = new List<InvoiceExpense>();

        public IList<Matter> Matters { get; set; } = new List<Matter>();
    }
}
