using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdvoSecureTenant.Core.Persistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenantBases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantBases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantBillings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BillingFirmName = table.Column<string>(type: "text", nullable: false),
                    BillingFirmAddress = table.Column<string>(type: "text", nullable: false),
                    BillingFirmAddress2 = table.Column<string>(type: "text", nullable: false),
                    BillingFirmCity = table.Column<string>(type: "text", nullable: false),
                    BillingFirmState = table.Column<string>(type: "text", nullable: false),
                    BillingFirmZip = table.Column<string>(type: "text", nullable: false),
                    BillingFirmCountry = table.Column<string>(type: "text", nullable: false),
                    BillingFirmPhone = table.Column<string>(type: "text", nullable: false),
                    BillingFirmWeb = table.Column<string>(type: "text", nullable: false),
                    BillingFirmVATid = table.Column<string>(type: "text", nullable: false),
                    BillingFirmBankAccount = table.Column<string>(type: "text", nullable: false),
                    BillingFirmBankBIC = table.Column<string>(type: "text", nullable: false),
                    BillingFirmBankName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantBillings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BaseId = table.Column<int>(type: "integer", nullable: false),
                    TenantId = table.Column<int>(type: "integer", nullable: false),
                    ZoneId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMappings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SchemaName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AzureTenantId = table.Column<string>(type: "text", nullable: false),
                    ConnectionString = table.Column<string>(type: "text", nullable: false),
                    AdminTenantId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdminTenantId = table.Column<int>(type: "integer", nullable: false),
                    AvailableTenants = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantBases");

            migrationBuilder.DropTable(
                name: "TenantBillings");

            migrationBuilder.DropTable(
                name: "TenantMappings");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "TenantSettings");

            migrationBuilder.DropTable(
                name: "Zones");
        }
    }
}
