using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Matters;

namespace AdvoSecure.Domain.Entities.Billings
{
    public class Invoice : BaseGuidEntity
    {
        public DateTime Date { get; set; }

        public DateTime Due { get; set; }

        public decimal Subtotal { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal Total { get; set; }

        public string ExternalInvoiceId { get; set; }

        public string BillTo_NameLine1 { get; set; }

        public string BillTo_NameLine2 { get; set; }

        public string BillTo_AddressLine1 { get; set; }

        public string BillTo_AddressLine2 { get; set; }

        public string BillTo_City { get; set; }

        public string BillTo_State { get; set; }

        public string BillTo_Zip { get; set; }

        public int BillToId { get; set; }

        public Contact BillTo { get; set; }

        public int? BillingGroupId { get; set; }

        public BillingGroup BillingGroup { get; set; }

        public Guid? MatterId { get; set; }

        public Matter Matter { get; set; }

        public IList<InvoiceExpense> InvoiceExpenses { get; set; } = new List<InvoiceExpense>();

        public IList<InvoiceFee> InvoiceFees { get; set; } = new List<InvoiceFee>();

        public IList<InvoiceTime> InvoiceTimes { get; set; } = new List<InvoiceTime>();
    }
}
