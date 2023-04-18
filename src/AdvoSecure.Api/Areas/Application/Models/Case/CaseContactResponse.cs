using AdvoSecure.Api.Areas.Application.Models.Contact;

namespace AdvoSecure.Api.Areas.Application.Models.Case;

public class CaseContactResponse
{
    public Guid Id { get; set; }

    public ContactResponse Contact { get; set; }
    public bool IsClient { get; set; }
    public bool IsClientContact { get; set; }
    public bool IsAppointed { get; set; }
    public bool IsParty { get; set; }
    public bool IsJudge { get; set; }
    public bool IsWitness { get; set; }
    public bool IsAttorney { get; set; }
    public bool IsLeadAttorney { get; set; }
    public bool IsSupportStaff { get; set; }
    public bool IsThirdPartyPayor { get; set; }
}
