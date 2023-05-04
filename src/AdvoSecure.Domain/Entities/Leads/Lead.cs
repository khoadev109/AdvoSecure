using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Leads
{
    public class Lead : BaseLongEntity
    {
        public DateTime? Closed { get; set; }

        public string Details { get; set; }

        public int? StatusId { get; set; }

        public LeadStatus Status { get; set; }

        public int? ContactId { get; set; }

        public Contacts.Contact Contact { get; set; }

        public int? SourceId { get; set; }

        public LeadSource Source { get; set; }

        public int? FeeId { get; set; }

        public LeadFee Fee { get; set; }
    }
}
