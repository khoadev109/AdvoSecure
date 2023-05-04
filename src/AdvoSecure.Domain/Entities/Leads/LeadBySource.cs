using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Leads
{
    public class LeadBySource : BaseEntity
    {
        public int? SourceId { get; set; }

        public int? Count { get; set; }

        public string Title { get; set; }
    }
}
