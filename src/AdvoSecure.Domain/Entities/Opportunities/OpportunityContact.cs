using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Opportunities
{
    public class OpportunityContact : BaseLongEntity
    {
        public long OpportunityId { get; set; }

        public Opportunity Opportunity { get; set; }

        public int ContactId { get; set; }

        public Contacts.Contact Contact { get; set; }
    }
}
