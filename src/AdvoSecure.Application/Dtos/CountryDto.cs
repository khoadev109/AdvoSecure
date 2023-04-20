namespace AdvoSecure.Application.Dtos
{
    public class CountryDto
    {
        public string Id { get; set; }      // is not integer but 2-3 digit iso countrycode
        public string Alpha2 { get; set; } 
        public string Alpha3 { get; set; }
        public string PhoneIso { get; set; }
        public string CurrencyIso { get; set; }
        public string EuMember { get; set; }
        public string CountryName_en { get; set; }
        public string CountryName_fr { get; set; }
        public string CountryName_de { get; set; }
        public string CountryName_nl { get; set; }
        public string CountryName_it { get; set; }
        public string CountryName_es { get; set; }
        public string ibancode { get; set; }
        public string ibanlen { get; set; }
        public string ibancheck { get; set; }
        public string sepa { get; set; }

    }
}
