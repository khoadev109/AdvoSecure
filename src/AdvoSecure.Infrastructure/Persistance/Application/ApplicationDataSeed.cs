using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Language;
using AdvoSecure.Domain.Entities.Matters;
using AdvoSecure.Domain.Enums;
using AdvoSecure.Infrastructure.Persistance.App;
using AdvoSecure.Infrastructure.Persistance.Tenant;
using AutoMapper.Execution;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Threading.Tasks;

namespace AdvoSecure.Infrastructure.Persistance
{
    public static class ApplicationDataSeed
    {
        public static async Task SeedAsAppTables(ApplicationDbContext context)
        {
            try
            {
                await SeedBillingRates(context);

                await SeedCompanyLegalStatuses(context);

                await SeedCountries(context);

                await SeedContactIdTypes(context);

                await SeedContactCivilStatuses(context);

                await SeedLanguages(context);

                await context.SaveChangesAsync();

                await SeedEmployees(context);

                await SeedPersons(context);

                await SeedCompanies(context);

                await SeedMatterType(context);

                await SeedMatterAreas(context);

                await SeedCourtGeographicalJurisdictions(context);

                await SeedCourtSittingInCities(context);

                await context.SaveChangesAsync();

                await SeedMatters(context);

                await SeedTaskType(context);

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public static async Task SeedCompanyLegalStatuses(ApplicationDbContext context)
        {
            if (!context.CompanyLegalStatuses.Any())
            {
                await context.CompanyLegalStatuses.AddRangeAsync(
                    new CompanyLegalStatus
                    {
                        Title = "Eenmanszaak",
                        CreatedBy = "TOAA"
                    },
                    new CompanyLegalStatus
                    {
                        Title = "VOF",
                        CreatedBy = "TOAA"
                    },
                    new CompanyLegalStatus
                    {
                        Title = "Maatschap",
                        CreatedBy = "TOAA"
                    },
                    new CompanyLegalStatus
                    {
                        Title = "BV",
                        CreatedBy = "TOAA"
                    },
                    new CompanyLegalStatus
                    {
                        Title = "NV",
                        CreatedBy = "TOAA"
                    },
                    new CompanyLegalStatus
                    {
                        Title = "CV",
                        CreatedBy = "TOAA"
                    },
                    new CompanyLegalStatus
                    {
                        Title = "Stichting",
                        CreatedBy = "TOAA"
                    },
                    new CompanyLegalStatus
                    {
                        Title = "Vereniging",
                        CreatedBy = "TOAA"
                    },
                    new CompanyLegalStatus
                    {
                        Title = "Coöperatie",
                        CreatedBy = "TOAA"
                    },
                    new CompanyLegalStatus
                    {
                        Title = "GmbH",
                        CreatedBy = "TOAA"
                    },
                    new CompanyLegalStatus
                    {
                        Title = "GbR",
                        CreatedBy = "TOAA"
                    },
                    new CompanyLegalStatus
                    {
                        Title = "KG",
                        CreatedBy = "TOAA"
                    },
                    new CompanyLegalStatus
                    {
                        Title = "AG",
                        CreatedBy = "TOAA"
                    },
                    new CompanyLegalStatus
                    {
                        Title = "SE",
                        CreatedBy = "TOAA"
                    },
                    new CompanyLegalStatus
                    {
                        Title = "SCE",
                        CreatedBy = "TOAA"
                    },
                    new CompanyLegalStatus
                    {
                        Title = "EESV",
                        CreatedBy = "TOAA"
                    }
                );
            }
        }

        public static async Task SeedBillingRates(ApplicationDbContext context)
        {
            if (!context.BillingRates.Any())
            {
                await context.BillingRates.AddRangeAsync(
                    new BillingRate
                    {
                        Title = "Partner Tarief",
                        PricePerUnit = 200,
                        CreatedBy = "TOAA"
                    },
                    new BillingRate
                    {
                        Title = "Kantoorkosten",
                        PricePerUnit = 50,
                        CreatedBy = "TOAA"
                    },
                    new BillingRate
                    {
                        Title = "Assistent",
                        PricePerUnit = 100,
                        CreatedBy = "TOAA"
                    },
                    new BillingRate
                    {
                        Title = "Basis Kantoortarief",
                        PricePerUnit = 150,
                        CreatedBy = "TOAA"
                    }
                );
            }
        }

        public static async Task SeedCountries(ApplicationDbContext context)
        {
            if (!context.Countries.Any())
            {
                await context.Countries.AddRangeAsync(
                    new Country
                    {
                        Id = "4",
                        Alpha2 = "af",
                        Alpha3 = "afg",
                        PhoneIso = "93",
                        CurrencyIso = "",
                        EuMember = "N/A",
                        CountryName_en = "Afghanistan",
                        CountryName_fr = "Afghanistan",
                        CountryName_de = "Afghanistan",
                        CountryName_nl = "Afghanistan",
                        CountryName_it = "Afghanistan",
                        CountryName_es = "Afganistán",
                        CreatedBy = "TOAA"
                    },
                    new Country
                    {
                        Id = "248",
                        Alpha2 = "ax",
                        Alpha3 = "ala",
                        PhoneIso = "",
                        CurrencyIso = "",
                        EuMember = "N/A",
                        CountryName_en = "Åland Islands",
                        CountryName_fr = "Îles Åland",
                        CountryName_de = "Åland",
                        CountryName_nl = "Åland",
                        CountryName_it = "Isole",
                        CountryName_es = "Åland",
                        CreatedBy = "TOAA"
                    },
                     new Country
                     {
                         Id = "8",
                         Alpha2 = "al",
                         Alpha3 = "alb",
                         PhoneIso = "355",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Albania",
                         CountryName_fr = "Albanie",
                         CountryName_de = "Albanien",
                         CountryName_nl = "Albanië",
                         CountryName_it = "Albania",
                         CountryName_es = "Albania",
                         CreatedBy = "TOAA"
                     },
                     new Country
                     {
                         Id = "12",
                         Alpha2 = "dz",
                         Alpha3 = "dza",
                         PhoneIso = "213",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Algeria",
                         CountryName_fr = "Algérie",
                         CountryName_de = "Algerien",
                         CountryName_nl = "Algerije",
                         CountryName_it = "Algeria",
                         CountryName_es = "Argelia",
                         CreatedBy = "TOAA"
                     },
                     new Country
                     {
                         Id = "16",
                         Alpha2 = "as",
                         Alpha3 = "asm",
                         PhoneIso = "1-684",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "American Samoa",
                         CountryName_fr = "Samoa américaines",
                         CountryName_de = "Amerikanisch-Samoa",
                         CountryName_nl = "Amerikaans-Samoa",
                         CountryName_it = "Samoa Americane",
                         CountryName_es = "Samoa Americana",
                         CreatedBy = "TOAA"
                     },
                     new Country
                     {
                         Id = "20",
                         Alpha2 = "ad",
                         Alpha3 = "ago",
                         PhoneIso = "244",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Angola",
                         CountryName_fr = "Angola",
                         CountryName_de = "Angola",
                         CountryName_nl = "Angola",
                         CountryName_it = "Angola",
                         CountryName_es = "Angola",
                         CreatedBy = "TOAA"
                     },
                     new Country
                     {
                         Id = "660",
                         Alpha2 = "ai",
                         Alpha3 = "aia",
                         PhoneIso = "1-264",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Anguilla",
                         CountryName_fr = "Anguilla",
                         CountryName_de = "Anguilla",
                         CountryName_nl = "Anguilla",
                         CountryName_it = "Anguilla",
                         CountryName_es = "Anguila",
                         CreatedBy = "TOAA"
                     },
                     new Country
                     {
                         Id = "10",
                         Alpha2 = "aq",
                         Alpha3 = "ata",
                         PhoneIso = "672",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Antarctica",
                         CountryName_fr = "Antarctique",
                         CountryName_de = "Antarktika (Sonderstatus durch Antarktis-Vertrag)",
                         CountryName_nl = "Antarctica",
                         CountryName_it = "Antartide",
                         CountryName_es = "Antártida",
                         CreatedBy = "TOAA"
                     },
                     new Country
                     {
                         Id = "28",
                         Alpha2 = "ag",
                         Alpha3 = "atg",
                         PhoneIso = "1-268",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Antigua and Barbuda",
                         CountryName_fr = "Antigua-et-Barbuda",
                         CountryName_de = "Antigua und Barbuda",
                         CountryName_nl = "Antigua en Barbuda",
                         CountryName_it = "Antigua e Barbuda",
                         CountryName_es = "Antigua y Barbuda",
                         CreatedBy = "TOAA"
                     },
                     new Country
                     {
                         Id = "32",
                         Alpha2 = "ar",
                         Alpha3 = "arg",
                         PhoneIso = "54",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Argentina",
                         CountryName_fr = "Argentine",
                         CountryName_de = "Argentinien",
                         CountryName_nl = "Argentinië",
                         CountryName_it = "Argentina",
                         CountryName_es = "Argentina",
                         CreatedBy = "TOAA"
                     },
                     new Country
                     {
                         Id = "51",
                         Alpha2 = "am",
                         Alpha3 = "arm",
                         PhoneIso = "374",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Armenia",
                         CountryName_fr = "Arménie",
                         CountryName_de = "Armenien",
                         CountryName_nl = "Armenië",
                         CountryName_it = "Armenia",
                         CountryName_es = "Armenia",
                         CreatedBy = "TOAA"
                     },
                     new Country
                     {
                         Id = "533",
                         Alpha2 = "aw",
                         Alpha3 = "abw",
                         PhoneIso = "297",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Aruba",
                         CountryName_fr = "Aruba",
                         CountryName_de = "Aruba",
                         CountryName_nl = "Aruba",
                         CountryName_it = "Aruba",
                         CountryName_es = "Aruba",
                         CreatedBy = "TOAA"
                     },
                     new Country
                     {
                         Id = "36",
                         Alpha2 = "au",
                         Alpha3 = "aus",
                         PhoneIso = "61",
                         CurrencyIso = "AUD",
                         EuMember = "N/A",
                         CountryName_en = "Australia",
                         CountryName_fr = "Australie",
                         CountryName_de = "Australien",
                         CountryName_nl = "Australië",
                         CountryName_it = "Australia",
                         CountryName_es = "Australia",
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "40",
                         Alpha2 = "at",
                         Alpha3 = "aut",
                         PhoneIso = "43",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Austria",
                         CountryName_fr = "Autriche",
                         CountryName_de = "Österreich",
                         CountryName_nl = "Oostenrijk",
                         CountryName_it = "Austria",
                         CountryName_es = "Austria"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "31",
                         Alpha2 = "az",
                         Alpha3 = "aze",
                         PhoneIso = "994",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Azerbaijan",
                         CountryName_fr = "Azerbaïdjan",
                         CountryName_de = "Aserbaidschan",
                         CountryName_nl = "Azerbeidzjan",
                         CountryName_it = "Azerbaigian",
                         CountryName_es = "Azerbaiyán"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "44",
                         Alpha2 = "bs",
                         Alpha3 = "bhs",
                         PhoneIso = "1-242",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Bahamas",
                         CountryName_fr = "Bahamas",
                         CountryName_de = "Bahamas",
                         CountryName_nl = "Bahama-s",
                         CountryName_it = "Bahamas",
                         CountryName_es = "Bahamas"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "48",
                         Alpha2 = "bh",
                         Alpha3 = "bhr",
                         PhoneIso = "973",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Bahrain",
                         CountryName_fr = "Bahreïn",
                         CountryName_de = "Bahrain",
                         CountryName_nl = "Bahrein",
                         CountryName_it = "Bahrein",
                         CountryName_es = "Baréin"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "50",
                         Alpha2 = "bd",
                         Alpha3 = "bgd",
                         PhoneIso = "880",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Bangladesh",
                         CountryName_fr = "Bangladesh",
                         CountryName_de = "Bangladesch",
                         CountryName_nl = "Bangladesh",
                         CountryName_it = "Bangladesh",
                         CountryName_es = "Bangladés"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "52",
                         Alpha2 = "bb",
                         Alpha3 = "brb",
                         PhoneIso = "1-246",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Barbados",
                         CountryName_fr = "Barbade",
                         CountryName_de = "Barbados",
                         CountryName_nl = "Barbados",
                         CountryName_it = "Barbados",
                         CountryName_es = "Barbados"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "112",
                         Alpha2 = "by",
                         Alpha3 = "blr",
                         PhoneIso = "375",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Belarus",
                         CountryName_fr = "Biélorussie",
                         CountryName_de = "Belarus(Weißrussland)",
                         CountryName_nl = "Wit-Rusland",
                         CountryName_it = "Bielorussia",
                         CountryName_es = "Bielorrusia"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "56",
                         Alpha2 = "be",
                         Alpha3 = "bel",
                         PhoneIso = "32",
                         CurrencyIso = "EUR",
                         EuMember = "N/A",
                         CountryName_en = "Belgium",
                         CountryName_fr = "Belgique",
                         CountryName_de = "Belgien",
                         CountryName_nl = "België",
                         CountryName_it = "Belgio",
                         CountryName_es = "Bélgica"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "84",
                         Alpha2 = "bz",
                         Alpha3 = "blz",
                         PhoneIso = "501",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Belize",
                         CountryName_fr = "Belize",
                         CountryName_de = "Belize",
                         CountryName_nl = "Belize",
                         CountryName_it = "Belize",
                         CountryName_es = "Belice"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "204",
                         Alpha2 = "bj",
                         Alpha3 = "ben",
                         PhoneIso = "229",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Benin",
                         CountryName_fr = "Bénin",
                         CountryName_de = "Benin",
                         CountryName_nl = "Benin",
                         CountryName_it = "Benin",
                         CountryName_es = "Benín"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "60",
                         Alpha2 = "bm",
                         Alpha3 = "bmu",
                         PhoneIso = "1-441",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Bermuda",
                         CountryName_fr = "Bermudes",
                         CountryName_de = "Bermuda",
                         CountryName_nl = "Bermuda",
                         CountryName_it = "Bermuda",
                         CountryName_es = "Bermudas"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "64",
                         Alpha2 = "bt",
                         Alpha3 = "btn",
                         PhoneIso = "975",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Bhutan",
                         CountryName_fr = "Bhoutan",
                         CountryName_de = "Bhutan",
                         CountryName_nl = "Bhutan",
                         CountryName_it = "Bhutan",
                         CountryName_es = "Bután"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "68",
                         Alpha2 = "bo",
                         Alpha3 = "bol",
                         PhoneIso = "591",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Bolivia(PlurinationalStateof)",
                         CountryName_fr = "Bolivie",
                         CountryName_de = "Bolivien",
                         CountryName_nl = "Bolivia",
                         CountryName_it = "Bolivia",
                         CountryName_es = "Bolivia"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "535",
                         Alpha2 = "bq",
                         Alpha3 = "bes",
                         PhoneIso = "",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Bonaire,SintEustatiusandSaba",
                         CountryName_fr = "Pays-Bascaribéens",
                         CountryName_de = "Bonaire,SintEustatiusundSaba(Niederlande)",
                         CountryName_nl = "CaribischNederland	IsoleBES",
                         CountryName_it = "Bonaire,SanEustaquioySaba",
                         CountryName_es = ""


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "70",
                         Alpha2 = "ba",
                         Alpha3 = "bih",
                         PhoneIso = "387",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "BosniaandHerzegovina",
                         CountryName_fr = "Bosnie-Herzégovine",
                         CountryName_de = "BosnienundHerzegowina",
                         CountryName_nl = "BosniëenHerzegovina	BosniaedErzegovina",
                         CountryName_it = "BosniayHerzegovina",
                         CountryName_es = ""


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "72",
                         Alpha2 = "bw",
                         Alpha3 = "bwa",
                         PhoneIso = "267",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Botswana",
                         CountryName_fr = "Botswana",
                         CountryName_de = "Botswana",
                         CountryName_nl = "Botswana",
                         CountryName_it = "Botswana",
                         CountryName_es = "Botsuana"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "74",
                         Alpha2 = "bv",
                         Alpha3 = "bvt",
                         PhoneIso = "55",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "BouvetIsland",
                         CountryName_fr = "ÎleBouvet",
                         CountryName_de = "Bouvetinsel",
                         CountryName_nl = "Bouveteiland",
                         CountryName_it = "IsolaBouvet",
                         CountryName_es = "IslaBouvet"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "76",
                         Alpha2 = "br",
                         Alpha3 = "bra",
                         PhoneIso = "246",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Brazil",
                         CountryName_fr = "Brésil",
                         CountryName_de = "Brasilien",
                         CountryName_nl = "Brazilië",
                         CountryName_it = "Brasile",
                         CountryName_es = "Brasil"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "86",
                         Alpha2 = "io",
                         Alpha3 = "iot",
                         PhoneIso = "1-284",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "BritishIndianOceanTerritory",
                         CountryName_fr = "Territoirebritanniquedel-océanIndien",
                         CountryName_de = "BritischesTerritoriumimIndischenOzean",
                         CountryName_nl = "BritsIndischeOceaanterritorium",
                         CountryName_it = "Territoriobritannicodell-OceanoIndiano",
                         CountryName_es = "TerritorioBritánicodelOcéanoÍndico"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "96",
                         Alpha2 = "bn",
                         Alpha3 = "brn",
                         PhoneIso = "673",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "BruneiDarussalam",
                         CountryName_fr = "Brunei",
                         CountryName_de = "Brunei",
                         CountryName_nl = "Darussalam	Brunei",
                         CountryName_it = "Brunei",
                         CountryName_es = "Brunéi"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "100",
                         Alpha2 = "bg",
                         Alpha3 = "bgr",
                         PhoneIso = "359",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Bulgaria",
                         CountryName_fr = "Bulgarie",
                         CountryName_de = "Bulgarien",
                         CountryName_nl = "Bulgarije",
                         CountryName_it = "Bulgaria",
                         CountryName_es = "Bulgaria"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "854",
                         Alpha2 = "bf",
                         Alpha3 = "bfa",
                         PhoneIso = "226",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "BurkinaFaso",
                         CountryName_fr = "BurkinaFaso",
                         CountryName_de = "BurkinaFaso",
                         CountryName_nl = "BurkinaFaso",
                         CountryName_it = "BurkinaFaso",
                         CountryName_es = "BurkinaFaso"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "108",
                         Alpha2 = "bi",
                         Alpha3 = "bdi",
                         PhoneIso = "257",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Burundi",
                         CountryName_fr = "Burundi",
                         CountryName_de = "Burundi",
                         CountryName_nl = "Burundi",
                         CountryName_it = "Burundi",
                         CountryName_es = "Burundi"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "132",
                         Alpha2 = "cv",
                         Alpha3 = "cpv",
                         PhoneIso = "238",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "CaboVerde",
                         CountryName_fr = "Cap-Vert",
                         CountryName_de = "KapVerde",
                         CountryName_nl = "Kaapverdië",
                         CountryName_it = "CapoVerde",
                         CountryName_es = "CaboVerde"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "116",
                         Alpha2 = "kh",
                         Alpha3 = "khm",
                         PhoneIso = "855",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Cambodia",
                         CountryName_fr = "Cambodge",
                         CountryName_de = "Kambodscha",
                         CountryName_nl = "Cambodja",
                         CountryName_it = "Cambogia",
                         CountryName_es = "Camboya"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "120",
                         Alpha2 = "cm",
                         Alpha3 = "cmr",
                         PhoneIso = "237",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "Cameroon",
                         CountryName_fr = "Cameroun",
                         CountryName_de = "Kamerun",
                         CountryName_nl = "Kameroen",
                         CountryName_it = "Camerun",
                         CountryName_es = "Camerún"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "124",
                         Alpha2 = "ca",
                         Alpha3 = "can",
                         PhoneIso = "1",
                         CurrencyIso = "CAD",
                         EuMember = "N/A",
                         CountryName_en = "Canada",
                         CountryName_fr = "Canada",
                         CountryName_de = "Kanada",
                         CountryName_nl = "Canada",
                         CountryName_it = "Canada",
                         CountryName_es = "Canadá"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "136",
                         Alpha2 = "ky",
                         Alpha3 = "cym",
                         PhoneIso = "1-345",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "CaymanIslands",
                         CountryName_fr = "ÎlesCaïmans",
                         CountryName_de = "Kaimaninseln",
                         CountryName_nl = "Kaaimaneilanden",
                         CountryName_it = "IsoleCayman",
                         CountryName_es = "IslasCaimán"


                     ,
                         CreatedBy = "TOAA"
                     }, new Country
                     {
                         Id = "140",
                         Alpha2 = "cf",
                         Alpha3 = "caf",
                         PhoneIso = "236",
                         CurrencyIso = "",
                         EuMember = "N/A",
                         CountryName_en = "CentralAfricanRepublic",
                         CountryName_fr = "Centrafrique",
                         CountryName_de = "ZentralafrikanischeRepublik",
                         CountryName_nl = "Centraal-AfrikaanseRepubliek",
                         CountryName_it = "Rep.Centrafricana",
                         CountryName_es = "RepúblicaCentroafricana"
                     ,
                         CreatedBy = "TOAA"
                     },
                     new Country { Id = "148	", Alpha2 = "td", Alpha3 = "tcd", PhoneIso = "235", CurrencyIso = "   ", EuMember = "N/A", CountryName_en = "Chad", CountryName_fr = "Tchad", CountryName_de = "Tschad", CountryName_nl = "Tsjaad", CountryName_it = "Ciad", CountryName_es = "Chad", CreatedBy = "TOAA" },

                    new Country { Id = "152	", Alpha2 = "cl", Alpha3 = "chl", PhoneIso = "56 ", CurrencyIso = "   ", EuMember = "N/A", CountryName_en = "Chile", CountryName_fr = "Chili", CountryName_de = "Chile", CountryName_nl = "Chili", CountryName_it = "Cile", CountryName_es = "Chile", CreatedBy = "TOAA" },

                    new Country
                    { Id = "156	", Alpha2 = "cn", Alpha3 = "chn", PhoneIso = "86 ", CurrencyIso = "   ", EuMember = "N/A", CountryName_en = "China", CountryName_fr = "Chine", CountryName_de = "China, Volksrepublik", CountryName_nl = "China", CountryName_it = "Cina", CountryName_es = "China", CreatedBy = "TOAA" },

                    new Country
                    {
                        Id = "162	",
                        Alpha2 = "cx",
                        Alpha3 = "cxr",
                        PhoneIso = "61 ",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Christmas Island",
                        CountryName_fr = "Île Christmas",
                        CountryName_de = "Weihnachtsinsel",
                        CountryName_nl = "Christmaseiland",
                        CountryName_it = "Isola di Natale",
                        CountryName_es = "Isla de Navidad"
                    ,
                        CreatedBy = "TOAA"
                    },
                    new Country { Id = "166	", Alpha2 = "cc", Alpha3 = "cck", PhoneIso = "61 ", CurrencyIso = "   ", EuMember = "N/A", CountryName_en = "Cocos (Keeling) Islands", CountryName_fr = "Îles Cocos", CountryName_de = "Kokosinseln", CountryName_nl = "Cocoseilanden", CountryName_it = "Isole Cocos (Keeling)", CountryName_es = "Islas Cocos", CreatedBy = "TOAA" },
                    new Country { Id = "170	", Alpha2 = "co", Alpha3 = "col", PhoneIso = "57 ", CurrencyIso = "   ", EuMember = "N/A", CountryName_en = "Colombia", CountryName_fr = "Colombie	", CountryName_de = "Kolumbien ", CountryName_nl = "Colombia", CountryName_it = "Colombia", CountryName_es = "Colombia", CreatedBy = "TOAA" },

                    new Country { Id = "174	", Alpha2 = "km", Alpha3 = "com", PhoneIso = "269", CurrencyIso = "   ", EuMember = "N/A", CountryName_en = "Comoros	", CountryName_fr = "Comores (pays)	", CountryName_de = "Komoren", CountryName_nl = "	Comoren", CountryName_it = "	Comore	", CountryName_es = "Comoras", CreatedBy = "TOAA" },

                    new Country { Id = "178	", Alpha2 = "cg", Alpha3 = "cog", PhoneIso = "242", CurrencyIso = "   ", EuMember = "N/A", CountryName_en = "Congo", CountryName_fr = "	République du Congo", CountryName_de = "	Kongo, Republik (ehem. K.-Brazzaville)", CountryName_nl = "Congo-Brazzaville", CountryName_it = "	Rep. del Congo", CountryName_es = "República del Congo", CreatedBy = "TOAA" },
                    new Country { Id = "180	", Alpha2 = "cd", Alpha3 = "cod", PhoneIso = "243", CurrencyIso = "   ", EuMember = "N/A", CountryName_en = "Congo (Democratic Republic of the)", CountryName_fr = "République démocratique du Congo", CountryName_de = "Kongo, Demokratische Republik (ehem. Zaire)", CountryName_nl = "Congo-Kinshasa", CountryName_it = "RD del Congo", CountryName_es = "República Democrática del Congo", CreatedBy = "TOAA" },

                    new Country { Id = "184	", Alpha2 = "ck", Alpha3 = "cok", PhoneIso = "682", CurrencyIso = "   ", EuMember = "N/A", CountryName_en = "Cook Islands", CountryName_fr = "Îles Cook", CountryName_de = "Cookinseln", CountryName_nl = "Cookeilanden", CountryName_it = "Isole Cook", CountryName_es = "Islas Cook", CreatedBy = "TOAA" },
                    new Country { Id = "188	", Alpha2 = "cr", Alpha3 = "cri", PhoneIso = "506", CurrencyIso = "   ", EuMember = "N/A", CountryName_en = "Costa Rica", CountryName_fr = "Costa Rica", CountryName_de = "Costa Rica", CountryName_nl = "Costa Rica", CountryName_it = "Costa Rica", CountryName_es = "Costa Rica", CreatedBy = "TOAA" },

                    new Country { Id = "384	", Alpha2 = "ci", Alpha3 = "civ", PhoneIso = "225", CurrencyIso = "   ", EuMember = "N/A", CountryName_en = "Ivory Coast", CountryName_fr = "Côte d-Ivoire", CountryName_de = "Côte d’Ivoire (Elfenbeinküste)", CountryName_nl = "Ivoorkust", CountryName_it = "Costa d-Avorio", CountryName_es = "Costa de Marfil", CreatedBy = "TOAA" },
                    new Country
                    {
                        Id = "191	",
                        Alpha2 = "hr",
                        Alpha3 = "hrv",
                        PhoneIso = "385",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Croatia,",
                        CountryName_fr = "Croatie",
                        CountryName_de = "Kroatien",
                        CountryName_nl = "Kroatië",
                        CountryName_it = "Croazia",
                        CountryName_es = "Croacia"
                    ,
                        CreatedBy = "TOAA"
                    },
                    new Country
                    {
                        Id = "192	",
                        Alpha2 = "cu",
                        Alpha3 = "cub",
                        PhoneIso = "53 ",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Cuba",
                        CountryName_fr = "Cuba",
                        CountryName_de = "Kuba",
                        CountryName_nl = "Cuba",
                        CountryName_it = "Cuba",
                        CountryName_es = "Cuba"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "531	",
                        Alpha2 = "cw",
                        Alpha3 = "cuw",
                        PhoneIso = "599",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Curaçao",
                        CountryName_fr = "Curaçao",
                        CountryName_de = "Curaçao",
                        CountryName_nl = "Curaçao",
                        CountryName_it = "Curaçao",
                        CountryName_es = "Curazao"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "196	",
                        Alpha2 = "cy",
                        Alpha3 = "cyp",
                        PhoneIso = "357",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Cyprus",
                        CountryName_fr = "Chypre (pays)",
                        CountryName_de = "Zypern",
                        CountryName_nl = "Cyprus",
                        CountryName_it = "Cipro",
                        CountryName_es = "Chipre"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "203	",
                        Alpha2 = "cz",
                        Alpha3 = "cze",
                        PhoneIso = "420",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Czechia",
                        CountryName_fr = "Tchéquie",
                        CountryName_de = "Tschechien",
                        CountryName_nl = "Tsjechië",
                        CountryName_it = "Rep. Ceca",
                        CountryName_es = "República Checa"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "208	",
                        Alpha2 = "dk",
                        Alpha3 = "dnk",
                        PhoneIso = "45 ",
                        CurrencyIso = "DKK",
                        EuMember = "N/A",
                        CountryName_en = "Denmark",
                        CountryName_fr = "Danemark",
                        CountryName_de = "Dänemark",
                        CountryName_nl = "Denemarken",
                        CountryName_it = "Danimarca",
                        CountryName_es = "Dinamarca"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "262	",
                        Alpha2 = "dj",
                        Alpha3 = "dji",
                        PhoneIso = "253",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Djibouti",
                        CountryName_fr = "Djibouti",
                        CountryName_de = "Dschibuti",
                        CountryName_nl = "Djibouti",
                        CountryName_it = "Gibuti",
                        CountryName_es = "Yibuti"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "212	",
                        Alpha2 = "dm",
                        Alpha3 = "dma",
                        PhoneIso = "1-767",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Dominica",
                        CountryName_fr = "Dominique",
                        CountryName_de = "Dominica",
                        CountryName_nl = "Dominica",
                        CountryName_it = "Dominica",
                        CountryName_es = "Dominica"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "214	",
                        Alpha2 = "do",
                        Alpha3 = "dom",
                        PhoneIso = "1-809",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Dominican Republic",
                        CountryName_fr = "République dominicaine",
                        CountryName_de = "Dominikanische Republik",
                        CountryName_nl = "Dominicaanse Republiek",
                        CountryName_it = "Rep. Dominicana",
                        CountryName_es = "República Dominicana"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "218	",
                        Alpha2 = "ec",
                        Alpha3 = "ecu",
                        PhoneIso = "593",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Ecuador",
                        CountryName_fr = "Équateur (pays",
                        CountryName_de = "Ecuador",
                        CountryName_nl = "Ecuador",
                        CountryName_it = "Ecuador",
                        CountryName_es = "Ecuador"
                    ,
                        CreatedBy = "TOAA"
                    },
                    new Country
                    {
                        Id = "818	",
                        Alpha2 = "eg",
                        Alpha3 = "egy",
                        PhoneIso = "20      	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Egypt",
                        CountryName_fr = "	Égypte",
                        CountryName_de = "	Ägypten",
                        CountryName_nl = "	Egypte",
                        CountryName_it = "	Egitto",
                        CountryName_es = "	Egipto"
                    ,
                        CreatedBy = "TOAA"
                    },
                    new Country
                    {
                        Id = "222	",
                        Alpha2 = "sv",
                        Alpha3 = "slv",
                        PhoneIso = "503     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "El Salvador",
                        CountryName_fr = "Salvador",
                        CountryName_de = "	El Salvador",
                        CountryName_nl = "	El Salvador",
                        CountryName_it = "	El Salvador",
                        CountryName_es = "El Salvador"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "226	",
                        Alpha2 = "gq",
                        Alpha3 = "gnq",
                        PhoneIso = "240     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Equatorial Guinea",
                        CountryName_fr = "Guinée équatoriale",
                        CountryName_de = "	Äquatorialguinea",
                        CountryName_nl = "Equatoriaal-Guinea",
                        CountryName_it = "Guinea Equatoriale",
                        CountryName_es = "Guinea Ecuatorial"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "232	",
                        Alpha2 = "er",
                        Alpha3 = "eri",
                        PhoneIso = "291     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Eritrea",
                        CountryName_fr = "Érythrée",
                        CountryName_de = "Eritrea",
                        CountryName_nl = "Eritrea",
                        CountryName_it = "Eritrea",
                        CountryName_es = "Eritrea"
                    ,
                        CreatedBy = "TOAA"
                    },
                    new Country
                    {
                        Id = "233	",
                        Alpha2 = "ee",
                        Alpha3 = "est",
                        PhoneIso = "372     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Estonia"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "231	",
                        Alpha2 = "et",
                        Alpha3 = "eth",
                        PhoneIso = "251     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Ethiopia"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "238	",
                        Alpha2 = "fk",
                        Alpha3 = "flk",
                        PhoneIso = "500     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Falkland Islands (Malvinas)"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "234	",
                        Alpha2 = "fo",
                        Alpha3 = "fro",
                        PhoneIso = "298     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Faroe Islands"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "242	",
                        Alpha2 = "fj",
                        Alpha3 = "fji",
                        PhoneIso = "679     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Fiji"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "246	",
                        Alpha2 = "fi",
                        Alpha3 = "fin",
                        PhoneIso = "358     	",
                        CurrencyIso = "EUR",
                        EuMember = "N/A",
                        CountryName_en = "Finland"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "250	",
                        Alpha2 = "fr",
                        Alpha3 = "fra",
                        PhoneIso = "33      	",
                        CurrencyIso = "EUR",
                        EuMember = "N/A",
                        CountryName_en = "France"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "254	",
                        Alpha2 = "gf",
                        Alpha3 = "guf",
                        PhoneIso = "        	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "French Guiana"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "258	",
                        Alpha2 = "pf",
                        Alpha3 = "pyf",
                        PhoneIso = "689     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "French Polynesia"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "260	",
                        Alpha2 = "tf",
                        Alpha3 = "atf",
                        PhoneIso = "        	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "French Southern Territories"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "266	",
                        Alpha2 = "ga",
                        Alpha3 = "gab",
                        PhoneIso = "241     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Gabon"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "270	",
                        Alpha2 = "gm",
                        Alpha3 = "gmb",
                        PhoneIso = "220     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Gambia"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "268	",
                        Alpha2 = "ge",
                        Alpha3 = "geo",
                        PhoneIso = "995     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Georgia"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "276	",
                        Alpha2 = "de",
                        Alpha3 = "deu",
                        PhoneIso = "49      	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Germany"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "288	",
                        Alpha2 = "gh",
                        Alpha3 = "gha",
                        PhoneIso = "233     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Ghana"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "292	",
                        Alpha2 = "gi",
                        Alpha3 = "gib",
                        PhoneIso = "350     	",
                        CurrencyIso = "GIP",
                        EuMember = "N/A",
                        CountryName_en = "Gibraltar"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "300	",
                        Alpha2 = "gr",
                        Alpha3 = "grc",
                        PhoneIso = "30      	",
                        CurrencyIso = "EUR",
                        EuMember = "N/A",
                        CountryName_en = "Greece"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "304	",
                        Alpha2 = "gl",
                        Alpha3 = "grl",
                        PhoneIso = "299     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Greenland"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "308	",
                        Alpha2 = "gd",
                        Alpha3 = "grd",
                        PhoneIso = "1-473   	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Grenada"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "312	",
                        Alpha2 = "gp",
                        Alpha3 = "glp",
                        PhoneIso = "        	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "British Indian Ocean Territory"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "316	",
                        Alpha2 = "gu",
                        Alpha3 = "gum",
                        PhoneIso = "1-671   	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Guam"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "320	",
                        Alpha2 = "gt",
                        Alpha3 = "gtm",
                        PhoneIso = "502     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Guatemala"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "831	",
                        Alpha2 = "gg",
                        Alpha3 = "ggy",
                        PhoneIso = "44-1481 	",
                        CurrencyIso = "GBP",
                        EuMember = "N/A",
                        CountryName_en = "Guernsey"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "324	",
                        Alpha2 = "gn",
                        Alpha3 = "gin",
                        PhoneIso = "224     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Guinea"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "624	",
                        Alpha2 = "gw",
                        Alpha3 = "gnb",
                        PhoneIso = "245     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Guinea-Bissau"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "328	",
                        Alpha2 = "gy",
                        Alpha3 = "guy",
                        PhoneIso = "592     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Guyana"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "332	",
                        Alpha2 = "ht",
                        Alpha3 = "hti",
                        PhoneIso = "509     	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Haiti"
                    ,
                        CreatedBy = "TOAA"
                    },

                    new Country
                    {
                        Id = "334	",
                        Alpha2 = "hm",
                        Alpha3 = "hmd",
                        PhoneIso = "        	",
                        CurrencyIso = "   ",
                        EuMember = "N/A",
                        CountryName_en = "Heard Island and McDonald Islands	Îles"
                    ,
                        CreatedBy = "TOAA"
                    },
                    new Country { Id = "336", Alpha2 = "va", Alpha3 = "	vat", PhoneIso = "	       ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Holy See", CreatedBy = "TOAA" },
                    new Country { Id = "340", Alpha2 = "hn", Alpha3 = "	hnd", PhoneIso = "	504    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Honduras", CreatedBy = "TOAA" },
                    new Country { Id = "344", Alpha2 = "hk", Alpha3 = "	hkg", PhoneIso = "	852    ", CurrencyIso = "	HKD", EuMember = "N/A", CountryName_en = "Hong Kong", CreatedBy = "TOAA" },
                    new Country { Id = "348", Alpha2 = "hu", Alpha3 = "	hun", PhoneIso = "	36     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Hungary", CreatedBy = "TOAA" },
                    new Country { Id = "352", Alpha2 = "is", Alpha3 = "	isl", PhoneIso = "	354    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Iceland", CreatedBy = "TOAA" },
                    new Country { Id = "356", Alpha2 = "in", Alpha3 = "	ind", PhoneIso = "	91     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "India", CreatedBy = "TOAA" },
                    new Country { Id = "360", Alpha2 = "id", Alpha3 = "	idn", PhoneIso = "	62     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Indonesia", CreatedBy = "TOAA" },
                    new Country { Id = "364", Alpha2 = "ir", Alpha3 = "	irn", PhoneIso = "	98     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Iran (Islamic Republic of)", CreatedBy = "TOAA" },
                    new Country { Id = "368", Alpha2 = "iq", Alpha3 = "	irq", PhoneIso = "	964    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Iraq", CreatedBy = "TOAA" },
                    new Country { Id = "372", Alpha2 = "ie", Alpha3 = "	irl", PhoneIso = "	353    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Ireland", CreatedBy = "TOAA" },
                    new Country { Id = "833", Alpha2 = "im", Alpha3 = "	imn", PhoneIso = "	44-1624", CurrencyIso = "	GPB", EuMember = "N/A", CountryName_en = "Isle of Man", CreatedBy = "TOAA" },
                    new Country { Id = "376", Alpha2 = "il", Alpha3 = "	isr", PhoneIso = "	972    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Israel", CreatedBy = "TOAA" },
                    new Country { Id = "380", Alpha2 = "it", Alpha3 = "	ita", PhoneIso = "	39     ", CurrencyIso = "	EUR", EuMember = "N/A", CountryName_en = "Italy", CreatedBy = "TOAA" },
                    new Country { Id = "388", Alpha2 = "jm", Alpha3 = "	jam", PhoneIso = "	1-876  ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Jamaica", CreatedBy = "TOAA" },
                    new Country { Id = "392", Alpha2 = "jp", Alpha3 = "	jpn", PhoneIso = "	81     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Japan", CreatedBy = "TOAA" },
                    new Country { Id = "832", Alpha2 = "je", Alpha3 = "	jey", PhoneIso = "	44-1534", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Jersey", CreatedBy = "TOAA" },
                    new Country { Id = "400", Alpha2 = "jo", Alpha3 = "	jor", PhoneIso = "	962    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Jordan", CreatedBy = "TOAA" },
                    new Country { Id = "398", Alpha2 = "kz", Alpha3 = "	kaz", PhoneIso = "	7      ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Kazakhstan", CreatedBy = "TOAA" },
                    new Country { Id = "404", Alpha2 = "ke", Alpha3 = "	ken", PhoneIso = "	254    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Kenya", CreatedBy = "TOAA" },
                    new Country { Id = "296", Alpha2 = "ki", Alpha3 = "	kir", PhoneIso = "	686    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Kiribati", CreatedBy = "TOAA" },
                    new Country { Id = "383", Alpha2 = "xk", Alpha3 = "	xkx", PhoneIso = "	383    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Kosovo", CreatedBy = "TOAA" },
                    new Country { Id = "408", Alpha2 = "kp", Alpha3 = "	prk", PhoneIso = "	850    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Noth Korea (Democratic People-s Republic of)", CreatedBy = "TOAA" },
                    new Country { Id = "410", Alpha2 = "kr", Alpha3 = "	kor", PhoneIso = "	82     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "South Korea (Republic of)", CreatedBy = "TOAA" },
                    new Country { Id = "414", Alpha2 = "kw", Alpha3 = "	kwt", PhoneIso = "	965    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Kuwait", CreatedBy = "TOAA" },
                    new Country { Id = "417", Alpha2 = "kg", Alpha3 = "	kgz", PhoneIso = "	996    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Kyrgyzstan", CreatedBy = "TOAA" },
                    new Country { Id = "418", Alpha2 = "la", Alpha3 = "	lao", PhoneIso = "	856    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Laos People-s Democratic", CreatedBy = "TOAA" },
                    new Country { Id = "428", Alpha2 = "lv", Alpha3 = "	lva", PhoneIso = "	371    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Latvia", CreatedBy = "TOAA" },
                    new Country { Id = "422", Alpha2 = "lb", Alpha3 = "	lbn", PhoneIso = "	961    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Lebanon", CreatedBy = "TOAA" },
                    new Country { Id = "426", Alpha2 = "ls", Alpha3 = "	lso", PhoneIso = "	266    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Lesotho", CreatedBy = "TOAA" },
                    new Country { Id = "430", Alpha2 = "lr", Alpha3 = "	lbr", PhoneIso = "	231    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Liberia", CreatedBy = "TOAA" },
                    new Country { Id = "434", Alpha2 = "ly", Alpha3 = "	lby", PhoneIso = "	218    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Libya", CreatedBy = "TOAA" },
                    new Country { Id = "438", Alpha2 = "li", Alpha3 = "	lie", PhoneIso = "	423    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Liechtenstein", CreatedBy = "TOAA" },
                    new Country { Id = "440", Alpha2 = "lt", Alpha3 = "	ltu", PhoneIso = "	370    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Lithuania", CreatedBy = "TOAA" },
                    new Country { Id = "442", Alpha2 = "lu", Alpha3 = "	lux", PhoneIso = "	352    ", CurrencyIso = "	EUR", EuMember = "N/A", CountryName_en = "Luxembourg", CreatedBy = "TOAA" },
                    new Country { Id = "446", Alpha2 = "mo", Alpha3 = "	mac", PhoneIso = "	853    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Macao", CreatedBy = "TOAA" },
                    new Country { Id = "807", Alpha2 = "mk", Alpha3 = "	mkd", PhoneIso = "	389    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Macedonia", CreatedBy = "TOAA" },
                    new Country { Id = "450", Alpha2 = "mg", Alpha3 = "	mdg", PhoneIso = "	261    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Madagascar", CreatedBy = "TOAA" },
                    new Country { Id = "454", Alpha2 = "mw", Alpha3 = "	mwi", PhoneIso = "	265    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Malawi", CreatedBy = "TOAA" },
                    new Country { Id = "458", Alpha2 = "my", Alpha3 = "	mys", PhoneIso = "	60     ", CurrencyIso = "	MYR", EuMember = "N/A", CountryName_en = "Malaysia", CreatedBy = "TOAA" },
                    new Country { Id = "462", Alpha2 = "mv", Alpha3 = "	mdv", PhoneIso = "	960    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Maldives", CreatedBy = "TOAA" },
                    new Country { Id = "466", Alpha2 = "ml", Alpha3 = "	mli", PhoneIso = "	223    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Mali", CreatedBy = "TOAA" },
                    new Country { Id = "470", Alpha2 = "mt", Alpha3 = "	mlt", PhoneIso = "	356    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Malta", CreatedBy = "TOAA" },
                    new Country { Id = "584", Alpha2 = "mh", Alpha3 = "	mhl", PhoneIso = "	692    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Marshall", CreatedBy = "TOAA" },
                    new Country { Id = "474", Alpha2 = "mq", Alpha3 = "	mtq", PhoneIso = "	       ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Martinique", CreatedBy = "TOAA" },
                    new Country { Id = "478", Alpha2 = "mr", Alpha3 = "	mrt", PhoneIso = "	222    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Mauritania", CreatedBy = "TOAA" },
                    new Country { Id = "480", Alpha2 = "mu", Alpha3 = "	mus", PhoneIso = "	230    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Mauritius", CreatedBy = "TOAA" },
                    new Country { Id = "175", Alpha2 = "yt", Alpha3 = "	myt", PhoneIso = "	262    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Mayotte", CreatedBy = "TOAA" },
                    new Country { Id = "484", Alpha2 = "mx", Alpha3 = "	mex", PhoneIso = "	52     ", CurrencyIso = "	MXN", EuMember = "N/A", CountryName_en = "Mexico", CreatedBy = "TOAA" },
                    new Country { Id = "583", Alpha2 = "fm", Alpha3 = "	fsm", PhoneIso = "	691    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Micronesia", CreatedBy = "TOAA" },
                    new Country { Id = "498", Alpha2 = "md", Alpha3 = "	mda", PhoneIso = "	373    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Moldova", CreatedBy = "TOAA" },
                    new Country { Id = "492", Alpha2 = "mc", Alpha3 = "	mco", PhoneIso = "	377    ", CurrencyIso = "	EUR", EuMember = "N/A", CountryName_en = "Monaco", CreatedBy = "TOAA" },
                    new Country { Id = "496", Alpha2 = "mn", Alpha3 = "	mng", PhoneIso = "	976    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Mongolia", CreatedBy = "TOAA" },
                    new Country { Id = "499", Alpha2 = "me", Alpha3 = "	mne", PhoneIso = "	382    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Montenegro", CreatedBy = "TOAA" },
                    new Country { Id = "500", Alpha2 = "ms", Alpha3 = "	msr", PhoneIso = "	1-664  ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Montserrat", CreatedBy = "TOAA" },
                    new Country { Id = "504", Alpha2 = "ma", Alpha3 = "	mar", PhoneIso = "	212    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Morocco	Maroc", CreatedBy = "TOAA" },
                    new Country { Id = "508", Alpha2 = "mz", Alpha3 = "	moz", PhoneIso = "	258    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Mozambique", CreatedBy = "TOAA" },
                    new Country { Id = "104", Alpha2 = "mm", Alpha3 = "	mmr", PhoneIso = "	95     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Myanmar", CreatedBy = "TOAA" },
                    new Country { Id = "516", Alpha2 = "na", Alpha3 = "	nam", PhoneIso = "	264    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Namibia", CreatedBy = "TOAA" },
                    new Country { Id = "520", Alpha2 = "nr", Alpha3 = "	nru", PhoneIso = "	674    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Nauru", CreatedBy = "TOAA" },
                    new Country { Id = "524", Alpha2 = "np", Alpha3 = "	npl", PhoneIso = "	977    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Nepal", CreatedBy = "TOAA" },
                    new Country { Id = "528", Alpha2 = "nl", Alpha3 = "	nld", PhoneIso = "	31     ", CurrencyIso = "	EUR", EuMember = "N/A", CountryName_en = "Netherlands", CreatedBy = "TOAA" },
                    new Country { Id = "540", Alpha2 = "nc", Alpha3 = "	ncl", PhoneIso = "	687    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "New Caledonia", CreatedBy = "TOAA" },
                    new Country { Id = "554", Alpha2 = "nz", Alpha3 = "	nzl", PhoneIso = "	64     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "New Zealand", CreatedBy = "TOAA" },
                    new Country { Id = "558", Alpha2 = "ni", Alpha3 = "	nic", PhoneIso = "	505    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Nicaragua", CreatedBy = "TOAA" },
                    new Country { Id = "562", Alpha2 = "ne", Alpha3 = "	ner", PhoneIso = "	227    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Niger", CreatedBy = "TOAA" },
                    new Country { Id = "566", Alpha2 = "ng", Alpha3 = "	nga", PhoneIso = "	234    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Nigeria", CreatedBy = "TOAA" },
                    new Country { Id = "570", Alpha2 = "nu", Alpha3 = "	niu", PhoneIso = "	683    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Niue", CreatedBy = "TOAA" },
                    new Country { Id = "574", Alpha2 = "nf", Alpha3 = "	nfk", PhoneIso = "	672    ", CurrencyIso = "	AUD", EuMember = "N/A", CountryName_en = "Norfolk", CreatedBy = "TOAA" },
                    new Country { Id = "580", Alpha2 = "mp", Alpha3 = "	mnp", PhoneIso = "	1-670  ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Northern", CreatedBy = "TOAA" },
                    new Country { Id = "578", Alpha2 = "no", Alpha3 = "	nor", PhoneIso = "	47     ", CurrencyIso = "	NOK", EuMember = "N/A", CountryName_en = "Norway", CreatedBy = "TOAA" },
                    new Country { Id = "512", Alpha2 = "om", Alpha3 = "	omn", PhoneIso = "	968    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Oman", CreatedBy = "TOAA" },
                    new Country { Id = "586", Alpha2 = "pk", Alpha3 = "	pak", PhoneIso = "	92     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Pakistan", CreatedBy = "TOAA" },
                    new Country { Id = "585", Alpha2 = "pw", Alpha3 = "	plw", PhoneIso = "	680    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Palau", CreatedBy = "TOAA" },
                    new Country { Id = "275", Alpha2 = "ps", Alpha3 = "	pse", PhoneIso = "	970    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Palestine", CreatedBy = "TOAA" },
                    new Country { Id = "591", Alpha2 = "pa", Alpha3 = "	pan", PhoneIso = "	507    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Panama", CreatedBy = "TOAA" },
                    new Country { Id = "598", Alpha2 = "pg", Alpha3 = "	png", PhoneIso = "	675    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Papua New Guinea", CreatedBy = "TOAA" },
                    new Country { Id = "600", Alpha2 = "py", Alpha3 = "	pry", PhoneIso = "	595    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Paraguay", CreatedBy = "TOAA" },
                    new Country { Id = "604", Alpha2 = "pe", Alpha3 = "	per", PhoneIso = "	51     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Peru", CreatedBy = "TOAA" },
                    new Country { Id = "608", Alpha2 = "ph", Alpha3 = "	phl", PhoneIso = "	63     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Philippines", CreatedBy = "TOAA" },
                    new Country { Id = "612", Alpha2 = "pn", Alpha3 = "	pcn", PhoneIso = "	64     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Pitcairn", CreatedBy = "TOAA" },
                    new Country { Id = "616", Alpha2 = "pl", Alpha3 = "	pol", PhoneIso = "	48     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Poland", CreatedBy = "TOAA" },
                    new Country { Id = "620", Alpha2 = "pt", Alpha3 = "	prt", PhoneIso = "	351    ", CurrencyIso = "	EUR", EuMember = "N/A", CountryName_en = "Portugal", CreatedBy = "TOAA" },
                    new Country { Id = "630", Alpha2 = "pr", Alpha3 = "	pri", PhoneIso = "	1-787  ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Puerto Rico", CreatedBy = "TOAA" },
                    new Country { Id = "634", Alpha2 = "qa", Alpha3 = "	qat", PhoneIso = "	974    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Qatar", CreatedBy = "TOAA" },
                    new Country { Id = "638", Alpha2 = "re", Alpha3 = "	reu", PhoneIso = "	262    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Réunion	La Réunion", CreatedBy = "TOAA" },
                    new Country { Id = "642", Alpha2 = "ro", Alpha3 = "	rou", PhoneIso = "	40     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Romania	Roumanie", CreatedBy = "TOAA" },
                    new Country { Id = "643", Alpha2 = "ru", Alpha3 = "	rus", PhoneIso = "	7      ", CurrencyIso = "	RUB", EuMember = "N/A", CountryName_en = "Russian Federation", CreatedBy = "TOAA" },
                    new Country { Id = "646", Alpha2 = "rw", Alpha3 = "	rwa", PhoneIso = "	250    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Rwanda", CreatedBy = "TOAA" },
                    new Country { Id = "652", Alpha2 = "bl", Alpha3 = "	blm", PhoneIso = "	590    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Saint Barthélemy", CreatedBy = "TOAA" },
                    new Country { Id = "654", Alpha2 = "sh", Alpha3 = "	shn", PhoneIso = "	290    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Saint Helena, Ascension and Tristan da Cunha", CreatedBy = "TOAA" },
                    new Country { Id = "659", Alpha2 = "kn", Alpha3 = "	kna", PhoneIso = "	1-869  ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Saint Kitts and Nevis", CreatedBy = "TOAA" },
                    new Country { Id = "662", Alpha2 = "lc", Alpha3 = "	lca", PhoneIso = "	1-758  ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Saint Lucia	Sainte-Lucie", CreatedBy = "TOAA" },
                    new Country { Id = "663", Alpha2 = "mf", Alpha3 = "	maf", PhoneIso = "	590    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Saint Martin (French part)", CreatedBy = "TOAA" },
                    new Country { Id = "666", Alpha2 = "pm", Alpha3 = "	spm", PhoneIso = "	508    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Saint Pierre and Miquelon", CreatedBy = "TOAA" },
                    new Country { Id = "670", Alpha2 = "vc", Alpha3 = "	vct", PhoneIso = "	1-784  ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Saint Vincent and the Grenadines", CreatedBy = "TOAA" },
                    new Country { Id = "882", Alpha2 = "ws", Alpha3 = "	wsm", PhoneIso = "	685    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Samoa", CreatedBy = "TOAA" },
                    new Country { Id = "674", Alpha2 = "sm", Alpha3 = "	smr", PhoneIso = "	378    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "San Marino", CreatedBy = "TOAA" },
                    new Country { Id = "678", Alpha2 = "st", Alpha3 = "	stp", PhoneIso = "	239    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Sao Tome and Principe", CreatedBy = "TOAA" },
                    new Country { Id = "682", Alpha2 = "sa", Alpha3 = "	sau", PhoneIso = "	966    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Saudi Arabia", CreatedBy = "TOAA" },
                    new Country { Id = "686", Alpha2 = "sn", Alpha3 = "	sen", PhoneIso = "	221    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Senegal", CreatedBy = "TOAA" },
                    new Country { Id = "688", Alpha2 = "rs", Alpha3 = "	srb", PhoneIso = "	381    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Serbia", CreatedBy = "TOAA" },
                    new Country { Id = "690", Alpha2 = "sc", Alpha3 = "	syc", PhoneIso = "	248    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Seychelles", CreatedBy = "TOAA" },
                    new Country { Id = "694", Alpha2 = "sl", Alpha3 = "	sle", PhoneIso = "	232    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Sierra Leone", CreatedBy = "TOAA" },
                    new Country { Id = "702", Alpha2 = "sg", Alpha3 = "	sgp", PhoneIso = "	65     ", CurrencyIso = "	SGD", EuMember = "N/A", CountryName_en = "Singapore", CreatedBy = "TOAA" },
                    new Country { Id = "534", Alpha2 = "sx", Alpha3 = "	sxm", PhoneIso = "	1-721  ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Sint Maarten (Dutch part)", CreatedBy = "TOAA" },
                    new Country { Id = "703", Alpha2 = "sk", Alpha3 = "	svk", PhoneIso = "	421    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Slovakia", CreatedBy = "TOAA" },
                    new Country { Id = "705", Alpha2 = "si", Alpha3 = "	svn", PhoneIso = "	386    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Slovenia", CreatedBy = "TOAA" },
                    new Country { Id = "90 ", Alpha2 = "sb", Alpha3 = "	slb", PhoneIso = "	677    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Solomon Islands", CreatedBy = "TOAA" },
                    new Country { Id = "706", Alpha2 = "so", Alpha3 = "	som", PhoneIso = "	252    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Somalia", CreatedBy = "TOAA" },
                    new Country { Id = "710", Alpha2 = "za", Alpha3 = "	zaf", PhoneIso = "	27     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "South Africa", CreatedBy = "TOAA" },
                    new Country { Id = "239", Alpha2 = "gs", Alpha3 = "	sgs", PhoneIso = "	       ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "South Georgia and the South Sandwich Islands", CreatedBy = "TOAA" },
                    new Country { Id = "728", Alpha2 = "ss", Alpha3 = "	ssd", PhoneIso = "	211    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "South Sudan", CreatedBy = "TOAA" },
                    new Country { Id = "724", Alpha2 = "es", Alpha3 = "	esp", PhoneIso = "	34     ", CurrencyIso = "	EUR", EuMember = "N/A", CountryName_en = "Spain", CreatedBy = "TOAA" },
                    new Country { Id = "144", Alpha2 = "lk", Alpha3 = "	lka", PhoneIso = "	94     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Sri Lanka", CreatedBy = "TOAA" },
                    new Country { Id = "729", Alpha2 = "sd", Alpha3 = "	sdn", PhoneIso = "	249    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Sudan", CreatedBy = "TOAA" },
                    new Country { Id = "740", Alpha2 = "sr", Alpha3 = "	sur", PhoneIso = "	597    ", CurrencyIso = "	SRD", EuMember = "N/A", CountryName_en = "Suriname", CreatedBy = "TOAA" },
                    new Country { Id = "744", Alpha2 = "sj", Alpha3 = "	sjm", PhoneIso = "	47     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Svalbard and Jan Mayen", CreatedBy = "TOAA" },
                    new Country { Id = "748", Alpha2 = "sz", Alpha3 = "	swz", PhoneIso = "	268    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Swaziland", CreatedBy = "TOAA" },
                    new Country { Id = "752", Alpha2 = "se", Alpha3 = "	swe", PhoneIso = "	46     ", CurrencyIso = "	SEK", EuMember = "N/A", CountryName_en = "Sweden", CreatedBy = "TOAA" },
                    new Country { Id = "756", Alpha2 = "ch", Alpha3 = "	che", PhoneIso = "	41     ", CurrencyIso = "	CHF", EuMember = "N/A", CountryName_en = "Switzerland", CreatedBy = "TOAA" },
                    new Country { Id = "760", Alpha2 = "sy", Alpha3 = "	syr", PhoneIso = "	963    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Syrian Arab Republic", CreatedBy = "TOAA" },
                    new Country { Id = "158", Alpha2 = "tw", Alpha3 = "	twn", PhoneIso = "	886    ", CurrencyIso = "	NTD", EuMember = "N/A", CountryName_en = "Taiwan", CreatedBy = "TOAA" },
                    new Country { Id = "762", Alpha2 = "tj", Alpha3 = "	tjk", PhoneIso = "	992    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Tajikistan", CreatedBy = "TOAA" },
                    new Country { Id = "834", Alpha2 = "tz", Alpha3 = "	tza", PhoneIso = "	255    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Tanzania", CreatedBy = "TOAA" },
                    new Country { Id = "764", Alpha2 = "th", Alpha3 = "	tha", PhoneIso = "	66     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Thailand", CreatedBy = "TOAA" },
                    new Country { Id = "626", Alpha2 = "tl", Alpha3 = "	tls", PhoneIso = "	670    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "East Timor", CreatedBy = "TOAA" },
                    new Country { Id = "768", Alpha2 = "tg", Alpha3 = "	tgo", PhoneIso = "	228    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Togo", CreatedBy = "TOAA" },
                    new Country { Id = "772", Alpha2 = "tk", Alpha3 = "	tkl", PhoneIso = "	690    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Tokelau", CreatedBy = "TOAA" },
                    new Country { Id = "776", Alpha2 = "to", Alpha3 = "	ton", PhoneIso = "	676    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Tonga", CreatedBy = "TOAA" },
                    new Country { Id = "780", Alpha2 = "tt", Alpha3 = "	tto", PhoneIso = "	1-868  ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Trinidad and Tobago", CreatedBy = "TOAA" },
                    new Country { Id = "788", Alpha2 = "tn", Alpha3 = "	tun", PhoneIso = "	216    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Tunisia", CreatedBy = "TOAA" },
                    new Country { Id = "792", Alpha2 = "tr", Alpha3 = "	tur", PhoneIso = "	90     ", CurrencyIso = "	TRY", EuMember = "N/A", CountryName_en = "Turkey", CreatedBy = "TOAA" },
                    new Country { Id = "795", Alpha2 = "tm", Alpha3 = "	tkm", PhoneIso = "	993    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Turkmenistan", CreatedBy = "TOAA" },
                    new Country { Id = "796", Alpha2 = "tc", Alpha3 = "	tca", PhoneIso = "	1-649  ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Turks and Caicos Islands", CreatedBy = "TOAA" },
                    new Country { Id = "798", Alpha2 = "tv", Alpha3 = "	tuv", PhoneIso = "	688    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Tuvalu", CreatedBy = "TOAA" },
                    new Country { Id = "800", Alpha2 = "ug", Alpha3 = "	uga", PhoneIso = "	256    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Uganda", CreatedBy = "TOAA" },
                    new Country { Id = "804", Alpha2 = "ua", Alpha3 = "	ukr", PhoneIso = "	380    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Ukraine", CreatedBy = "TOAA" },
                    new Country { Id = "784", Alpha2 = "ae", Alpha3 = "	are", PhoneIso = "	971    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "United Arab Emirates", CreatedBy = "TOAA" },
                    new Country { Id = "826", Alpha2 = "gb", Alpha3 = "	gbr", PhoneIso = "	44     ", CurrencyIso = "	GBP", EuMember = "N/A", CountryName_en = "United Kingdom of Great Britain and Northern Ireland", CreatedBy = "TOAA" },
                    new Country { Id = "581", Alpha2 = "um", Alpha3 = "	umi", PhoneIso = "	       ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "United States Minor Outlying Islands", CreatedBy = "TOAA" },
                    new Country { Id = "840", Alpha2 = "us", Alpha3 = "	usa", PhoneIso = "	1      ", CurrencyIso = "	USD", EuMember = "N/A", CountryName_en = "United States of America", CreatedBy = "TOAA" },
                    new Country { Id = "858", Alpha2 = "uy", Alpha3 = "	ury", PhoneIso = "	598    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Uruguay", CreatedBy = "TOAA" },
                    new Country { Id = "860", Alpha2 = "uz", Alpha3 = "	uzb", PhoneIso = "	998    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Uzbekistan", CreatedBy = "TOAA" },
                    new Country { Id = "548", Alpha2 = "vu", Alpha3 = "	vut", PhoneIso = "	678    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Vanuatu", CreatedBy = "TOAA" },
                    new Country { Id = "862", Alpha2 = "ve", Alpha3 = "	ven", PhoneIso = "	379    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Venezuela", CreatedBy = "TOAA" },
                    new Country { Id = "704", Alpha2 = "vn", Alpha3 = "	vnm", PhoneIso = "	58     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Viet Nam", CreatedBy = "TOAA" },
                    new Country { Id = "92 ", Alpha2 = "vg", Alpha3 = "	vgb", PhoneIso = "	84     ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Virgin Islands (British)", CreatedBy = "TOAA" },
                    new Country { Id = "850", Alpha2 = "vi", Alpha3 = "	vir", PhoneIso = "	1-340  ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Virgin Islands (U.S.)", CreatedBy = "TOAA" },
                    new Country { Id = "876", Alpha2 = "wf", Alpha3 = "	wlf", PhoneIso = "	681    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Wallis and Futuna", CreatedBy = "TOAA" },
                    new Country { Id = "732", Alpha2 = "eh", Alpha3 = "	esh", PhoneIso = "	212    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Western Sahara", CreatedBy = "TOAA" },
                    new Country { Id = "887", Alpha2 = "ye", Alpha3 = "	yem", PhoneIso = "	967    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Yemen", CreatedBy = "TOAA" },
                    new Country { Id = "894", Alpha2 = "zm", Alpha3 = "	zmb", PhoneIso = "	260    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Zambia", CreatedBy = "TOAA" },
                    new Country { Id = "716", Alpha2 = "zw", Alpha3 = "	zwe", PhoneIso = "	263    ", CurrencyIso = "	   ", EuMember = "N/A", CountryName_en = "Zimbabwe", CreatedBy = "TOAA" }
                );
            }
        }

        public static async Task SeedContactIdTypes(ApplicationDbContext context)
        {
            if (!context.ContactIdTypes.Any())
            {
                await context.ContactIdTypes.AddRangeAsync(
                    new ContactIdType
                    {
                        Title = "Nederlands Paspoort",
                        CreatedBy = "TOAA"
                    },
                    new ContactIdType
                    {
                        Title = "Nederlandse Identiteitskaart",
                        CreatedBy = "TOAA"
                    },
                    new ContactIdType
                    {
                        Title = "Rijbewijs",
                        CreatedBy = "TOAA"
                    },
                    new ContactIdType
                    {
                        Title = "Toeristenkaart",
                        CreatedBy = "TOAA"
                    },
                    new ContactIdType
                    {
                        Title = "Diplomatiek/Dienst Paspoort",
                        CreatedBy = "TOAA"
                    },
                    new ContactIdType
                    {
                        Title = "Vreemdelingen Paspoort",
                        CreatedBy = "TOAA"
                    },
                    new ContactIdType
                    {
                        Title = "Vluchtelingen Paspoort",
                        CreatedBy = "TOAA"
                    },
                    new ContactIdType
                    {
                        Title = "EU/EER Paspoort",
                        CreatedBy = "TOAA"
                    },
                    new ContactIdType
                    {
                        Title = "Buitenlands Paspoort",
                        CreatedBy = "TOAA"
                    },
                    new ContactIdType
                    {
                        Title = "Vluchtelingen Paspoort",
                        CreatedBy = "TOAA"
                    },
                    new ContactIdType
                    {
                        Title = "Vreemdelingen W-Document",
                        CreatedBy = "TOAA"
                    },
                    new ContactIdType
                    {
                        Title = "Vreemdelingen W2-Document",
                        CreatedBy = "TOAA"
                    }
                );
            }
        }

        public static async Task SeedContactCivilStatuses(ApplicationDbContext context)
        {
            if (!context.ContactCivilStatuses.Any())
            {
                await context.ContactCivilStatuses.AddRangeAsync(
                    new ContactCivilStatus
                    {
                        Title = "Ongehuwd",
                        CreatedBy = "TOAA"
                    },
                    new ContactCivilStatus
                    {
                        Title = "Wettig Gehuwd",
                        CreatedBy = "TOAA"
                    },
                    new ContactCivilStatus
                    {
                        Title = "Geregistreerd Partnerschap",
                        CreatedBy = "TOAA"
                    },
                    new ContactCivilStatus
                    {
                        Title = "Verweduwd na wettig huwelijk",
                        CreatedBy = "TOAA"
                    },
                    new ContactCivilStatus
                    {
                        Title = "Verweduwd na partnerschap",
                        CreatedBy = "TOAA"
                    },
                    new ContactCivilStatus
                    {
                        Title = "Gescheiden na partnerschap",
                        CreatedBy = "TOAA"
                    },
                    new ContactCivilStatus
                    {
                        Title = "Gescheiden na wettig huwelijk",
                        CreatedBy = "TOAA"
                    }
                );
            }
        }

        public static async Task SeedEmployees(ApplicationDbContext context)
        {
            if (!context.Contacts.Any(x => x.IsOurEmployee && !x.IsOrganization))
            {
                await context.Contacts.AddRangeAsync(
                    new Contact
                    {
                        IsOurEmployee = true,
                        Surname = "Smit",
                        MiddleName = "",
                        Gender = "M",
                        GivenName = "Arjen",
                        Title = "De heer ",
                        Initials = "A. ",
                        DisplayName = "Arjen Smit employee",
                        CivilStatusId = 3,
                        Birthday = new DateTime(1980, 12, 20),
                        Address1AddressStreet = "Beurspoortje",
                        Address1AddressHouseNo = "174",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "8387 EX",
                        Address1AddressCity = "Westerveld",
                        Address1AddressStateOrProvince = "Drenthe",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Arjen Smit",
                        Telephone1TelephoneNumber = "06-99830049",
                        Profession = "Advocaat",
                        Email1DisplayName = "Arjen Smit",
                        Email1EmailAddress = "test.A.Smit@gmail.com",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = true,
                        Surname = "de Ruiter",
                        MiddleName = "",
                        Gender = "M",
                        GivenName = "Levi",
                        Title = "De heer ",
                        Initials = "L.",
                        DisplayName = "Levi de Ruiter employee",
                        CivilStatusId = 4,
                        Birthday = new DateTime(1922, 11, 26),
                        Address1AddressStreet = "Aalscholverweg",
                        Address1AddressHouseNo = "362",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "8305 MC",
                        Address1AddressCity = "Noordoostpolder",
                        Address1AddressStateOrProvince = "Flevoland",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Levi de Ruiter",
                        Telephone1TelephoneNumber = "06-99966807",
                        Profession = "Advocaat Partner",
                        Email1DisplayName = "Levi de Ruiter",
                        Email1EmailAddress = "test.L.deRuiter@totaldesk.nl",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = true,
                        Surname = "Koning",
                        MiddleName = "",
                        Gender = "M",
                        GivenName = "Cees",
                        Title = "De heer ",
                        Initials = "C.",
                        DisplayName = "Cees Koning employee",
                        CivilStatusId = 3,
                        Birthday = new DateTime(1968, 03, 27),
                        Address1AddressStreet = "Dam",
                        Address1AddressHouseNo = "128",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "9965 QW",
                        Address1AddressCity = "De Marne",
                        Address1AddressStateOrProvince = "Groningen",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Cees Koning",
                        Telephone1TelephoneNumber = "06-99170928",
                        Profession = "Administratiefmedewerker",
                        Email1DisplayName = "Cees Koning",
                        Email1EmailAddress = "test.C.Koning@hotmail.nl",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = true,
                        Surname = "van der Berg",
                        MiddleName = "",
                        Gender = "M",
                        GivenName = "Kevin",
                        Title = "De heer ",
                        Initials = "K.",
                        DisplayName = "Kevin van der Berg employee",
                        CivilStatusId = 3,
                        Birthday = new DateTime(2001, 05, 16),
                        Address1AddressStreet = "Haarlemmerplein",
                        Address1AddressHouseNo = "227",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "1476 EF",
                        Address1AddressCity = "Edam-Volendam",
                        Address1AddressStateOrProvince = "Noord-Holland",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Adcocaat Partner",
                        Telephone1TelephoneNumber = "06-99871731",
                        Profession = "Psychiater",
                        Email1DisplayName = "Kevin van der Berg",
                        Email1EmailAddress = "test.K.vanderBerg@gmail.com",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = true,
                        Surname = "Bosman",
                        MiddleName = "",
                        Gender = "M",
                        GivenName = "Luuk",
                        Title = "De heer ",
                        Initials = "L.",
                        DisplayName = "Luuk Bosman employee",
                        CivilStatusId = 2,
                        Birthday = new DateTime(1963, 06, 25),
                        Address1AddressStreet = "Galgenstraat",
                        Address1AddressHouseNo = "65",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "3356 VK",
                        Address1AddressCity = "Papendrecht",
                        Address1AddressStateOrProvince = "Zuid-Holland",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Luuk Bosman",
                        Telephone1TelephoneNumber = "06-99569595",
                        Profession = "Advocaat",
                        Email1DisplayName = "Luuk Bosman",
                        Email1EmailAddress = "test.L.Bosman@emaildomeinen",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = true,
                        Surname = "Driessen",
                        MiddleName = "",
                        Gender = "M",
                        GivenName = "Sam",
                        Title = "De heer ",
                        Initials = "S.",
                        DisplayName = "Sam Driessen employee",
                        CivilStatusId = 3,
                        Birthday = new DateTime(1971, 02, 21),
                        Address1AddressStreet = "Nieuwstraat ",
                        Address1AddressHouseNo = "94",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "3257 YP",
                        Address1AddressCity = "Goeree-Overflakkee",
                        Address1AddressStateOrProvince = "Zuid-Holland",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Sam Driessen",
                        Telephone1TelephoneNumber = "06-99813475",
                        Profession = "Advocaat",
                        Email1DisplayName = "Sam Driessen",
                        Email1EmailAddress = "test.S.Driessen@gmail.com",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = true,
                        Surname = "van Veen",
                        MiddleName = "",
                        Gender = "F",
                        GivenName = "Lisa",
                        Title = "Mevrouw ",
                        Initials = "L.",
                        DisplayName = "Lisa van Veen employee",
                        CivilStatusId = 3,
                        Birthday = new DateTime(1989, 07, 31),
                        Address1AddressStreet = "Adriaan Pauwstraat",
                        Address1AddressHouseNo = "169",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "5764 YY",
                        Address1AddressCity = "Gemert-Bakel",
                        Address1AddressStateOrProvince = "Noord-Brabant",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Lisa van Veen",
                        Telephone1TelephoneNumber = "06-99809211",
                        Profession = "Advocaat",
                        Email1DisplayName = "Lisa van Veen",
                        Email1EmailAddress = "test.L.vanVeen@glomos.nl",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = true,
                        Surname = "van de Wetering",
                        MiddleName = "",
                        Gender = "F",
                        GivenName = "Indy",
                        Title = "Mevrouw ",
                        Initials = "I.",
                        DisplayName = "Indy van de Wetering employee",
                        CivilStatusId = 7,
                        Birthday = new DateTime(1968, 2, 26),
                        Address1AddressStreet = "Damrak oneven",
                        Address1AddressHouseNo = "104",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "2861 XQ",
                        Address1AddressCity = "Krimpenerwaard",
                        Address1AddressStateOrProvince = "Zuid-Holland",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Indy van de Wetering",
                        Telephone1TelephoneNumber = "06-99142478",
                        Profession = "Secretaresse",
                        Email1DisplayName = "Indy van de Wetering",
                        Email1EmailAddress = "test.I.vandeWetering@hotmail.nl",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = true,
                        Surname = "van der Velde",
                        MiddleName = "",
                        Gender = "F",
                        GivenName = "Ilse",
                        Title = "Mevrouw ",
                        Initials = "I.",
                        DisplayName = "Ilse van der Velde employee",
                        CivilStatusId = 3,
                        Birthday = new DateTime(1997, 2, 25),
                        Address1AddressStreet = "Schoterweg",
                        Address1AddressHouseNo = "229",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "7949 YN",
                        Address1AddressCity = "Meppel",
                        Address1AddressStateOrProvince = "Drenthe",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Ilse van der Velde",
                        Telephone1TelephoneNumber = "06-99226127",
                        Profession = "Secretaresse",
                        Email1DisplayName = "Ilse van der Velde",
                        Email1EmailAddress = "test.I.vanderVelde@hotmail.com",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = true,
                        Surname = "van der Veen",
                        MiddleName = "",
                        Gender = "F",
                        GivenName = "Sterre",
                        Title = "Mevrouw ",
                        Initials = "S.",
                        DisplayName = "Sterre van der Veen employee",
                        CivilStatusId = 3,
                        Birthday = new DateTime(1997, 3, 5),
                        Address1AddressStreet = "Dollebegijnensteeg",
                        Address1AddressHouseNo = "95",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "4707 PS",
                        Address1AddressCity = "Roosendaal",
                        Address1AddressStateOrProvince = "Noord-Brabant",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Sterre van der Veen",
                        Telephone1TelephoneNumber = " 06-99825596",
                        Profession = " Kapper",
                        Email1DisplayName = "Sterre van der Veen",
                        Email1EmailAddress = "test.S.vanderVeen@totaldesk.nl",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = true,
                        Surname = "Peters",
                        MiddleName = "",
                        Gender = "M",
                        GivenName = "Jelle",
                        Title = "De heer ",
                        Initials = "J.",
                        DisplayName = "Jelle Peters employee",
                        CivilStatusId = 3,
                        Birthday = new DateTime(1950, 6, 1),
                        Address1AddressStreet = "Haarlemmerdijk",
                        Address1AddressHouseNo = "270",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "9241 BW",
                        Address1AddressCity = "Opsterland",
                        Address1AddressStateOrProvince = "Friesland",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Jelle Peters",
                        Telephone1TelephoneNumber = "06-99944060",
                        Profession = "Projectmanager",
                        Email1DisplayName = "Jelle Peters",
                        Email1EmailAddress = "test.J.Peters@totaldesk.nl",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = true,
                        Surname = "Elzinga",
                        MiddleName = "",
                        Gender = "F",
                        GivenName = "Elisabeth",
                        Title = "Mevrouw ",
                        Initials = "E.",
                        DisplayName = "Elisabeth Elzinga employee",
                        Birthday = new DateTime(1997, 3, 9),
                        Address1AddressStreet = "Beursstraat",
                        Address1AddressHouseNo = "298",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "7217 ZN",
                        Address1AddressCity = "Lochem",
                        Address1AddressStateOrProvince = "Gelderland",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Elisabeth Elzinga",
                        Telephone1TelephoneNumber = "06-99864860",
                        Profession = "Stewardes",
                        Email1DisplayName = "Elisabeth Elzinga",
                        Email1EmailAddress = "test.E.Elzinga@gmail.com",
                        CreatedBy = "TOAA"
                    }
                );
            }
        }

        public static async Task SeedPersons(ApplicationDbContext context)
        {
            if (!context.Contacts.Any(x => !x.IsOurEmployee && !x.IsOrganization))
            {
                await context.Contacts.AddRangeAsync(
                    new Contact
                    {
                        IsOurEmployee = false,
                        Surname = "van Dam",
                        MiddleName = "",
                        Gender = "F",
                        GivenName = "Elisabeth",
                        Title = "Mevrouw",
                        Initials = "E.",
                        DisplayName = "Elisabeth van Dam",
                        CivilStatusId = 2,
                        Birthday = new DateTime(1963, 11, 27),
                        Address1AddressStreet = "Herenweg",
                        Address1AddressHouseNo = "195",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "7475 VV",
                        Address1AddressCity = "Hof van Twente",
                        Address1AddressStateOrProvince = "Overijssel",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Elisabeth van Dam",
                        Telephone1TelephoneNumber = "06-992524",
                        Profession = "Therapeut",
                        Email1DisplayName = "Elisabeth van Dam",
                        Email1EmailAddress = "test.E.vanDam@totaldesk.nl",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = false,
                        Surname = "Huisman",
                        MiddleName = "",
                        Gender = "F",
                        GivenName = "Isa",
                        Title = "Mevrouw",
                        Initials = "I.",
                        DisplayName = "Isa Huisman",
                        CivilStatusId = 7,
                        Birthday = new DateTime(1988, 06, 19),
                        Address1AddressStreet = "Houtmankade",
                        Address1AddressHouseNo = "118",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "6231 CU",
                        Address1AddressCity = "Meerssen",
                        Address1AddressStateOrProvince = "Limburg",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Isa Huisman",
                        Telephone1TelephoneNumber = "06-99804254",
                        Profession = "Inspecteur",
                        Email1DisplayName = "Isa Huisman",
                        Email1EmailAddress = "test.I.Huisman@totaldesk.nl",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = false,
                        Surname = "Smit",
                        MiddleName = "",
                        Gender = "M",
                        GivenName = "Luuk",
                        Title = "De heer ",
                        Initials = "L.",
                        DisplayName = "Luuk Smit",
                        CivilStatusId = 3,
                        Birthday = new DateTime(1934, 12, 24),
                        Address1AddressStreet = "Bloedstraat",
                        Address1AddressHouseNo = "141",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "5469 CS",
                        Address1AddressCity = "Meierijstad",
                        Address1AddressStateOrProvince = "Noord-Brabant",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Luuk Smit",
                        Telephone1TelephoneNumber = "06-99857038",
                        Profession = "Arbeider Bouw",
                        Email1DisplayName = "Luuk Smit",
                        Email1EmailAddress = "test.L.Smit@gmail.com",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = false,
                        Surname = "Driessen",
                        MiddleName = "",
                        Gender = "F",
                        GivenName = "Tessa",
                        Title = "Mevrouw",
                        Initials = "T.",
                        DisplayName = "Tessa Driessen",
                        CivilStatusId = 3,
                        Birthday = new DateTime(1998, 02, 04),
                        Address1AddressStreet = "Kiel",
                        Address1AddressHouseNo = "150",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "6595 TC",
                        Address1AddressCity = "Gennep",
                        Address1AddressStateOrProvince = "Limburg",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Tessa Driessen",
                        Telephone1TelephoneNumber = "06-99124691",
                        Profession = "Inspecteur",
                        Email1DisplayName = "Tessa Driessen",
                        Email1EmailAddress = "test.T.Driessen@emaildomeinen",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = false,
                        Surname = "Wolters",
                        MiddleName = "",
                        Gender = "F",
                        GivenName = "Anna",
                        Title = "Mevrouw",
                        Initials = "A.",
                        DisplayName = "Anna Wolters",
                        CivilStatusId = 3,
                        Birthday = new DateTime(1968, 07, 03),
                        Address1AddressStreet = "Bloedstraat",
                        Address1AddressHouseNo = "105",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "8141 FG",
                        Address1AddressCity = "Raalte",
                        Address1AddressStateOrProvince = "Overijssel",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Anna Wolters",
                        Telephone1TelephoneNumber = "06-99952012",
                        Profession = "Huisarts",
                        Email1DisplayName = "Anna Wolters",
                        Email1EmailAddress = "test.A.Wolters@hotmail.nl",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = false,
                        Surname = "van der Wal",
                        MiddleName = "",
                        Gender = "M",
                        GivenName = "Lucas",
                        Title = "De heer ",
                        Initials = "L.",
                        DisplayName = "Lucas van der Wal",
                        CivilStatusId = 2,
                        Birthday = new DateTime(2005, 10, 25),
                        Address1AddressStreet = "Lijsterbes",
                        Address1AddressHouseNo = "239",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "5492 YE",
                        Address1AddressCity = "Meierijstad",
                        Address1AddressStateOrProvince = "Noord-Brabant",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Lucas van der Wal",
                        Telephone1TelephoneNumber = "06-9938484",
                        Profession = "Dierenarts",
                        Email1DisplayName = "Lucas van der Wal",
                        Email1EmailAddress = "test.L.vanderWal@emaildomeinen",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = false,
                        Surname = "Willems",
                        MiddleName = "",
                        Gender = "F",
                        GivenName = "Amber",
                        Title = "Mevrouw",
                        Initials = "A.",
                        DisplayName = "Amber Willems",
                        CivilStatusId = 2,
                        Birthday = new DateTime(1951, 04, 18),
                        Address1AddressStreet = "Bloedstraat",
                        Address1AddressHouseNo = "219",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "5513 LC",
                        Address1AddressCity = "Eersel",
                        Address1AddressStateOrProvince = "Noord-Brabant",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Amber Willems",
                        Telephone1TelephoneNumber = "06-99746503",
                        Profession = "Personal Assistant",
                        Email1DisplayName = "Amber Willems",
                        Email1EmailAddress = "test.A.Willems@emaildomeinen",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = false,
                        Surname = "Willems",
                        MiddleName = "",
                        Gender = "F",
                        GivenName = "Anne",
                        Title = "Mevrouw",
                        Initials = "A.",
                        DisplayName = "Anne Willems",
                        CivilStatusId = 3,
                        Birthday = new DateTime(1946, 01, 12),
                        Address1AddressStreet = "Eksterweg",
                        Address1AddressHouseNo = "162",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "6005 DE",
                        Address1AddressCity = "Weert",
                        Address1AddressStateOrProvince = "Limburg",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Anne Willems",
                        Telephone1TelephoneNumber = "06-99462845",
                        Profession = "Rechter",
                        Email1DisplayName = "Anne Willems",
                        Email1EmailAddress = "test.A.Willems@hotmail.nl",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = false,
                        Surname = "van de Pol",
                        MiddleName = "",
                        Gender = "F",
                        GivenName = "Maureen",
                        Title = "Mevrouw",
                        Initials = "M.",
                        DisplayName = "Maureen van de Pol",
                        CivilStatusId = 3,
                        Birthday = new DateTime(2007, 05, 04),
                        Address1AddressStreet = "Eksterweg",
                        Address1AddressHouseNo = "18",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "6286 JR",
                        Address1AddressCity = "Gulpen-Wittem",
                        Address1AddressStateOrProvince = "Limburg",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Maureen van de Pol",
                        Telephone1TelephoneNumber = "06-99548432",
                        Profession = "Baliemedewerker",
                        Email1DisplayName = "Maureen van de Pol",
                        Email1EmailAddress = "test.M.vandePol@totaldesk.nl",
                        CreatedBy = "TOAA"
                    },
                    new Contact
                    {
                        IsOurEmployee = false,
                        Surname = "Schuitemaker",
                        MiddleName = "",
                        Gender = "M",
                        GivenName = "Robin",
                        Title = "De heer ",
                        Initials = "R.",
                        DisplayName = "Robin Schuitemaker",
                        CivilStatusId = 2,
                        Birthday = new DateTime(1922, 12, 11),
                        Address1AddressStreet = "Kastanjelaan",
                        Address1AddressHouseNo = "118",
                        Address1AddressHouseNoExt = "",
                        Address1AddressLine2 = "",
                        Address1AddressPostalCode = "9162 YQ",
                        Address1AddressCity = "Ameland",
                        Address1AddressStateOrProvince = "Friesland",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Telephone1DisplayName = "Robin Schuitemaker",
                        Telephone1TelephoneNumber = "06-9980558",
                        Profession = "Clientadviseur",
                        Email1DisplayName = "Robin Schuitemaker",
                        Email1EmailAddress = "test.R.Schuitemaker@hotmail.com",
                        CreatedBy = "TOAA"
                    });
            }
        }

        public static async Task SeedCompanies(ApplicationDbContext context)
        {
            if (!context.Contacts.Any(x => x.IsOrganization))
            {
                await context.Contacts.AddRangeAsync(
                    new Contact
                    {
                        IsOrganization = true,
                        DisplayName = "Advocaten kantoor Bloem en Boter",
                        Email1EmailAddress = "info@bloemenboter.nl",
                        Language = "NL",
                        Address1AddressStateOrProvince = "NH",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        CompanyLegalStatusId = 1,
                        CreatedBy = "TOAA"
                    });
            }

            if (!context.Contacts.Any(x => x.IsOrganization && x.IsOurEmployee))
            {
                await context.Contacts.AddRangeAsync(
                    new Contact
                    {
                        IsOrganization = true,
                        IsOurEmployee = true,
                        Surname = "Bastiaan",
                        MiddleName = "De",
                        Gender = "M",
                        GivenName = "Jonge",
                        DisplayName = "Bastiaan Jonge",
                        Email1EmailAddress = "bastiaan@advosecure.nl",
                        Telephone1TelephoneNumber = "06-12345678",
                        Telephone2TelephoneNumber = "0614154578",
                        CompanyName = "Bastiaan Holding B.V.",
                        Profession = "aartsbisschop",
                        Title = "Zijne Hoogwaardige Excellentie Mgr.",
                        Saluation = "Monseigneur",
                        Address1AddressCountryCode = "nld",
                        Address1AddressCountry = "Nederland",
                        Address2AddressCountryCode = "nld",
                        Address2AddressCountry = "Nederland",
                        CompanyLegalStatusId = 1,
                        BillingRateId = 1,
                        CreatedBy = "TOAA"
                    });
            }
        }

        public static async Task SeedMatterType(ApplicationDbContext context)
        {
            if (!context.MatterTypes.Any())
            {
                await context.MatterTypes.AddRangeAsync(
                    new MatterType
                    {
                        Title = "Kinderalimentatie",
                        CreatedBy = "TOAA"
                    },
                    new MatterType
                    {
                        Title = "Partneralimentatie",
                        CreatedBy = "TOAA"
                    },
                    new MatterType
                    {
                        Title = "Insolventie",
                        CreatedBy = "TOAA"
                    },
                    new MatterType
                    {
                        Title = "Naturalisatie",
                        CreatedBy = "TOAA"
                    },
                    new MatterType
                    {
                        Title = "Arbeidsconflict",
                        CreatedBy = "TOAA"
                    },
                    new MatterType
                    {
                        Title = "Strafrecht",
                        CreatedBy = "TOAA"
                    },
                    new MatterType
                    {
                        Title = "Onroerende Zaken Zakelijk recht",
                        CreatedBy = "TOAA"
                    },
                    new MatterType
                    {
                        Title = "Echtscheidinkk",
                        CreatedBy = "TOAA"
                    }
                );
            }
        }

        public static async Task SeedTaskType(ApplicationDbContext context)
        {
            if (!context.TaskTypes.Any())
            {
                await context.TaskTypes.AddRangeAsync(
                    new Domain.Entities.Tasks.TaskType {
                        Title = "Task",
                        Icon = "fa-check",
                        Group = "",
                        CreatedBy = "TOAA"
                    },
                    new Domain.Entities.Tasks.TaskType
                    {
                        Title = "Meeting/Appointment in Office",
                        Icon = "fa-building",
                        Group = "",
                        CreatedBy = "TOAA"
                    },
                    new Domain.Entities.Tasks.TaskType
                    {
                        Title = "Meeting/Appointment out of Office",
                        Icon = "fa-image",
                        Group = "",
                        CreatedBy = "TOAA"
                    },
                    new Domain.Entities.Tasks.TaskType
                    {
                        Title = "Meeting in Court",
                        Icon = "fa-hospital-o",
                        Group = "",
                        CreatedBy = "TOAA"
                    },
                    new Domain.Entities.Tasks.TaskType
                    {
                        Title = "Traveltime",
                        Icon = "fa-cab",
                        Group = "",
                        CreatedBy = "TOAA"
                    },
                    new Domain.Entities.Tasks.TaskType
                    {
                        Title = "Phonecall",
                        Icon = "fa-phone",
                        Group = "",
                        CreatedBy = "TOAA"
                    },
                    new Domain.Entities.Tasks.TaskType
                    {
                        Title = "Email",
                        Icon = "fa-envelope",
                        Group = "",
                        CreatedBy = "TOAA"
                    },
                    new Domain.Entities.Tasks.TaskType
                    {
                        Title = "Inlezen",
                        Icon = "fa-folder-open",
                        Group = "",
                        CreatedBy = "TOAA"
                    },
                    new Domain.Entities.Tasks.TaskType
                    {
                        Title = "Administratie",
                        Icon = "fa-euro",
                        Group = "",
                        CreatedBy = "TOAA"
                    },
                    new Domain.Entities.Tasks.TaskType
                    {
                         Title = "Research/Studie",
                         Icon = "fa-mortar-board",
                         Group = "",
                        CreatedBy = "TOAA"
                    },
                    new Domain.Entities.Tasks.TaskType
                    {
                          Title = "Afspraak maken",
                          Icon = "fa-calendar",
                          Group = "",
                          CreatedBy = "TOAA"
                    });
            }
        }
        
        public static async Task SeedLanguages(ApplicationDbContext context)
        {
            if (!context.Languages.Any())
            {
                await context.Languages.AddRangeAsync(
                    new Language
                    {
                        Alpha2 = "aa",
                        Alpha3 = "aar",
                        Title = "Afar",
                        TitleNl = "",
                        CreatedBy = "TOAA"
                    },
                    new Language
                    {
                        Alpha2 = "ab",
                        Alpha3 = "abk",
                        Title = "Abkhazian",
                        TitleNl = "",
                        CreatedBy = "TOAA"

                    },
                    new Language
                    {
                        Alpha2 = "af",
                        Alpha3 = "afr",
                        Title = "Afrikaans",
                        TitleNl = "",
                        CreatedBy = "TOAA"

                    },
                    new Language
                    {
                        Alpha2 = "ak",
                        Alpha3 = "aka",
                        Title = "Akan",
                        TitleNl = "",
                        CreatedBy = "TOAA"
                    },
                    new Language { Alpha3 = "alb", Alpha2 = "sq", Title = "Albanian", TitleNl = "Albaans", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "amh", Alpha2 = "am", Title = "Amharic", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ara", Alpha2 = "ar", Title = "Arabic", TitleNl = "Arabisch", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "arg", Alpha2 = "an", Title = "Aragonese", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "arm", Alpha2 = "hy", Title = "Armenian", TitleNl = "Armeens", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "asm", Alpha2 = "as", Title = "Assamese", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ava", Alpha2 = "av", Title = "Avaric", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ave", Alpha2 = "ae", Title = "Avestan", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "aym", Alpha2 = "ay", Title = "Aymara", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "aze", Alpha2 = "az", Title = "Azerbaijani", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "bak", Alpha2 = "ba", Title = "Bashkir", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "bam", Alpha2 = "bm", Title = "Bambara", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "baq", Alpha2 = "eu", Title = "Basque", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "bel", Alpha2 = "be", Title = "Belarusian", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ben", Alpha2 = "bn", Title = "Bengali", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "bih", Alpha2 = "bh", Title = "Bihari languages", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "bis", Alpha2 = "bi", Title = "Bislama", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "bos", Alpha2 = "bs", Title = "Bosnian", TitleNl = "Bosnisch", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "bre", Alpha2 = "br", Title = "Breton", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "bul", Alpha2 = "bg", Title = "Bulgarian", TitleNl = "Bulgaars", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "bur", Alpha2 = "my", Title = "Burmese", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "cat", Alpha2 = "ca", Title = "Catalan", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "cha", Alpha2 = "ch", Title = "Chamorro", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "che", Alpha2 = "ce", Title = "Chechen", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "chi", Alpha2 = "zh", Title = "Chinese", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "chu", Alpha2 = "cu", Title = "Church Slavic", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "chv", Alpha2 = "cv", Title = "Chuvash", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "cor", Alpha2 = "kw", Title = "Cornish", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "cos", Alpha2 = "co", Title = "Corsican", TitleNl = "Corsicaans", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "cre", Alpha2 = "cr", Title = "Cree", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "cze", Alpha2 = "cs", Title = "Czech", TitleNl = "Tzechisch", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "dan", Alpha2 = "da", Title = "Danish", TitleNl = "Deens", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "div", Alpha2 = "dv", Title = "Divehi", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "dut", Alpha2 = "nl", Title = "Dutch", TitleNl = "Nederlands", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "dzo", Alpha2 = "dz", Title = "Dzongkha", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "eng", Alpha2 = "en", Title = "English", TitleNl = "Engels", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "epo", Alpha2 = "eo", Title = "Esperanto", TitleNl = "Esperanto", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "est", Alpha2 = "et", Title = "Estonian", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ewe", Alpha2 = "ee", Title = "Ewe", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "fao", Alpha2 = "fo", Title = "Faroese", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "fij", Alpha2 = "fj", Title = "Fijian", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "fin", Alpha2 = "fi", Title = "Finnish", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "fre", Alpha2 = "fr", Title = "French", TitleNl = "Frans", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "fry", Alpha2 = "fy", Title = "Western Frisian", TitleNl = "Friesch", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "bre", Alpha2 = "br", Title = "Breton", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ful", Alpha2 = "ff", Title = "Fulah", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "geo", Alpha2 = "ka", Title = "Georgian", TitleNl = "Georgisch", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ger", Alpha2 = "de", Title = "German", TitleNl = "Duits", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "gla", Alpha2 = "gd", Title = "Gaelic", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "gle", Alpha2 = "ga", Title = "Irish", TitleNl = "Iers", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "glg", Alpha2 = "gl", Title = "Galician", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "glv", Alpha2 = "gv", Title = "Manx", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "gre", Alpha2 = "el", Title = "Greek", TitleNl = "Grieks", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "grn", Alpha2 = "gn", Title = "Guarani", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "guj", Alpha2 = "gu", Title = "Gujarati", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "hat", Alpha2 = "ht", Title = "Haitian", TitleNl = "Haïtiaans", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "hau", Alpha2 = "ha", Title = "Hausa", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "heb", Alpha2 = "he", Title = "Hebrew", TitleNl = "Hebreeuws", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "her", Alpha2 = "hz", Title = "Herero", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "hin", Alpha2 = "hi", Title = "Hindi", TitleNl = "Hindi", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "hmo", Alpha2 = "ho", Title = "Hiri Motu", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "hrv", Alpha2 = "hr", Title = "Croatian", TitleNl = "Kroatisch", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "hun", Alpha2 = "hu", Title = "Hungarian", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ibo", Alpha2 = "ig", Title = "Igbo", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "bre", Alpha2 = "br", Title = "Breton", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ice", Alpha2 = "is", Title = "Icelandic", TitleNl = "Ijslands", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ido", Alpha2 = "io", Title = "Ido", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "iii", Alpha2 = "ii", Title = "Sichuan Yi", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "iku", Alpha2 = "iu", Title = "Inuktitut", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ile", Alpha2 = "ie", Title = "Interlingue", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ina", Alpha2 = "ia", Title = "Interlingua (International Auxiliary Language Association);", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ind", Alpha2 = "id", Title = "Indonesian", TitleNl = "Indonesisch", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ipk", Alpha2 = "ik", Title = "Inupiaq", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ita", Alpha2 = "it", Title = "Italian", TitleNl = "Italiaans", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "jav", Alpha2 = "jv", Title = "Javanese", TitleNl = "Javaans", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "jpn", Alpha2 = "ja", Title = "Japanese", TitleNl = "Japans", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "kal", Alpha2 = "kl", Title = "Kalaallisut", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "kan", Alpha2 = "kn", Title = "Kannada", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "kas", Alpha2 = "ks", Title = "Kashmiri", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "kau", Alpha2 = "kr", Title = "Kanuri", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "kaz", Alpha2 = "kk", Title = "Kazakh", TitleNl = "Kazachs", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "khm", Alpha2 = "km", Title = "Central Khmer", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "kik", Alpha2 = "ki", Title = "Kikuyu", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "kin", Alpha2 = "rw", Title = "Kinyarwanda", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "kir", Alpha2 = "ky", Title = "Kirghiz", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "kom", Alpha2 = "kv", Title = "Komi", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "kon", Alpha2 = "kg", Title = "Kongo", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "kor", Alpha2 = "ko", Title = "Korean", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "kua", Alpha2 = "kj", Title = "Kuanyama", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "kur", Alpha2 = "ku", Title = "Kurdish", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "lao", Alpha2 = "lo", Title = "Lao", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "lat", Alpha2 = "la", Title = "Latin", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "lav", Alpha2 = "lv", Title = "Latvian", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "lim", Alpha2 = "li", Title = "Limburgan", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "lin", Alpha2 = "ln", Title = "Lingala", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "lit", Alpha2 = "lt", Title = "Lithuanian", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ltz", Alpha2 = "lb", Title = "Luxembourgish", TitleNl = "Luxemburgs", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "lub", Alpha2 = "lu", Title = "Luba-Katanga", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "lug", Alpha2 = "lg", Title = "Ganda", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "mac", Alpha2 = "mk", Title = "Macedonian", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "mah", Alpha2 = "mh", Title = "Marshallese", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "mal", Alpha2 = "ml", Title = "Malayalam", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "mao", Alpha2 = "mi", Title = "Maori", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "mar", Alpha2 = "mr", Title = "Marathi", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "may", Alpha2 = "ms", Title = "Malay", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "mlg", Alpha2 = "mg", Title = "Malagasy", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "mlt", Alpha2 = "mt", Title = "Maltese", TitleNl = "Maltees", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "mon", Alpha2 = "mn", Title = "Mongolian", TitleNl = "Mongools", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "nau", Alpha2 = "na", Title = "Nauru", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "nav", Alpha2 = "nv", Title = "Navajo", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "nbl", Alpha2 = "nr", Title = "Ndebele - South", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "nde", Alpha2 = "nd", Title = "Ndebele - North", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ndo", Alpha2 = "ng", Title = "Ndonga", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "nep", Alpha2 = "ne", Title = "Nepali", TitleNl = "Nepalees", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "nno", Alpha2 = "nn", Title = "Norwegian Nynorsk", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "nob", Alpha2 = "nb", Title = "Bokmål", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "nor", Alpha2 = "no", Title = "Norwegian", TitleNl = "Noors", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "nya", Alpha2 = "ny", Title = "Chichewa", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "oci", Alpha2 = "oc", Title = "Occitan (post 1500)", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "oji", Alpha2 = "oj", Title = "Ojibwa", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ori", Alpha2 = "or", Title = "Oriya", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "orm", Alpha2 = "om", Title = "Oromo", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "bre", Alpha2 = "br", Title = "Breton", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "oss", Alpha2 = "os", Title = "Ossetian", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "pan", Alpha2 = "pa", Title = "Panjabi", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "per", Alpha2 = "fa", Title = "Persian", TitleNl = "Farsi", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "pli", Alpha2 = "pi", Title = "Pali", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "pol", Alpha2 = "pl", Title = "Polish", TitleNl = "Pools", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "por", Alpha2 = "pt", Title = "Portuguese", TitleNl = "Portugees", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "pus", Alpha2 = "ps", Title = "Pushto", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "que", Alpha2 = "qu", Title = "Quechua", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "roh", Alpha2 = "rm", Title = "Romansh", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "rum", Alpha2 = "ro", Title = "Romanian", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "run", Alpha2 = "rn", Title = "Rundi", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "rus", Alpha2 = "ru", Title = "Russian", TitleNl = "Russisch", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "sag", Alpha2 = "sg", Title = "Sango", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "san", Alpha2 = "sa", Title = "Sanskrit", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "sin", Alpha2 = "si", Title = "Sinhala", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "slo", Alpha2 = "sk", Title = "Slovak", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "slv", Alpha2 = "sl", Title = "Slovenian", TitleNl = "Sloveens", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "sme", Alpha2 = "se", Title = "Northern Sami", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "smo", Alpha2 = "sm", Title = "Samoan", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "sna", Alpha2 = "sn", Title = "Shona", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "snd", Alpha2 = "sd", Title = "Sindhi", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "som", Alpha2 = "so", Title = "Somali", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "sot", Alpha2 = "st", Title = "Sotho - Southern", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "spa", Alpha2 = "es", Title = "Spanish", TitleNl = "Spaans", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "srd", Alpha2 = "sc", Title = "Sardinian", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "srp", Alpha2 = "sr", Title = "Serbian", TitleNl = "Servisch", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ssw", Alpha2 = "ss", Title = "Swati", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "sun", Alpha2 = "su", Title = "Sundanese", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "bre", Alpha2 = "br", Title = "Breton", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "swa", Alpha2 = "sw", Title = "Swahili", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "swe", Alpha2 = "sv", Title = "Swedish", TitleNl = "Zweeds", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "tah", Alpha2 = "ty", Title = "Tahitian", TitleNl = "Tahitiaans", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "tam", Alpha2 = "ta", Title = "Tamil", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "tat", Alpha2 = "tt", Title = "Tatar", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "tel", Alpha2 = "te", Title = "Telugu", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "tgk", Alpha2 = "tg", Title = "Tajik", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "tgl", Alpha2 = "tl", Title = "Tagalog", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "tha", Alpha2 = "th", Title = "Thai", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "tib", Alpha2 = "bo", Title = "Tibetan", TitleNl = "Tibetaans", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "tir", Alpha2 = "ti", Title = "Tigrinya", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ton", Alpha2 = "to", Title = "Tonga (Tonga Islands)", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "tsn", Alpha2 = "tn", Title = "Tswana", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "tso", Alpha2 = "ts", Title = "Tsonga", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "tuk", Alpha2 = "tk", Title = "Turkmen", TitleNl = "Turkmeens", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "tur", Alpha2 = "tr", Title = "Turkish", TitleNl = "Turks", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "twi", Alpha2 = "tw", Title = "Twi", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "uig", Alpha2 = "ug", Title = "Uighur", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ukr", Alpha2 = "uk", Title = "Ukrainian", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "urd", Alpha2 = "ur", Title = "Urdu", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "uzb", Alpha2 = "uz", Title = "Uzbek", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "ven", Alpha2 = "ve", Title = "Venda", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "vie", Alpha2 = "vi", Title = "Vietnamese", TitleNl = "Vietnamees", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "vol", Alpha2 = "vo", Title = "Volapük", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "wel", Alpha2 = "cy", Title = "Welsh", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "wln", Alpha2 = "wa", Title = "Walloon", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "wol", Alpha2 = "wo", Title = "Wolof", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "xho", Alpha2 = "xh", Title = "Xhosa", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "yid", Alpha2 = "yi", Title = "Yiddish", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "yor", Alpha2 = "yo", Title = "Yoruba", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "zha", Alpha2 = "za", Title = "Zhuang", TitleNl = "", CreatedBy = "TOAA" },
                    new Language { Alpha3 = "zul", Alpha2 = "zu", Title = "Zulu", TitleNl = "", CreatedBy = "TOAA" }
                    );
            }
        }
        
        public static async Task SeedMatterAreas(ApplicationDbContext context)
        {
            if (!context.MatterAreas.Any())
            {
                await context.MatterAreas.AddRangeAsync(
                    new MatterArea
                    {
                        AreaGroup = 1,
                        AreaCode = "1",
                        Title = "Onbekend of nvt",
                        CreatedBy = "TOAA"
                    },
                    new MatterArea { AreaGroup = 1, AreaCode = "1", Title = "Onbekend of nvt", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 1, AreaCode = "1", Title = "Algemene praktijk", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 1, AreaCode = "1a", Title = "Burgerlijk recht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 1, AreaCode = "1b", Title = "Strafrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 1, AreaCode = "1c", Title = "Bestuursrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 2, AreaCode = "2", Title = "Personen- en Familierecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 2, AreaCode = "2a", Title = "Echtscheidingen, alimentatiezaken, omgangsregelingen", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 2, AreaCode = "2b", Title = "Ouderschap en erkenning", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 2, AreaCode = "2c", Title = "Collaborative divorce", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 2, AreaCode = "2d", Title = "Mediation", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 2, AreaCode = "2e", Title = "Jeugdbeschermingsrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 2, AreaCode = "2f", Title = "Bijzondere curator", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 2, AreaCode = "2g", Title = "Internationale kinderontvoering", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 2, AreaCode = "2h", Title = "Internationaal privaatrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 3, AreaCode = "3", Title = "Erfrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 4, AreaCode = "4", Title = "Arbeidsrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 4, AreaCode = "4a", Title = "Medezeggenschap", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 4, AreaCode = "4b", Title = "Collectief ontslag", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 4, AreaCode = "4c", Title = "Pensioenen", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 4, AreaCode = "4d", Title = "Arbeidsmediation", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 4, AreaCode = "4e", Title = "Internationaal arbeidsrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 5, AreaCode = "5", Title = "Sociaal-zekerheidsrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 5, AreaCode = "5a", Title = "Werknemersverzekeringen", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 5, AreaCode = "5b", Title = "Volksverzekeringen", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 5, AreaCode = "5c", Title = "Sociale voorzieningen", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 5, AreaCode = "5d", Title = "Internationaal (arbeids)recht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 6, AreaCode = "6", Title = "Ambtenarenrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 6, AreaCode = "6a", Title = "Militairen", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 7, AreaCode = "7", Title = "Huurrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 7, AreaCode = "7a", Title = "Woonruimte", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 7, AreaCode = "7b", Title = "Bedrijfsruimte", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 8, AreaCode = "8", Title = "Verbintenissenrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 9, AreaCode = "9", Title = "Sportrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 10, AreaCode = "10", Title = "Intellectueel eigendomsrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 11, AreaCode = "11", Title = "Mededingingsrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 12, AreaCode = "12", Title = "Aanbestedingsrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 13, AreaCode = "13", Title = "Ondernemingsrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 13, AreaCode = "13a", Title = "Vennootschappen", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 13, AreaCode = "13b", Title = "Verenigingen en stichtingen", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 13, AreaCode = "13c", Title = "Agentuur en distributie", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 13, AreaCode = "13d", Title = "Fusies en overnames", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 13, AreaCode = "13e", Title = "Bestuurdersaansprakelijkheid", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 13, AreaCode = "13f", Title = "Beroepsaansprakelijkheid", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 14, AreaCode = "14", Title = "Burgerlijk procesrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 14, AreaCode = "14a", Title = "Arbitrage", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 14, AreaCode = "14b", Title = "Litigation", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 14, AreaCode = "14c", Title = "Beslag- en executierecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 15, AreaCode = "15", Title = "Transport- en handelsrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 16, AreaCode = "16", Title = "Financieel recht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 16, AreaCode = "16a", Title = "Bankrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 17, AreaCode = "17", Title = "Verzekeringsrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 18, AreaCode = "18", Title = "Belastingrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 19, AreaCode = "19", Title = "ICT-recht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 19, AreaCode = "19a", Title = "Privacy recht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 20, AreaCode = "20", Title = "Insolventierecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 20, AreaCode = "20a", Title = "Faillissement", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 20, AreaCode = "20b", Title = "Surseance van betaling", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 20, AreaCode = "20c", Title = "WSNP", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 21, AreaCode = "21", Title = "Strafrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 21, AreaCode = "21a", Title = "Jeugdstrafrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 21, AreaCode = "21b", Title = "Militair strafrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 21, AreaCode = "21c", Title = "Financieel economisch strafrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 21, AreaCode = "21d", Title = "Milieu strafrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 21, AreaCode = "21e", Title = "Fiscaal strafrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 21, AreaCode = "21f", Title = "Internationaal Strafrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 21, AreaCode = "21g", Title = "TBS", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 21, AreaCode = "21h", Title = "Uit- en overleveringszaken", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 21, AreaCode = "21i", Title = "Slachtofferzaken", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 21, AreaCode = "21j", Title = "Vreemdelingen(straf)recht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 22, AreaCode = "22", Title = "Psychiatrisch patiëntenrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 23, AreaCode = "23", Title = "Letselschaderecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 23, AreaCode = "23a", Title = "Slachtofferzaken", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 24, AreaCode = "24", Title = "Vreemdelingenrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 24, AreaCode = "24a", Title = "Vreemdelingenbewaring", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 25, AreaCode = "25", Title = "Asiel- en vluchtelingenrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 26, AreaCode = "26", Title = "Omgevingsrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 26, AreaCode = "26a", Title = "Milieurecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 26, AreaCode = "26b", Title = "Natuurbeschermingsrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 26, AreaCode = "26c", Title = "Waterrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 26, AreaCode = "26d", Title = "Ruimtelijk bestuursrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 27, AreaCode = "27", Title = "Gezondheidsrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 28, AreaCode = "28", Title = "Onderwijsrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 29, AreaCode = "29", Title = "Onteigeningsrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 30, AreaCode = "30", Title = "Bouwrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 30, AreaCode = "30a", Title = "Vastgoedrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 31, AreaCode = "31", Title = "Agrarisch recht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 32, AreaCode = "32", Title = "Tuchtrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 32, AreaCode = "32a", Title = "Medisch tuchtrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 32, AreaCode = "32b", Title = "Advocatentuchtrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 32, AreaCode = "32c", Title = "Tuchtrecht notarissen, accountants en belastingadviseurs", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 32, AreaCode = "32d", Title = "Militair tuchtrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 32, AreaCode = "32e", Title = "Makelaardij tuchtrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 32, AreaCode = "32f", Title = "Deurwaarderstuchtrecht", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 33, AreaCode = "33", Title = "Cassatie", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 33, AreaCode = "33a", Title = "Straf", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 33, AreaCode = "33b", Title = "Civiel", CreatedBy = "TOAA" },
                    new MatterArea { AreaGroup = 33, AreaCode = "33c", Title = "Belasting", CreatedBy = "TOAA" }
                );
            }
        }

        public static async Task SeedCourtGeographicalJurisdictions(ApplicationDbContext context)
        {
            if (!context.CourtGeographicalJurisdictions.Any())
            {
                await context.CourtGeographicalJurisdictions.AddRangeAsync(
                    new CourtGeographicalJurisdiction
                    {
                        Title = "Noord Nederland",
                        CreatedBy = "TOAA"
                    },
                    new CourtGeographicalJurisdiction
                    {
                        Title = "Midden Nederland",
                        CreatedBy = "TOAA"
                    },
                    new CourtGeographicalJurisdiction
                    {
                        Title = "Limburg",
                        CreatedBy = "TOAA"
                    },
                    new CourtGeographicalJurisdiction
                    {
                        Title = "Oost Brabant",
                        CreatedBy = "TOAA"
                    },
                    new CourtGeographicalJurisdiction
                    {
                        Title = "Noord Holland",
                        CreatedBy = "TOAA"
                    },
                    new CourtGeographicalJurisdiction
                    {
                        Title = "Zeeland West Brabant",
                        CreatedBy = "TOAA"
                    }
                );
            }
        }

        public static async Task SeedCourtSittingInCities(ApplicationDbContext context)
        {
            if (!context.CourtSittingInCities.Any())
            {
                await context.CourtSittingInCities.AddRangeAsync(
                    new CourtSittingInCity
                    {
                        Title = "Rechtbank Amsterdam",
                        CreatedBy = "TOAA"
                    },
                    new CourtSittingInCity
                    {
                        Title = "Rechtbank Den Haag",
                        CreatedBy = "TOAA"
                    },
                    new CourtSittingInCity
                    {
                        Title = "Rechtbank Leeuwarden",
                        CreatedBy = "TOAA"
                    },
                    new CourtSittingInCity
                    {
                        Title = "Rechtbank Haarlem",
                        CreatedBy = "TOAA"
                    },
                    new CourtSittingInCity
                    {
                        Title = "Rechtbank Vlissingen",
                        CreatedBy = "TOAA"
                    },
                    new CourtSittingInCity
                    {
                        Title = "Rechtbank Arnhem",
                        CreatedBy = "TOAA"
                    },
                    new CourtSittingInCity
                    {
                        Title = "Rechtbank Groningen",
                        CreatedBy = "TOAA"
                    },
                    new CourtSittingInCity
                    {
                        Title = "Rechtbank Breda",
                        CreatedBy = "TOAA"
                    }
                );
            }
        }

        public static async Task SeedMatters(ApplicationDbContext context)
        {
            if (!context.Matters.Any())
            {
                await context.Matters.AddRangeAsync(
                    new Matter
                    {
                        Id = Guid.NewGuid(),
                        MatterNumber = "20/0021CCC",
                        Title = "BESTBV/aandeelhouders conflict",
                        Active = true,
                        MatterTypeId = 1,
                        Synopsis = "Echtscheiding Piet Janssen/Ella Cornelis",
                        MatterAreaId = 2,
                        BillToContactId = 1,
                        BillToContactDisplayName = "Arjen Smit employee",
                        DefaultBillingRateId = 1,
                        OverrideMatterRateWithEmployeeRate = true,
                        CaseNumber = "case12345456",
                        CreatedBy = "TOAA"
                    },
                    new Matter
                    {
                        Id = Guid.NewGuid(),
                        MatterNumber = "21/0038ACU",
                        Title = "Boogert/Cornelis ontbinding huwelijk",
                        Active = true,
                        MatterTypeId = 2,
                        Synopsis = "Echtscheiding Marianne Boogert/Pater Cornelis",
                        MatterAreaId = 3,
                        BillToContactId = 3,
                        BillToContactDisplayName = "Cees Koning employee",
                        DefaultBillingRateId = 2,
                        OverrideMatterRateWithEmployeeRate = true,
                        CaseNumber = "20190003AS",
                        AttorneyForPartyTitle = "testtest",
                        CourtSittingInCityId = 1,
                        CourtGeographicalJurisdictionId = 1,
                        CaptionPlaintiffOrSubjectShort = "blah",
                        CaptionPlaintiffOrSubjectRegular = "blah",
                        CaptionPlaintiffOrSubjectLong = "blah",
                        CaptionOtherPartyShort = "blah",
                        CaptionOtherPartyRegular = "blah",
                        CaptionOtherPartyLong = "blah",
                        CreatedBy = "TOAA"
                    },
                    new Matter
                    {
                        Id = Guid.NewGuid(),
                        MatterNumber = "20/0138BKE",
                        Title = "BNNV/Brenders - Verzekeringsfraude brand",
                        Active = true,
                        MatterTypeId = 3,
                        Synopsis = "Verzekering keert niet uit ",
                        MatterAreaId = 4,
                        BillToContactId = 4,
                        BillToContactDisplayName = "Kevin van der Berg employee",
                        DefaultBillingRateId = 3,
                        OverrideMatterRateWithEmployeeRate = true,
                        CaseNumber = "20190002AS",
                        AttorneyForPartyTitle = "Eiser",
                        CourtSittingInCityId = 2,
                        CourtGeographicalJurisdictionId = 2,
                        CaptionPlaintiffOrSubjectShort = "Verzekeraar keert niet uit na brand i.v.m. vermeend brandstichting verzekerde. Verzekeraar heeft geen wettig bewijs",
                        CreatedBy = "TOAA"
                    },
                    new Matter
                    {
                        Id = Guid.NewGuid(),
                        MatterNumber = "19/0007CCC",
                        Title = "Schade aanrijding",
                        Active = true,
                        MatterTypeId = 2,
                        Synopsis = "ALIO/Soeten -  ontbindingsovereenkomst na conflict",
                        MatterAreaId = 1,
                        BillToContactId = 5,
                        BillToContactDisplayName = "Luuk Bosman employee",
                        DefaultBillingRateId = 3,
                        OverrideMatterRateWithEmployeeRate = true,
                        CourtSittingInCityId = 3,
                        CourtGeographicalJurisdictionId = 4,
                        CreatedBy = "TOAA"
                    },
                    new Matter
                    {
                        Id = Guid.NewGuid(),
                        MatterNumber = "20/0022CCC",
                        Title = "IND/Mulovi - bijstand asielprocedure",
                        Active = true,
                        MatterTypeId = 3,
                        Synopsis = "ALIO/Soeten -  ontbindingsovereenkomst na conflict",
                        MatterAreaId = 3,
                        BillToContactId = 6,
                        BillToContactDisplayName = "Sam Driessen employee",
                        DefaultBillingRateId = 4,
                        OverrideMatterRateWithEmployeeRate = true,
                        CreatedBy = "TOAA"
                    }
                );
            }
        }
    }
}
