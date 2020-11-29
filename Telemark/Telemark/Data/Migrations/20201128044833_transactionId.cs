using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class transactionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50c8927e-afa3-43f1-9298-8308c4e0d2bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98366bcc-e18f-4c5a-8a04-c75eade38934");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c239d56-2e9a-4f4d-a9d4-8bf1f7441999", "110bef33-ea80-46b7-977d-92c76e20f2e7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ee29992-b74e-40d9-a3e4-5e8203d35dff", "4d416349-453a-463a-ba8e-e60c1f73dda5", "Director", "DIRECTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c239d56-2e9a-4f4d-a9d4-8bf1f7441999");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ee29992-b74e-40d9-a3e4-5e8203d35dff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "50c8927e-afa3-43f1-9298-8308c4e0d2bc", "a18d08a2-a607-49be-a746-90496389730b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98366bcc-e18f-4c5a-8a04-c75eade38934", "f1354f7b-0473-4102-acd7-6a3e3df24904", "Director", "DIRECTOR" });
        }
    }
}
