using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Opportunities
{
    public class OpportunityStage : BaseEntity
    {
        public int? Order { get; set; }

        public string Title { get; set; }
    }
}
