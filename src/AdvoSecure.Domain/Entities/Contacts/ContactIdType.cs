using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Contacts
{
    public class ContactIdType : BaseEntity
    {
        public string Title { get; set; }

        public IList<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
