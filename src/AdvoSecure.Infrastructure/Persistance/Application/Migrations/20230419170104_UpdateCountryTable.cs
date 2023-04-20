using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvoSecure.Infrastructure.Persistance.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCountryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryName_nl",
                table: "Countries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Countries",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryName_nl",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Countries");
        }
    }
}
