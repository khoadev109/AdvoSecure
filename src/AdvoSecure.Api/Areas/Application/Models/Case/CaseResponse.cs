namespace AdvoSecure.Api.Areas.Application.Models.Case;

public class CaseResponse
{
    public Guid? Id { get; set; }
    public bool Active { get; set; }
    public string CaseNumber { get; set; } = null!;
    public string? CaseReferenceNumber { get; set; }
    public string Title { get; set; } = null!;
    public string? Synopsis { get; set; }
    public CaseTypeResponse? CaseType { get; set; }
    public CaseResponse? Parent { get; set; }
    public CaseAreaResponse? CaseArea { get; set; }
    public string? BillToContactDisplayName { get; set; }
    public decimal? MinimumCharge { get; set; }
    public decimal? EstimatedCharge { get; set; }
    public decimal? MaximumCharge { get; set; }
    public bool OverrideCaseRateWithEmployeeRate { get; set; }
    public string? AttorneyForPartyTitle { get; set; }
    public List<CaseContactResponse> CaseContacts { get; set; }
}
