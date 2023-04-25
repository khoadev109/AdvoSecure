using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Contacts;

namespace AdvoSecure.Domain.Entities.Matters
{
    public class MatterType : BaseEntity
    {
        public string Title { get; set; }

        public IList<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
