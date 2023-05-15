using AdvoSecure.Domain.Entities.Contacts;

namespace AdvoSecure.Domain.Entities.Opportunities
{
    public class OpportunityContact
    {
        public long OpportunityId { get; set; }

        public Opportunity Opportunity { get; set; }

        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}
