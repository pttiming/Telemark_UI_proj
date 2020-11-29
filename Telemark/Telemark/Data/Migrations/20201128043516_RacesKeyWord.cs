using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class RacesKeyWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87d7f458-9eee-4ddf-aa7f-bd6bb82507bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ca323fa-f83f-40ab-94ee-1b9eed39fde6");

            migrationBuilder.AddColumn<string>(
                name: "current_race",
                table: "TextUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_participant",
                table: "TextUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "last_request",
                table: "TextUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_request_tem",
                table: "TextUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Keyword",
                table: "Races",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "50c8927e-afa3-43f1-9298-8308c4e0d2bc", "a18d08a2-a607-49be-a746-90496389730b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98366bcc-e18f-4c5a-8a04-c75eade38934", "f1354f7b-0473-4102-acd7-6a3e3df24904", "Director", "DIRECTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50c8927e-afa3-43f1-9298-8308c4e0d2bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98366bcc-e18f-4c5a-8a04-c75eade38934");

            migrationBuilder.DropColumn(
                name: "current_race",
                table: "TextUsers");

            migrationBuilder.DropColumn(
                name: "is_participant",
                table: "TextUsers");

            migrationBuilder.DropColumn(
                name: "last_request",
                table: "TextUsers");

            migrationBuilder.DropColumn(
                name: "last_request_tem",
                table: "TextUsers");

            migrationBuilder.DropColumn(
                name: "Keyword",
                table: "Races");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87d7f458-9eee-4ddf-aa7f-bd6bb82507bf", "e788a050-f502-4b19-9304-8cad5ba1b418", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ca323fa-f83f-40ab-94ee-1b9eed39fde6", "4aa89e30-0571-48b7-ace0-e890d2e1768d", "Director", "DIRECTOR" });
        }
    }
}
