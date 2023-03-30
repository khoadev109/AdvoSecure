namespace AdvoSecure.Api.Models;

public class ContactsListResponse
{
    public Guid Id { get; set; }
    public string? DisplayName { get; set; }
    public bool IsOrganization { get; set; }
    public bool IsOurEmployee { get; set; }
    public int? BillingRateId { get; set; }
    public string? PictureUrl { get; set; }
    public int OnlineStatusId { get; set; }
    public string? Generation { get; set; }
    public string? DisplayNamePrefix { get; set; }
    public string? Surname { get; set; }
    public string? MiddleName { get; set; }
    public string? GivenName { get; set; }
    public string? Initials { get; set; }
    public string? PrimaryEmailAddress { get; set; }
}