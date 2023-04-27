using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdvoSecure.Infrastructure.Persistance.Application.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillingRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyLegalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLegalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactCivilStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCivilStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactIdTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactIdTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Alpha2 = table.Column<string>(type: "text", nullable: false),
                    Alpha3 = table.Column<string>(type: "text", nullable: false),
                    PhoneIso = table.Column<string>(type: "text", nullable: false),
                    CurrencyIso = table.Column<string>(type: "text", nullable: false),
                    EuMember = table.Column<string>(type: "text", nullable: false),
                    CountryName_en = table.Column<string>(type: "text", nullable: false),
                    CountryName_fr = table.Column<string>(type: "text", nullable: false),
                    CountryName_de = table.Column<string>(type: "text", nullable: false),
                    CountryName_nl = table.Column<string>(type: "text", nullable: false),
                    CountryName_it = table.Column<string>(type: "text", nullable: false),
                    CountryName_es = table.Column<string>(type: "text", nullable: false),
                    ibancode = table.Column<string>(type: "text", nullable: false),
                    ibanlen = table.Column<string>(type: "text", nullable: false),
                    ibancheck = table.Column<string>(type: "text", nullable: false),
                    sepa = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
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
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
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
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtSittingInCities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Alpha2 = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Alpha3 = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    TitleEn = table.Column<string>(type: "text", nullable: true),
                    TitleFr = table.Column<string>(type: "text", nullable: true),
                    TitleDe = table.Column<string>(type: "text", nullable: true),
                    TitleNl = table.Column<string>(type: "text", nullable: true),
                    TitleIt = table.Column<string>(type: "text", nullable: true),
                    TitleEs = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
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
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
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
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatterTypes", x => x.Id);
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
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
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
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_BillingRates_BillingRateId",
                        column: x => x.BillingRateId,
                        principalTable: "BillingRates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_CompanyLegalStatuses_CompanyLegalStatusId",
                        column: x => x.CompanyLegalStatusId,
                        principalTable: "CompanyLegalStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_ContactCivilStatuses_CivilStatusId",
                        column: x => x.CivilStatusId,
                        principalTable: "ContactCivilStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_ContactIdTypes_IdTypeId",
                        column: x => x.IdTypeId,
                        principalTable: "ContactIdTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_MatterTypes_MatterTypeId",
                        column: x => x.MatterTypeId,
                        principalTable: "MatterTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ProjectedStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ProjectedEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActualEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsGroupingTask = table.Column<bool>(type: "boolean", nullable: false),
                    SequentialPredecessorId = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CompletePercentage = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    TaskTypeId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
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
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingGroups_Contacts_BillToContactId",
                        column: x => x.BillToContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskAssignedContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false),
                    ContactId = table.Column<int>(type: "integer", nullable: false),
                    AssignmentType = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAssignedContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskAssignedContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
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
                    DefaultBillingRateId = table.Column<int>(type: "integer", nullable: false),
                    BillToContactId = table.Column<int>(type: "integer", nullable: false),
                    BillingGroupId = table.Column<int>(type: "integer", nullable: true),
                    MatterAreaId = table.Column<int>(type: "integer", nullable: true),
                    CourtGeographicalJurisdictionId = table.Column<int>(type: "integer", nullable: true),
                    CourtSittingInCityId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
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
                        name: "FK_Matters_BillingRates_DefaultBillingRateId",
                        column: x => x.DefaultBillingRateId,
                        principalTable: "BillingRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matters_Contacts_BillToContactId",
                        column: x => x.BillToContactId,
                        principalTable: "Contacts",
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
                name: "MatterContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    MatterId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactId = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatterContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatterContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
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
                name: "TaskMatters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaskId = table.Column<int>(type: "integer", nullable: false),
                    MatterId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMatters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskMatters_Matters_MatterId",
                        column: x => x.MatterId,
                        principalTable: "Matters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskMatters_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillingGroups_BillToContactId",
                table: "BillingGroups",
                column: "BillToContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_BillingRateId",
                table: "Contacts",
                column: "BillingRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CivilStatusId",
                table: "Contacts",
                column: "CivilStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CompanyLegalStatusId",
                table: "Contacts",
                column: "CompanyLegalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_IdTypeId",
                table: "Contacts",
                column: "IdTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_MatterTypeId",
                table: "Contacts",
                column: "MatterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MatterContacts_ContactId",
                table: "MatterContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_MatterContacts_MatterId",
                table: "MatterContacts",
                column: "MatterId");

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
                name: "IX_TaskAssignedContacts_ContactId",
                table: "TaskAssignedContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssignedContacts_TaskId",
                table: "TaskAssignedContacts",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMatters_MatterId",
                table: "TaskMatters",
                column: "MatterId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMatters_TaskId",
                table: "TaskMatters",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_SequentialPredecessorId",
                table: "Tasks",
                column: "SequentialPredecessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "MatterContacts");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "TaskAssignedContacts");

            migrationBuilder.DropTable(
                name: "TaskMatters");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Matters");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "BillingGroups");

            migrationBuilder.DropTable(
                name: "CourtGeographicalJurisdictions");

            migrationBuilder.DropTable(
                name: "CourtSittingInCities");

            migrationBuilder.DropTable(
                name: "MatterAreas");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "BillingRates");

            migrationBuilder.DropTable(
                name: "CompanyLegalStatuses");

            migrationBuilder.DropTable(
                name: "ContactCivilStatuses");

            migrationBuilder.DropTable(
                name: "ContactIdTypes");

            migrationBuilder.DropTable(
                name: "MatterTypes");
        }
    }
}
