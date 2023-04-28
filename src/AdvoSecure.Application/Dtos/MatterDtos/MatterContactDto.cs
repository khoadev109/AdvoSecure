namespace AdvoSecure.Application.Dtos.MatterDtos
{
    public class MatterContactDto
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

        public string MatterId { get; set; }

        public int ContactId { get; set; }
    }
}
