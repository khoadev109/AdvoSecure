using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvoSecure.Infrastructure.Persistance.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddContactLegalStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_BillingRates_BillingRateId",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillingRates",
                table: "BillingRates");

            migrationBuilder.RenameTable(
                name: "BillingRates",
                newName: "CompanyLegalStatuses");

            migrationBuilder.AddColumn<int>(
                name: "CompanyLegalStatusId",
                table: "Contacts",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerUnit",
                table: "CompanyLegalStatuses",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CompanyLegalStatuses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyLegalStatuses",
                table: "CompanyLegalStatuses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CompanyLegalStatusId",
                table: "Contacts",
                column: "CompanyLegalStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_CompanyLegalStatuses_BillingRateId",
                table: "Contacts",
                column: "BillingRateId",
                principalTable: "CompanyLegalStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_CompanyLegalStatuses_CompanyLegalStatusId",
                table: "Contacts",
                column: "CompanyLegalStatusId",
                principalTable: "CompanyLegalStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_CompanyLegalStatuses_BillingRateId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_CompanyLegalStatuses_CompanyLegalStatusId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CompanyLegalStatusId",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyLegalStatuses",
                table: "CompanyLegalStatuses");

            migrationBuilder.DropColumn(
                name: "CompanyLegalStatusId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CompanyLegalStatuses");

            migrationBuilder.RenameTable(
                name: "CompanyLegalStatuses",
                newName: "BillingRates");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerUnit",
                table: "BillingRates",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillingRates",
                table: "BillingRates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_BillingRates_BillingRateId",
                table: "Contacts",
                column: "BillingRateId",
                principalTable: "BillingRates",
                principalColumn: "Id");
        }
    }
}
