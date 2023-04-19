using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvoSecure.Infrastructure.Persistance.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContactRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PictureBin",
                table: "Contacts",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_BillingRates_BillingRateId",
                table: "Contacts",
                column: "BillingRateId",
                principalTable: "BillingRates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactCivilStatuses_CivilStatusId",
                table: "Contacts",
                column: "CivilStatusId",
                principalTable: "ContactCivilStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactIdTypes_IdTypeId",
                table: "Contacts",
                column: "IdTypeId",
                principalTable: "ContactIdTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_BillingRates_BillingRateId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactCivilStatuses_CivilStatusId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactIdTypes_IdTypeId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_BillingRateId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CivilStatusId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_IdTypeId",
                table: "Contacts");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PictureBin",
                table: "Contacts",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);
        }
    }
}
