using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Contacts;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvoSecure.Domain.Entities.Billings
{
    [Table("BillingGroups")]
    public class BillingGroup : BaseEntity
    {
        public string Title { get; set; }

        public DateTime? LastRun { get; set; }

        public DateTime NextRun { get; set; }

        public decimal Amount { get; set; }

        public int BillToContactId { get; set; }

        public Contact BillToContact { get; set; }

        public IList<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
