using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alura.UsuariosAPI.Migrations
{
    public partial class Fixusername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "aff80f64-3e4d-4355-943f-93cc3077ab71");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5e49ede-6272-4fc0-bcfd-ec68ed1ffecb", "ADMIN@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEDHiDEwQqi6tncbuGYmoahYmxDHL7E6qM51Q2coP5GQmWdW9vUz/iD3MMSr3iZR5Rg==", "6b7b1342-be98-4273-9c72-6d0bf996398e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "818f36d8-4d1e-442f-ba5c-690414198217");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a219bd1-d471-4437-91db-0b3c82ed7842", "ADMIN", "ADMIN@EMAIL.COM", "AQAAAAEAACcQAAAAEELgMrNnHOHoJ4AEOvEY3qEgkyEZl/TROgCHi1vHdw8BGrW+uTnDDqS8x/E0QuHtuQ==", "8f4e4c37-08a2-41c0-8861-1a91b5cb69b3" });
        }
    }
}
