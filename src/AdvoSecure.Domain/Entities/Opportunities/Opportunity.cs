using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Opportunities
{
    public class Opportunity : BaseLongEntity
    {
        public decimal? Probability { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? Closed { get; set; }

        public Contacts.Contact Account { get; set; }

        public List<Contacts.Contact> Contacts { get; set; }

        public int? StageId { get; set; }

        public OpportunityStage Stage { get; set; }

        public long? LeadId { get; set; }

        public Leads.Lead Lead { get; set; }

        public Guid? MatterId { get; set; }

        public Matters.Matter Matter { get; set; }
    }
}
