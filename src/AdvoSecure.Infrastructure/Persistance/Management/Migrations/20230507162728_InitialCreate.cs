using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdvoSecure.Infrastructure.Persistance.Management.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingRate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingRate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyLegalStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLegalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactCivilStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCivilStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactIdType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactIdType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourtGeographicalJurisdictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtGeographicalJurisdictions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourtSittingInCities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtSittingInCities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadSourceType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadSourceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatterAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AreaGroup = table.Column<int>(type: "integer", nullable: false),
                    AreaCode = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatterAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpportunityStage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Order = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpportunityStage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantIdentifier = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Group = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SchemaName = table.Column<string>(type: "text", nullable: false),
                    ConnectionString = table.Column<string>(type: "text", nullable: false),
                    AdminId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsOurEmployee = table.Column<bool>(type: "boolean", nullable: false),
                    IsOrganization = table.Column<bool>(type: "boolean", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: true),
                    PictureBin = table.Column<byte[]>(type: "bytea", nullable: true),
                    Nickname = table.Column<string>(type: "text", nullable: true),
                    Generation = table.Column<string>(type: "text", nullable: true),
                    DisplayNamePrefix = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    GivenName = table.Column<string>(type: "text", nullable: true),
                    Initials = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    Email1DisplayName = table.Column<string>(type: "text", nullable: true),
                    Email1EmailAddress = table.Column<string>(type: "text", nullable: true),
                    Email2DisplayName = table.Column<string>(type: "text", nullable: true),
                    Email2EmailAddress = table.Column<string>(type: "text", nullable: true),
                    Email3DisplayName = table.Column<string>(type: "text", nullable: true),
                    Email3EmailAddress = table.Column<string>(type: "text", nullable: true),
                    Fax1DisplayName = table.Column<string>(type: "text", nullable: true),
                    Fax1FaxNumber = table.Column<string>(type: "text", nullable: true),
                    Fax2DisplayName = table.Column<string>(type: "text", nullable: true),
                    Fax2FaxNumber = table.Column<string>(type: "text", nullable: true),
                    Fax3DisplayName = table.Column<string>(type: "text", nullable: true),
                    Fax3FaxNumber = table.Column<string>(type: "text", nullable: true),
                    Address1DisplayName = table.Column<string>(type: "text", nullable: true),
                    Address1AddressStreet = table.Column<string>(type: "text", nullable: true),
                    Address1AddressHouseNo = table.Column<string>(type: "text", nullable: true),
                    Address1AddressHouseNoExt = table.Column<string>(type: "text", nullable: true),
                    Address1AddressLine2 = table.Column<string>(type: "text", nullable: true),
                    Address1AddressCity = table.Column<string>(type: "text", nullable: true),
                    Address1AddressStateOrProvince = table.Column<string>(type: "text", nullable: true),
                    Address1AddressPostalCode = table.Column<string>(type: "text", nullable: true),
                    Address1AddressCountry = table.Column<string>(type: "text", nullable: true),
                    Address1AddressCountryCode = table.Column<string>(type: "text", nullable: true),
                    Address1AddressPostOfficeBox = table.Column<string>(type: "text", nullable: true),
                    Address2DisplayName = table.Column<string>(type: "text", nullable: true),
                    Address2AddressStreet = table.Column<string>(type: "text", nullable: true),
                    Address2AddressHouseNo = table.Column<string>(type: "text", nullable: true),
                    Address2AddressHouseNoExt = table.Column<string>(type: "text", nullable: true),
                    Address2AddressLine2 = table.Column<string>(type: "text", nullable: true),
                    Address2AddressCity = table.Column<string>(type: "text", nullable: true),
                    Address2AddressStateOrProvince = table.Column<string>(type: "text", nullable: true),
                    Address2AddressPostalCode = table.Column<string>(type: "text", nullable: true),
                    Address2AddressCountry = table.Column<string>(type: "text", nullable: true),
                    Address2AddressCountryCode = table.Column<string>(type: "text", nullable: true),
                    Address2AddressPostOfficeBox = table.Column<string>(type: "text", nullable: true),
                    Address3DisplayName = table.Column<string>(type: "text", nullable: true),
                    Address3AddressStreet = table.Column<string>(type: "text", nullable: true),
                    Address3AddressHouseNo = table.Column<string>(type: "text", nullable: true),
                    Address3AddressHouseNoExt = table.Column<string>(type: "text", nullable: true),
                    Address3AddressLine2 = table.Column<string>(type: "text", nullable: true),
                    Address3AddressCity = table.Column<string>(type: "text", nullable: true),
                    Address3AddressStateOrProvince = table.Column<string>(type: "text", nullable: true),
                    Address3AddressPostalCode = table.Column<string>(type: "text", nullable: true),
                    Address3AddressCountry = table.Column<string>(type: "text", nullable: true),
                    Address3AddressCountryCode = table.Column<string>(type: "text", nullable: true),
                    Address3AddressPostOfficeBox = table.Column<string>(type: "text", nullable: true),
                    Telephone1DisplayName = table.Column<string>(type: "text", nullable: true),
                    Telephone1TelephoneNumber = table.Column<string>(type: "text", nullable: true),
                    Telephone2DisplayName = table.Column<string>(type: "text", nullable: true),
                    Telephone2TelephoneNumber = table.Column<string>(type: "text", nullable: true),
                    Telephone3DisplayName = table.Column<string>(type: "text", nullable: true),
                    Telephone3TelephoneNumber = table.Column<string>(type: "text", nullable: true),
                    Telephone4DisplayName = table.Column<string>(type: "text", nullable: true),
                    Telephone4TelephoneNumber = table.Column<string>(type: "text", nullable: true),
                    Telephone5DisplayName = table.Column<string>(type: "text", nullable: true),
                    Telephone5TelephoneNumber = table.Column<string>(type: "text", nullable: true),
                    Telephone6DisplayName = table.Column<string>(type: "text", nullable: true),
                    Telephone6TelephoneNumber = table.Column<string>(type: "text", nullable: true),
                    Telephone7DisplayName = table.Column<string>(type: "text", nullable: true),
                    Telephone7TelephoneNumber = table.Column<string>(type: "text", nullable: true),
                    Telephone8DisplayName = table.Column<string>(type: "text", nullable: true),
                    Telephone8TelephoneNumber = table.Column<string>(type: "text", nullable: true),
                    Telephone9DisplayName = table.Column<string>(type: "text", nullable: true),
                    Telephone9TelephoneNumber = table.Column<string>(type: "text", nullable: true),
                    Telephone10DisplayName = table.Column<string>(type: "text", nullable: true),
                    Telephone10TelephoneNumber = table.Column<string>(type: "text", nullable: true),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Wedding = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    BarNumber = table.Column<string>(type: "text", nullable: true),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    DepartmentName = table.Column<string>(type: "text", nullable: true),
                    OfficeLocation = table.Column<string>(type: "text", nullable: true),
                    ManagerName = table.Column<string>(type: "text", nullable: true),
                    AssistantName = table.Column<string>(type: "text", nullable: true),
                    Profession = table.Column<string>(type: "text", nullable: true),
                    Saluation = table.Column<string>(type: "text", nullable: true),
                    SpouseName = table.Column<string>(type: "text", nullable: true),
                    Language = table.Column<string>(type: "text", nullable: true),
                    InstantMessagingAddress = table.Column<string>(type: "text", nullable: true),
                    PersonalHomePage = table.Column<string>(type: "text", nullable: true),
                    BusinessHomePage = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    ReferredByName = table.Column<string>(type: "text", nullable: true),
                    IdNumber = table.Column<string>(type: "text", nullable: true),
                    IdDateExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Nationality = table.Column<string>(type: "text", nullable: true),
                    BirthCity = table.Column<string>(type: "text", nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "text", nullable: true),
                    VNumber = table.Column<string>(type: "text", nullable: true),
                    BankAccount = table.Column<string>(type: "text", nullable: true),
                    BicCode = table.Column<string>(type: "text", nullable: true),
                    BankName = table.Column<string>(type: "text", nullable: true),
                    SepaMandateNumber = table.Column<string>(type: "text", nullable: true),
                    SepaMandateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SepaMandateLimit = table.Column<short>(type: "smallint", nullable: true),
                    TaxNumber = table.Column<string>(type: "text", nullable: true),
                    VatId = table.Column<string>(type: "text", nullable: true),
                    SbiCode = table.Column<string>(type: "text", nullable: true),
                    BusinessRegistration = table.Column<string>(type: "text", nullable: true),
                    DateOfIncorporation = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LegalForm = table.Column<string>(type: "text", nullable: true),
                    NumEmployees = table.Column<int>(type: "integer", nullable: true),
                    TurnOver = table.Column<int>(type: "integer", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    BillingRateId = table.Column<int>(type: "integer", nullable: true),
                    CivilStatusId = table.Column<int>(type: "integer", nullable: true),
                    IdTypeId = table.Column<int>(type: "integer", nullable: true),
                    CompanyLegalStatusId = table.Column<int>(type: "integer", nullable: true),
                    MatterTypeId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_BillingRate_BillingRateId",
                        column: x => x.BillingRateId,
                        principalTable: "BillingRate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contact_CompanyLegalStatus_CompanyLegalStatusId",
                        column: x => x.CompanyLegalStatusId,
                        principalTable: "CompanyLegalStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contact_ContactCivilStatus_CivilStatusId",
                        column: x => x.CivilStatusId,
                        principalTable: "ContactCivilStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contact_ContactIdType_IdTypeId",
                        column: x => x.IdTypeId,
                        principalTable: "ContactIdType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contact_MatterTypes_MatterTypeId",
                        column: x => x.MatterTypeId,
                        principalTable: "MatterTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TagBase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tag = table.Column<string>(type: "text", nullable: false),
                    TagCategoryId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagBase_TagCategory_TagCategoryId",
                        column: x => x.TagCategoryId,
                        principalTable: "TagCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ProjectedStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ProjectedEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActualEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsGroupingTask = table.Column<bool>(type: "boolean", nullable: false),
                    SequentialPredecessorId = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CompletePercentage = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    TaskTypeId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Tasks_SequentialPredecessorId",
                        column: x => x.SequentialPredecessorId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantBillings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirmName = table.Column<string>(type: "text", nullable: false),
                    FirmAddress = table.Column<string>(type: "text", nullable: false),
                    FirmAddress2 = table.Column<string>(type: "text", nullable: false),
                    FirmCity = table.Column<string>(type: "text", nullable: false),
                    FirmState = table.Column<string>(type: "text", nullable: false),
                    FirmZip = table.Column<string>(type: "text", nullable: false),
                    FirmCountry = table.Column<string>(type: "text", nullable: false),
                    FirmPhone = table.Column<string>(type: "text", nullable: false),
                    FirmWeb = table.Column<string>(type: "text", nullable: false),
                    FirmVATid = table.Column<string>(type: "text", nullable: false),
                    FirmBankAccount = table.Column<string>(type: "text", nullable: false),
                    FirmBankBIC = table.Column<string>(type: "text", nullable: false),
                    FirmBankName = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantBillings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantBillings_TenantSettings_TenantId",
                        column: x => x.TenantId,
                        principalTable: "TenantSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantDirectories",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantDirectories", x => new { x.TenantId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TenantDirectories_TenantSettings_TenantId",
                        column: x => x.TenantId,
                        principalTable: "TenantSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantDirectories_TenantUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TenantUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    LastRun = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NextRun = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    BillToContactId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingGroups_Contact_BillToContactId",
                        column: x => x.BillToContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadFee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsEligible = table.Column<bool>(type: "boolean", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric", nullable: true),
                    Paid = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AdditionalData = table.Column<string>(type: "text", nullable: false),
                    ToId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadFee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadFee_Contact_ToId",
                        column: x => x.ToId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeadSource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    AdditionalQuestion1 = table.Column<string>(type: "text", nullable: false),
                    AdditionalData1 = table.Column<string>(type: "text", nullable: false),
                    AdditionalQuestion2 = table.Column<string>(type: "text", nullable: false),
                    AdditionalData2 = table.Column<string>(type: "text", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: true),
                    ContactId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadSource_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeadSource_LeadSourceType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "LeadSourceType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NoteNotification",
                columns: table => new
                {
                    NoteId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactId = table.Column<int>(type: "integer", nullable: false),
                    Cleared = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteNotification", x => new { x.ContactId, x.NoteId });
                    table.ForeignKey(
                        name: "FK_NoteNotification_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteNotification_Note_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Note",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Stop = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: false),
                    Billable = table.Column<bool>(type: "boolean", nullable: false),
                    WorkerContactId = table.Column<int>(type: "integer", nullable: false),
                    TimeCategoryId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Time_Contact_WorkerContactId",
                        column: x => x.WorkerContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Time_TimeCategory_TimeCategoryId",
                        column: x => x.TimeCategoryId,
                        principalTable: "TimeCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InnerTaskNote",
                columns: table => new
                {
                    NotesId = table.Column<Guid>(type: "uuid", nullable: false),
                    TasksId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnerTaskNote", x => new { x.NotesId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_InnerTaskNote_Note_NotesId",
                        column: x => x.NotesId,
                        principalTable: "Note",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InnerTaskNote_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InnerTaskTagBase",
                columns: table => new
                {
                    TagsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TasksId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnerTaskTagBase", x => new { x.TagsId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_InnerTaskTagBase_TagBase_TagsId",
                        column: x => x.TagsId,
                        principalTable: "TagBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InnerTaskTagBase_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskAssignedContacts",
                columns: table => new
                {
                    TaskId = table.Column<long>(type: "bigint", nullable: false),
                    ContactId = table.Column<int>(type: "integer", nullable: false),
                    AssignmentType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAssignedContacts", x => new { x.ContactId, x.TaskId });
                    table.ForeignKey(
                        name: "FK_TaskAssignedContacts_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskAssignedContacts_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdInt = table.Column<long>(type: "bigint", nullable: true),
                    MatterNumber = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Synopsis = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CaseNumber = table.Column<string>(type: "text", nullable: true),
                    BillToContactDisplayName = table.Column<string>(type: "text", nullable: false),
                    MinimumCharge = table.Column<decimal>(type: "numeric", nullable: true),
                    EstimatedCharge = table.Column<decimal>(type: "numeric", nullable: true),
                    MaximumCharge = table.Column<decimal>(type: "numeric", nullable: true),
                    OverrideMatterRateWithEmployeeRate = table.Column<bool>(type: "boolean", nullable: false),
                    AttorneyForPartyTitle = table.Column<string>(type: "text", nullable: true),
                    CaptionPlaintiffOrSubjectShort = table.Column<string>(type: "text", nullable: true),
                    CaptionPlaintiffOrSubjectRegular = table.Column<string>(type: "text", nullable: true),
                    CaptionPlaintiffOrSubjectLong = table.Column<string>(type: "text", nullable: true),
                    CaptionOtherPartyShort = table.Column<string>(type: "text", nullable: true),
                    CaptionOtherPartyRegular = table.Column<string>(type: "text", nullable: true),
                    CaptionOtherPartyLong = table.Column<string>(type: "text", nullable: true),
                    MatterTypeId = table.Column<int>(type: "integer", nullable: false),
                    BillToContactId = table.Column<int>(type: "integer", nullable: false),
                    DefaultBillingRateId = table.Column<int>(type: "integer", nullable: false),
                    BillingGroupId = table.Column<int>(type: "integer", nullable: true),
                    MatterAreaId = table.Column<int>(type: "integer", nullable: true),
                    CourtGeographicalJurisdictionId = table.Column<int>(type: "integer", nullable: true),
                    CourtSittingInCityId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matters_BillingGroups_BillingGroupId",
                        column: x => x.BillingGroupId,
                        principalTable: "BillingGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matters_BillingRate_DefaultBillingRateId",
                        column: x => x.DefaultBillingRateId,
                        principalTable: "BillingRate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matters_Contact_BillToContactId",
                        column: x => x.BillToContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matters_CourtGeographicalJurisdictions_CourtGeographicalJur~",
                        column: x => x.CourtGeographicalJurisdictionId,
                        principalTable: "CourtGeographicalJurisdictions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matters_CourtSittingInCities_CourtSittingInCityId",
                        column: x => x.CourtSittingInCityId,
                        principalTable: "CourtSittingInCities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matters_MatterAreas_MatterAreaId",
                        column: x => x.MatterAreaId,
                        principalTable: "MatterAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matters_MatterTypes_MatterTypeId",
                        column: x => x.MatterTypeId,
                        principalTable: "MatterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Closed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: true),
                    ContactId = table.Column<int>(type: "integer", nullable: true),
                    SourceId = table.Column<int>(type: "integer", nullable: true),
                    FeeId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lead_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lead_LeadFee_FeeId",
                        column: x => x.FeeId,
                        principalTable: "LeadFee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lead_LeadSource_SourceId",
                        column: x => x.SourceId,
                        principalTable: "LeadSource",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lead_LeadStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "LeadStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InnerTaskTime",
                columns: table => new
                {
                    TasksId = table.Column<long>(type: "bigint", nullable: false),
                    TimesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnerTaskTime", x => new { x.TasksId, x.TimesId });
                    table.ForeignKey(
                        name: "FK_InnerTaskTime_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InnerTaskTime_Time_TimesId",
                        column: x => x.TimesId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InnerTaskMatter",
                columns: table => new
                {
                    MattersId = table.Column<Guid>(type: "uuid", nullable: false),
                    TasksId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnerTaskMatter", x => new { x.MattersId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_InnerTaskMatter_Matters_MattersId",
                        column: x => x.MattersId,
                        principalTable: "Matters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InnerTaskMatter_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatterContacts",
                columns: table => new
                {
                    MatterId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactId = table.Column<int>(type: "integer", nullable: false),
                    IsClient = table.Column<bool>(type: "boolean", nullable: false),
                    IsClientContact = table.Column<bool>(type: "boolean", nullable: false),
                    IsAppointed = table.Column<bool>(type: "boolean", nullable: false),
                    IsParty = table.Column<bool>(type: "boolean", nullable: false),
                    PartyTitle = table.Column<string>(type: "text", nullable: false),
                    IsJudge = table.Column<bool>(type: "boolean", nullable: false),
                    IsWitness = table.Column<bool>(type: "boolean", nullable: false),
                    IsLeadAttorney = table.Column<bool>(type: "boolean", nullable: false),
                    IsAttorney = table.Column<bool>(type: "boolean", nullable: false),
                    IsSupportStaff = table.Column<bool>(type: "boolean", nullable: false),
                    IsThirdPartyPayor = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatterContacts", x => new { x.ContactId, x.MatterId });
                    table.ForeignKey(
                        name: "FK_MatterContacts_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatterContacts_Matters_MatterId",
                        column: x => x.MatterId,
                        principalTable: "Matters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatterNote",
                columns: table => new
                {
                    MattersId = table.Column<Guid>(type: "uuid", nullable: false),
                    NotesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatterNote", x => new { x.MattersId, x.NotesId });
                    table.ForeignKey(
                        name: "FK_MatterNote_Matters_MattersId",
                        column: x => x.MattersId,
                        principalTable: "Matters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatterNote_Note_NotesId",
                        column: x => x.NotesId,
                        principalTable: "Note",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opportunity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Probability = table.Column<decimal>(type: "numeric", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric", nullable: true),
                    Closed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StageId = table.Column<int>(type: "integer", nullable: true),
                    LeadId = table.Column<long>(type: "bigint", nullable: true),
                    MatterId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opportunity_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opportunity_Matters_MatterId",
                        column: x => x.MatterId,
                        principalTable: "Matters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opportunity_OpportunityStage_StageId",
                        column: x => x.StageId,
                        principalTable: "OpportunityStage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContactOpportunity",
                columns: table => new
                {
                    ContactsId = table.Column<int>(type: "integer", nullable: false),
                    OpportunitiesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactOpportunity", x => new { x.ContactsId, x.OpportunitiesId });
                    table.ForeignKey(
                        name: "FK_ContactOpportunity_Contact_ContactsId",
                        column: x => x.ContactsId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactOpportunity_Opportunity_OpportunitiesId",
                        column: x => x.OpportunitiesId,
                        principalTable: "Opportunity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillingGroups_BillToContactId",
                table: "BillingGroups",
                column: "BillToContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_BillingRateId",
                table: "Contact",
                column: "BillingRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CivilStatusId",
                table: "Contact",
                column: "CivilStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CompanyLegalStatusId",
                table: "Contact",
                column: "CompanyLegalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_IdTypeId",
                table: "Contact",
                column: "IdTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_MatterTypeId",
                table: "Contact",
                column: "MatterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactOpportunity_OpportunitiesId",
                table: "ContactOpportunity",
                column: "OpportunitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerTaskMatter_TasksId",
                table: "InnerTaskMatter",
                column: "TasksId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerTaskNote_TasksId",
                table: "InnerTaskNote",
                column: "TasksId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerTaskTagBase_TasksId",
                table: "InnerTaskTagBase",
                column: "TasksId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerTaskTime_TimesId",
                table: "InnerTaskTime",
                column: "TimesId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_ContactId",
                table: "Lead",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_FeeId",
                table: "Lead",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_SourceId",
                table: "Lead",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_StatusId",
                table: "Lead",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadFee_ToId",
                table: "LeadFee",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadSource_ContactId",
                table: "LeadSource",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadSource_TypeId",
                table: "LeadSource",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MatterContacts_MatterId",
                table: "MatterContacts",
                column: "MatterId");

            migrationBuilder.CreateIndex(
                name: "IX_MatterNote_NotesId",
                table: "MatterNote",
                column: "NotesId");

            migrationBuilder.CreateIndex(
                name: "IX_Matters_BillingGroupId",
                table: "Matters",
                column: "BillingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Matters_BillToContactId",
                table: "Matters",
                column: "BillToContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Matters_CourtGeographicalJurisdictionId",
                table: "Matters",
                column: "CourtGeographicalJurisdictionId");

            migrationBuilder.CreateIndex(
                name: "IX_Matters_CourtSittingInCityId",
                table: "Matters",
                column: "CourtSittingInCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Matters_DefaultBillingRateId",
                table: "Matters",
                column: "DefaultBillingRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Matters_MatterAreaId",
                table: "Matters",
                column: "MatterAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Matters_MatterTypeId",
                table: "Matters",
                column: "MatterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteNotification_NoteId",
                table: "NoteNotification",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_LeadId",
                table: "Opportunity",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_MatterId",
                table: "Opportunity",
                column: "MatterId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_StageId",
                table: "Opportunity",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_TagBase_TagCategoryId",
                table: "TagBase",
                column: "TagCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignedContacts_TaskId",
                table: "TaskAssignedContacts",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_SequentialPredecessorId",
                table: "Tasks",
                column: "SequentialPredecessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantBillings_TenantId",
                table: "TenantBillings",
                column: "TenantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TenantDirectories_UserId",
                table: "TenantDirectories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Time_TimeCategoryId",
                table: "Time",
                column: "TimeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Time_WorkerContactId",
                table: "Time",
                column: "WorkerContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactOpportunity");

            migrationBuilder.DropTable(
                name: "InnerTaskMatter");

            migrationBuilder.DropTable(
                name: "InnerTaskNote");

            migrationBuilder.DropTable(
                name: "InnerTaskTagBase");

            migrationBuilder.DropTable(
                name: "InnerTaskTime");

            migrationBuilder.DropTable(
                name: "MatterContacts");

            migrationBuilder.DropTable(
                name: "MatterNote");

            migrationBuilder.DropTable(
                name: "NoteNotification");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "TaskAssignedContacts");

            migrationBuilder.DropTable(
                name: "TenantBillings");

            migrationBuilder.DropTable(
                name: "TenantDirectories");

            migrationBuilder.DropTable(
                name: "Opportunity");

            migrationBuilder.DropTable(
                name: "TagBase");

            migrationBuilder.DropTable(
                name: "Time");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TenantSettings");

            migrationBuilder.DropTable(
                name: "TenantUsers");

            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.DropTable(
                name: "Matters");

            migrationBuilder.DropTable(
                name: "OpportunityStage");

            migrationBuilder.DropTable(
                name: "TagCategory");

            migrationBuilder.DropTable(
                name: "TimeCategory");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "LeadFee");

            migrationBuilder.DropTable(
                name: "LeadSource");

            migrationBuilder.DropTable(
                name: "LeadStatus");

            migrationBuilder.DropTable(
                name: "BillingGroups");

            migrationBuilder.DropTable(
                name: "CourtGeographicalJurisdictions");

            migrationBuilder.DropTable(
                name: "CourtSittingInCities");

            migrationBuilder.DropTable(
                name: "MatterAreas");

            migrationBuilder.DropTable(
                name: "LeadSourceType");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "BillingRate");

            migrationBuilder.DropTable(
                name: "CompanyLegalStatus");

            migrationBuilder.DropTable(
                name: "ContactCivilStatus");

            migrationBuilder.DropTable(
                name: "ContactIdType");

            migrationBuilder.DropTable(
                name: "MatterTypes");
        }
    }
}
