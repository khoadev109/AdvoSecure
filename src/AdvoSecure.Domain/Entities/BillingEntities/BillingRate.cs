using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.ContactEntities;

namespace AdvoSecure.Domain.Entities.BillingEntities
{
    public class BillingRate : CompanyLegalStatus
    {
        public string Title { get; set; }

        public decimal PricePerUnit { get; set; }

        //public ICollection<Contact> Contacts { get; set; }
    }
}
