using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alura.UsuariosAPI.Migrations
{
    public partial class Adicionandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "263904bd-a6f1-4665-87ed-2f93772f9b67");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "99e53fc3-60b3-45d4-92ac-884361546401", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8ac0e7b-ff82-4be4-ad74-6a76c6edfa09", "AQAAAAEAACcQAAAAECOOb8JcDglsejnhdvpZAHa3eJBXaS55oQctVtpOZbuh1esyFIBoXPfmimWpd1jjMg==", "81a6c1ae-a81c-4861-9ac6-2bc7689f4295" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5e49ede-6272-4fc0-bcfd-ec68ed1ffecb", "AQAAAAEAACcQAAAAEDHiDEwQqi6tncbuGYmoahYmxDHL7E6qM51Q2coP5GQmWdW9vUz/iD3MMSr3iZR5Rg==", "6b7b1342-be98-4273-9c72-6d0bf996398e" });
        }
    }
}
