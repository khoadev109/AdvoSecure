using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Contacts;

namespace AdvoSecure.Domain.Entities.Matters
{
    public class MatterContact : BaseEntity
    {
        public bool IsClient { get; set; }

        public bool IsClientContact { get; set; }

        public bool IsAppointed { get; set; }

        public bool IsParty { get; set; }

        public string PartyTitle { get; set; }

        public bool IsJudge { get; set; }

        public bool IsWitness { get; set; }

        public bool IsLeadAttorney { get; set; }

        public bool IsAttorney { get; set; }

        public bool IsSupportStaff { get; set; }
        
        public bool IsThirdPartyPayor { get; set; }


        public Guid MatterId { get; set; }

        public Matter Matter { get; set; }


        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}
