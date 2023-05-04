using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Leads
{
    public class LeadSourceType : BaseEntity
    {
        public string Title { get; set; }

        public IList<LeadSource> Sources { get; set; } = new List<LeadSource>();
    }
}
