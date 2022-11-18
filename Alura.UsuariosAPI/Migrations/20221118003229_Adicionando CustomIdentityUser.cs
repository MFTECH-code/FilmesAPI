using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alura.UsuariosAPI.Migrations
{
    public partial class AdicionandoCustomIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "84f11f3d-8b7a-448d-8bbc-8e3d020ee4c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "3cd5d30a-9964-4806-844d-5c64b4b5e33c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fcdca20-8ea3-4614-b02d-a5a92fc89315", "AQAAAAEAACcQAAAAEKAwFBsabSkWs32R0ieLexQQct+IEBWz6rVT5+mgTe7ot5oO9Gp7fxUnyAIbwbG90w==", "7bdcd796-3b02-427b-8011-8d2da2a79c31" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "99e53fc3-60b3-45d4-92ac-884361546401");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "263904bd-a6f1-4665-87ed-2f93772f9b67");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8ac0e7b-ff82-4be4-ad74-6a76c6edfa09", "AQAAAAEAACcQAAAAECOOb8JcDglsejnhdvpZAHa3eJBXaS55oQctVtpOZbuh1esyFIBoXPfmimWpd1jjMg==", "81a6c1ae-a81c-4861-9ac6-2bc7689f4295" });
        }
    }
}
