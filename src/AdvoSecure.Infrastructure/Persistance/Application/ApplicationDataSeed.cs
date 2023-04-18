using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.ContactEntities;
using AdvoSecure.Domain.Enums;
using AdvoSecure.Infrastructure.Persistance.App;
using AdvoSecure.Infrastructure.Persistance.Tenant;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance
{
    public static class ApplicationDataSeed
    {
        //        public static async Task SeedLookupTables(ApplicationDbContext context)
        //        {
        //            if (!context.Countries.Any())
        //            {
        //                await context.Countries.AddRangeAsync(
        //                        new Country { Id = "NLD", CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", Alpha2 = "nl", Alpha3 = "nld", CountryName = "Netherlands", CountryNameNl = "Nederland" }
        //                );

        //            }
        //            if (!context.CaseTypes.Any())
        //            {
        //                await context.CaseTypes.AddRangeAsync(
        //                    new CaseType { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", Title = "Procedure" },
        //                    new CaseType { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", Title = "Gedaagde" },
        //                    new CaseType { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", Title = "Mediation" },
        //                    new CaseType { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", Title = "Advies" },
        //                    new CaseType { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", Title = "Project" },
        //                    new CaseType { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", Title = "Insolventie" },
        //                    new CaseType { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", Title = "Anders" }
        //                    );

        //            }
        //            if (!context.CaseAreas.Any())
        //            {
        //                await context.CaseAreas.AddRangeAsync(
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 1, AreaCode = "1", Title = "Onbekend of nvt" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 1, AreaCode = "1", Title = "Algemene praktijk" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 1, AreaCode = "1a", Title = "Burgerlijk recht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 1, AreaCode = "1b", Title = "Strafrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 1, AreaCode = "1c", Title = "Bestuursrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 2, AreaCode = "2", Title = "Personen- en Familierecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 2, AreaCode = "2a", Title = "Echtscheidingen, alimentatiezaken, omgangsregelingen" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 2, AreaCode = "2b", Title = "Ouderschap en erkenning" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 2, AreaCode = "2c", Title = "Collaborative divorce" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 2, AreaCode = "2d", Title = "Mediation" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 2, AreaCode = "2e", Title = "Jeugdbeschermingsrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 2, AreaCode = "2f", Title = "Bijzondere curator" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 2, AreaCode = "2g", Title = "Internationale kinderontvoering" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 2, AreaCode = "2h", Title = "Internationaal privaatrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 3, AreaCode = "3", Title = "Erfrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 4, AreaCode = "4", Title = "Arbeidsrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 4, AreaCode = "4a", Title = "Medezeggenschap" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 4, AreaCode = "4b", Title = "Collectief ontslag" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 4, AreaCode = "4c", Title = "Pensioenen" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 4, AreaCode = "4d", Title = "Arbeidsmediation" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 4, AreaCode = "4e", Title = "Internationaal arbeidsrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 5, AreaCode = "5", Title = "Sociaal-zekerheidsrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 5, AreaCode = "5a", Title = "Werknemersverzekeringen" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 5, AreaCode = "5b", Title = "Volksverzekeringen" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 5, AreaCode = "5c", Title = "Sociale voorzieningen" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 5, AreaCode = "5d", Title = "Internationaal (arbeids)recht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 6, AreaCode = "6", Title = "Ambtenarenrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 6, AreaCode = "6a", Title = "Militairen" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 7, AreaCode = "7", Title = "Huurrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 7, AreaCode = "7a", Title = "Woonruimte" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 7, AreaCode = "7b", Title = "Bedrijfsruimte" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 8, AreaCode = "8", Title = "Verbintenissenrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 9, AreaCode = "9", Title = "Sportrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 10, AreaCode = "10", Title = "Intellectueel eigendomsrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 11, AreaCode = "11", Title = "Mededingingsrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 12, AreaCode = "12", Title = "Aanbestedingsrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 13, AreaCode = "13", Title = "Ondernemingsrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 13, AreaCode = "13a", Title = "Vennootschappen" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 13, AreaCode = "13b", Title = "Verenigingen en stichtingen" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 13, AreaCode = "13c", Title = "Agentuur en distributie" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 13, AreaCode = "13d", Title = "Fusies en overnames" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 13, AreaCode = "13e", Title = "Bestuurdersaansprakelijkheid" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 13, AreaCode = "13f", Title = "Beroepsaansprakelijkheid" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 14, AreaCode = "14", Title = "Burgerlijk procesrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 14, AreaCode = "14a", Title = "Arbitrage" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 14, AreaCode = "14b", Title = "Litigation" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 14, AreaCode = "14c", Title = "Beslag- en executierecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 15, AreaCode = "15", Title = "Transport- en handelsrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 16, AreaCode = "16", Title = "Financieel recht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 16, AreaCode = "16a", Title = "Bankrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 17, AreaCode = "17", Title = "Verzekeringsrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 18, AreaCode = "18", Title = "Belastingrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 19, AreaCode = "19", Title = "ICT-recht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 19, AreaCode = "19a", Title = "Privacy recht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 20, AreaCode = "20", Title = "Insolventierecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 20, AreaCode = "20a", Title = "Faillissement" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 20, AreaCode = "20b", Title = "Surseance van betaling" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 20, AreaCode = "20c", Title = "WSNP" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 21, AreaCode = "21", Title = "Strafrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 21, AreaCode = "21a", Title = "Jeugdstrafrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 21, AreaCode = "21b", Title = "Militair strafrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 21, AreaCode = "21c", Title = "Financieel economisch strafrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 21, AreaCode = "21d", Title = "Milieu strafrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 21, AreaCode = "21e", Title = "Fiscaal strafrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 21, AreaCode = "21f", Title = "Internationaal Strafrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 21, AreaCode = "21g", Title = "TBS" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 21, AreaCode = "21h", Title = "Uit- en overleveringszaken" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 21, AreaCode = "21i", Title = "Slachtofferzaken" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 21, AreaCode = "21j", Title = "Vreemdelingen(straf)recht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 22, AreaCode = "22", Title = "Psychiatrisch patiëntenrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 23, AreaCode = "23", Title = "Letselschaderecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 23, AreaCode = "23a", Title = "Slachtofferzaken" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 24, AreaCode = "24", Title = "Vreemdelingenrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 24, AreaCode = "24a", Title = "Vreemdelingenbewaring" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 25, AreaCode = "25", Title = "Asiel- en vluchtelingenrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 26, AreaCode = "26", Title = "Omgevingsrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 26, AreaCode = "26a", Title = "Milieurecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 26, AreaCode = "26b", Title = "Natuurbeschermingsrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 26, AreaCode = "26c", Title = "Waterrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 26, AreaCode = "26d", Title = "Ruimtelijk bestuursrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 27, AreaCode = "27", Title = "Gezondheidsrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 28, AreaCode = "28", Title = "Onderwijsrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 29, AreaCode = "29", Title = "Onteigeningsrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 30, AreaCode = "30", Title = "Bouwrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 30, AreaCode = "30a", Title = "Vastgoedrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 31, AreaCode = "31", Title = "Agrarisch recht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 32, AreaCode = "32", Title = "Tuchtrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 32, AreaCode = "32a", Title = "Medisch tuchtrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 32, AreaCode = "32b", Title = "Advocatentuchtrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 32, AreaCode = "32c", Title = "Tuchtrecht notarissen, accountants en belastingadviseurs" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 32, AreaCode = "32d", Title = "Militair tuchtrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 32, AreaCode = "32e", Title = "Makelaardij tuchtrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 32, AreaCode = "32f", Title = "Deurwaarderstuchtrecht" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 33, AreaCode = "33", Title = "Cassatie" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 33, AreaCode = "33a", Title = "Straf" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 33, AreaCode = "33b", Title = "Civiel" },
        //                    new CaseArea { CreatedDateTime = DateTime.UtcNow, CreatedBy = "System", AreaGroup = 33, AreaCode = "33c", Title = "Belasting" }
        //                );
        //                await context.SaveChangesAsync();
        //            }
        //        }

        //        public static async Task SeedTestUsers(ApplicationDbContext context)
        //        {
        //            if (!context.Users.Any())
        //            {
        //                await context.Users.AddRangeAsync(
        //                    new User
        //                    {
        //                        Id = Guid.Parse("fb98297c-c5cd-4f1f-9425-108d9dd30fcf"),
        //                        Comment = "Comment from user",
        //                        DisplayName = "Roderic",
        //                        DisplayNamePrefix = "Mister",
        //                        LastActivityDate = DateTime.UtcNow.AddDays(-20),
        //                        CreatedDateTime = DateTime.UtcNow,
        //                        CreatedBy = "System"
        //                    },
        //                    new User
        //                    {
        //                        Id = Guid.Parse("4e31f117-c7c2-41a9-b190-a018b50c506e"),
        //                        Comment = "Comment from user",
        //                        DisplayName = "GJ",
        //                        DisplayNamePrefix = "Mister",
        //                        LastActivityDate = DateTime.UtcNow,
        //                        CreatedDateTime = DateTime.UtcNow,
        //                        CreatedBy = "System"
        //                    }
        //                );

        //                await context.SaveChangesAsync();
        //            }
        //        }

        //        public static async Task SeedTestCase(ApplicationDbContext context)
        //        {
        //            if (!await context.Addresses.AnyAsync())
        //            {
        //                await context.Addresses.AddRangeAsync(
        //                    new Address
        //                    {
        //                        CreatedDateTime = DateTime.UtcNow,
        //                        CreatedBy = "System",
        //                        Id = new Guid("11110000-0000-0000-0000-000000000001"),
        //                        DisplayName = "Home address",
        //                        AddressType = AddressType.Post,
        //                        CountryId = "NLD",
        //                        HouseNo = "1",
        //                        Street = "Streetname",
        //                        City = "Cityname"
        //                    }
        //                );
        //                await context.SaveChangesAsync();
        //            }

        //            if (!context.Contacts.Any())
        //            {
        //                await context.Contacts.AddRangeAsync(
        //                    new Contact
        //                    {
        //                        CreatedDateTime = DateTime.UtcNow,
        //                        CreatedBy = "System",
        //                        Id = new Guid("00000000-0000-1111-1111-000000000001"),
        //                        DisplayName = "Contactpersoon 1",
        //                        Addresses = new Address[]{
        //                       context.Addresses.First(),
        //                        }
        //                    },
        //                    new Contact
        //                    {
        //                        CreatedDateTime = DateTime.UtcNow,
        //                        CreatedBy = "System",
        //                        Id = new Guid("00000000-0000-1111-1111-000000000002"),
        //                        DisplayName = "Contactpersoon 2"
        //                    }
        //                    );
        //            }
        //            if (!context.Cases.Any())
        //            {
        //                await context.Cases.AddRangeAsync(
        //                    new Case
        //                    {
        //                        CreatedDateTime = DateTime.UtcNow,
        //                        CreatedBy = "System",
        //                        Id = new Guid("00000000-0000-0000-1111-000000000001"),
        //                        CaseNumber = "MAT01",
        //                        Title = "Test Case 1",
        //                        CaseTypeId = 1,
        //                        Active = true,
        //                        CaseAreaId = 1,
        //                        Synopsis = "Some case to do something",
        //                        CaseReferenceNumber = "QQ999"
        //                    },
        //                    new Case
        //                    {
        //                        CreatedDateTime = DateTime.UtcNow,
        //                        CreatedBy = "System",
        //                        Id = new Guid("00000000-0000-0000-1111-000000000002"),
        //                        CaseNumber = "MAT02",
        //                        Title = "Test Case 2",
        //                        CaseTypeId = 4,
        //                        Active = true,
        //                        CaseAreaId = 2,
        //                        Synopsis = "Insurance fraud case",
        //                        CaseReferenceNumber = "MLA23232"
        //                    }
        //                    );

        //            }
        //            if (!context.CaseContacts.Any())
        //            {
        //                await context.CaseContacts.AddRangeAsync(
        //                    new CaseContact
        //                    {
        //                        CreatedDateTime = DateTime.UtcNow,
        //                        CreatedBy = "System",
        //                        Id = new Guid("00000000-1111-1111-1111-000000000001"),
        //                        ContactId = new Guid("00000000-0000-1111-1111-000000000001"),
        //                        CaseId = new Guid("00000000-0000-0000-1111-000000000001"),
        //                        IsClient = true,
        //                    },
        //                    new CaseContact
        //                    {
        //                        CreatedDateTime = DateTime.UtcNow,
        //                        CreatedBy = "System",
        //                        Id = new Guid("00000000-1111-1111-1111-000000000002"),
        //                        ContactId = new Guid("00000000-0000-1111-1111-000000000001"),
        //                        CaseId = new Guid("00000000-0000-0000-1111-000000000002")
        //                    },
        //                    new CaseContact
        //                    {
        //                        CreatedDateTime = DateTime.UtcNow,
        //                        CreatedBy = "System",
        //                        Id = new Guid("00000000-1111-1111-1111-000000000003"),
        //                        ContactId = new Guid("00000000-0000-1111-1111-000000000002"),
        //                        CaseId = new Guid("00000000-0000-0000-1111-000000000002"),
        //                        IsClient = true,
        //                    }
        //                    );
        //            }
        //            await context.SaveChangesAsync();
        //        }

        public static async Task SeedAsAppTables(ApplicationDbContext context)
        {
            await SeedContactIdTypes(context);

            await SeedContactCivilStatuses(context);

            await context.SaveChangesAsync();

            await SeedEmployees(context);

            await SeedPersons(context);

            await context.SaveChangesAsync();
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
            if (!context.Contacts.Any(x => x.IsOurEmployee))
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
                        DisplayName = "Arjen Smit",
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
                        DisplayName = "Levi de Ruiter",
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
                        DisplayName = "Cees Koning",
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
                        DisplayName = "Kevin van der Berg",
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
                        DisplayName = "Luuk Bosman",
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
                        DisplayName = "Sam Driessen",
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
                        DisplayName = "Lisa van Veen",
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
                        DisplayName = "Indy van de Wetering",
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
                        DisplayName = "Ilse van der Velde",
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
                        DisplayName = "Sterre van der Veen",
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
                        DisplayName = "Jelle Peters",
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
                        DisplayName = "Elisabeth Elzinga",
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
            if (!context.Contacts.Any(x => !x.IsOurEmployee))
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
    }
}
