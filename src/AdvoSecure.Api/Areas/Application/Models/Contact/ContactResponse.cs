using AdvoSecure.Domain.Enums;

namespace AdvoSecure.Api.Areas.Application.Models.Contact;

public class ContactResponse
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; } = null!;
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
    public CompanyResponse? Company { get; set; }
    public ICollection<AddressResponse> Addresses { get; set; } = new List<AddressResponse>();

}

public class AddressResponse
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; } = null!;
    public AddressType AddressType { get; set; } = AddressType.Post;
    public string Street { get; set; } = null!;
    public string? HouseNo { get; set; }
    public string? HouseNoExt { get; set; }
    public string? Line2 { get; set; }
    public string City { get; set; } = null!;
    public string? StateOrProvince { get; set; }
    public string? PostalCode { get; set; }
    public string? PostOfficeBox { get; set; }
    public CountryResponse? Country { get; set; } = null!;
}



public class CompanyResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
}