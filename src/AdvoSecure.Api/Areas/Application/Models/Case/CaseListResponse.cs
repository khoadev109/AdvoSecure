namespace AdvoSecure.Api.Areas.Application.Models.Case;

public class CaseListResponse
{
    public Guid? Id { get; set; }
    public string CaseNumber { get; set; } = null!;
    public string? CaseReferenceNumber { get; set; }
    public string Title { get; set; } = null!;
    public string? Synopsis { get; set; }
    public string? Clients { get; set; }
    public string? CaseAreaTitle { get; set; }
}
