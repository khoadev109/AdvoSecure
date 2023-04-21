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
                        name: "FK_Contacts_ContactCivilStatuses_CivilStatusId",
                        column: x => x.CivilStatusId,
                        principalTable: "ContactCivilStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_ContactIdTypes_IdTypeId",
                        column: x => x.IdTypeId,
                        principalTable: "ContactIdTypes",
                        principalColumn: "Id");
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
                name: "IX_Contacts_BillingRateId",
                table: "Contacts",
                column: "BillingRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CivilStatusId",
                table: "Contacts",
                column: "CivilStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_IdTypeId",
                table: "Contacts",
                column: "IdTypeId");
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
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BillingRates");

            migrationBuilder.DropTable(
                name: "ContactCivilStatuses");

            migrationBuilder.DropTable(
                name: "ContactIdTypes");
        }
    }
}
