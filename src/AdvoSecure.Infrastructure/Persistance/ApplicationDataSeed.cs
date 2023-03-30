//using AdvoSecure.Domain.Entities;
//using AdvoSecure.Domain.Enums;
//using Microsoft.EntityFrameworkCore;

//namespace AdvoSecure.Infrastructure.Persistance
//{
//    public static class ApplicationDataSeed
//    {
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
//    }
//}
