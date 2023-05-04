using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Leads
{
    public class LeadFee : BaseEntity
    {
        public bool? IsEligible { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? Paid { get; set; }

        public string AdditionalData { get; set; }

        public int? ToId { get; set; }

        public Contacts.Contact To { get; set; }

        public IList<Lead> Leads { get; set; } = new List<Lead>();
    }
}
