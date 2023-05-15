using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Contacts;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvoSecure.Domain.Entities.Opportunities
{

    [Table("Opportunity")]
    public class Opportunity : BaseLongEntity
    {
        public decimal? Probability { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? Closed { get; set; }

        public int? StageId { get; set; }

        public OpportunityStage? Stage { get; set; }

        public long? LeadId { get; set; }

        public Leads.Lead? Lead { get; set; }

        public Guid? MatterId { get; set; }

        public Matters.Matter Matter { get; set; }

        public int? AccountId { get; set; }

        public Contact Account { get; set; }

        public IList<OpportunityContact> OpportunityContacts { get; set; } = new List<OpportunityContact>();

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DeletedDateTime { get; set; }
    }
}
