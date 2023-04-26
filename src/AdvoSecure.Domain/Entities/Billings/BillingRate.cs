using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Matters;

namespace AdvoSecure.Domain.Entities.Billings
{
    public class BillingRate : BaseEntity
    {
        public string Title { get; set; }

        public decimal PricePerUnit { get; set; }

        public IList<Contact> Contacts { get; set; } = new List<Contact>();

        public IList<Matter> Matters { get; set; } = new List<Matter>();
    }
}
