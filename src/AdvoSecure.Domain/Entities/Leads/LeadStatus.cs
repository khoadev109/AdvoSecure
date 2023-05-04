using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Leads
{
    public class LeadStatus : BaseEntity
    {
        public string Title { get; set; }

        public IList<Lead> Leads { get; set; } = new List<Lead>();
    }
}
