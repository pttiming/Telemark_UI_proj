using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class raceaddress1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dcd51a4-82f9-4a05-8183-655d9ee1a076");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb0a975c-93bd-4e9b-91a5-ed04dc641c43");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "RaceAddress",
                type: "decimal(10, 8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "RaceAddress",
                type: "decimal(11, 8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "081fb6ab-7c5f-469f-8b57-5fa47d77578b", "542ae8b2-d131-436e-884c-440f31164b27", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f060611-40f1-4eee-a5cd-b95ebb2d32d1", "4e9be362-071a-4fce-bf5b-3c9c0ec627cc", "Director", "DIRECTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "081fb6ab-7c5f-469f-8b57-5fa47d77578b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f060611-40f1-4eee-a5cd-b95ebb2d32d1");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "RaceAddress");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "RaceAddress");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb0a975c-93bd-4e9b-91a5-ed04dc641c43", "f07876da-23db-4005-b115-638c58ecec23", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8dcd51a4-82f9-4a05-8183-655d9ee1a076", "9e298b27-7649-4165-a3a1-53fb4be13ae9", "Director", "DIRECTOR" });
        }
    }
}
