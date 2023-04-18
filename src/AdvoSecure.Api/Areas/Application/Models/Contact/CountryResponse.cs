namespace AdvoSecure.Api.Areas.Application.Models.Contact;

public class CountryResponse
{
    public string Id { get; set; }      // is not integer but 2-3 digit iso countrycode
    public string Alpha2 { get; set; } = null!;
    public string Alpha3 { get; set; } = null!;
    public string PhoneIso { get; set; } = null!;
    public string CurrencyIso { get; set; } = null!;
    public string EuMember { get; set; } = null!;

    public string CountryName_en { get; set; } = null!;
    public string CountryName_fr { get; set; } = null!;
    public string CountryName_de { get; set; } = null!;
    public string CountryName_it { get; set; } = null!;
    public string CountryName_es { get; set; } = null!;
    public string ibancode { get; set; } = null!;
    public string ibanlen { get; set; } = null!;
    public string ibancheck { get; set; } = null!;
    public string sepa { get; set; } = null!;

}