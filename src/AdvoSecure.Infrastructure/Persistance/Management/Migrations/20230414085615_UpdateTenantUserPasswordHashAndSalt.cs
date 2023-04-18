using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvoSecure.Infrastructure.Persistance.Management.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTenantUserPasswordHashAndSalt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "TenantUsers",
                newName: "PasswordHash");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "TenantUsers",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "TenantUsers");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "TenantUsers",
                newName: "Password");
        }
    }
}
