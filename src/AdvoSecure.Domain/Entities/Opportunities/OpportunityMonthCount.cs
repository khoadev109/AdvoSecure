using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Opportunities
{
    public class OpportunityMonthCount : BaseEntity
    {
        public DateTime? Month { get; set; }

        public int? Count { get; set; }
    }
}
