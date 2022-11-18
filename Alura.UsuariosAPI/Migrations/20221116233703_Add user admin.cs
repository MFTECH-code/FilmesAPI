using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alura.UsuariosAPI.Migrations
{
    public partial class Adduseradmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99999, "818f36d8-4d1e-442f-ba5c-690414198217", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 99999, 0, "6a219bd1-d471-4437-91db-0b3c82ed7842", "admin@email.com", true, false, null, "ADMIN", "ADMIN@EMAIL.COM", "AQAAAAEAACcQAAAAEELgMrNnHOHoJ4AEOvEY3qEgkyEZl/TROgCHi1vHdw8BGrW+uTnDDqS8x/E0QuHtuQ==", null, false, "8f4e4c37-08a2-41c0-8861-1a91b5cb69b3", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 99999, 99999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 99999, 99999 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999);
        }
    }
}
