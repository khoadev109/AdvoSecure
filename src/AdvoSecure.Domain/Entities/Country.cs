using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities
{
    public class Country : BaseStringIdEntity
    {
        // Id but 2-3 digit iso countrycode
        public string Alpha2 { get; set; } = string.Empty;
        public string Alpha3 { get; set; } = string.Empty;
        public string PhoneIso { get; set; } = string.Empty;
        public string CurrencyIso { get; set; } = string.Empty;
        public string EuMember { get; set; } = string.Empty;

        public string CountryName_en { get; set; } = string.Empty;
        public string CountryName_fr { get; set; } = string.Empty;
        public string CountryName_de { get; set; } = string.Empty;
        public string CountryName_nl { get; set; } = string.Empty;
        public string CountryName_it { get; set; } = string.Empty;
        public string CountryName_es { get; set; } = string.Empty;
        public string ibancode { get; set; } = string.Empty;
        public string ibanlen { get; set; } = string.Empty;
        public string ibancheck { get; set; } = string.Empty;
        public string sepa { get; set; } = string.Empty;
    }
}
