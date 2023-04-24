using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AdvoSecure.Infrastructure.Persistance.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWrongBillingRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_CompanyLegalStatuses_BillingRateId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CompanyLegalStatuses");

            migrationBuilder.DropColumn(
                name: "PricePerUnit",
                table: "CompanyLegalStatuses");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_BillingRates_BillingRateId",
                table: "Contacts",
                column: "BillingRateId",
                principalTable: "BillingRates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_BillingRates_BillingRateId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "BillingRates");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CompanyLegalStatuses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerUnit",
                table: "CompanyLegalStatuses",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_CompanyLegalStatuses_BillingRateId",
                table: "Contacts",
                column: "BillingRateId",
                principalTable: "CompanyLegalStatuses",
                principalColumn: "Id");
        }
    }
}
