using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.ContactEntities;

namespace AdvoSecure.Domain.Entities
{
    public class CompanyLegalStatus : BaseEntity
    {
        public string Title { get; set; }

        public IList<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
