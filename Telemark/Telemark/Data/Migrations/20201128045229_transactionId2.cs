using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class transactionId2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "b211dbff-5c6c-44d6-9860-623521627b67", "72834eda-55bb-4c1f-bc7e-68c60cb54571", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a686e80a-6dc4-4407-a2ed-5aff3325537a", "98c07e47-a425-4256-bb56-680fc63fb214", "Director", "DIRECTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a686e80a-6dc4-4407-a2ed-5aff3325537a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b211dbff-5c6c-44d6-9860-623521627b67");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c239d56-2e9a-4f4d-a9d4-8bf1f7441999", "110bef33-ea80-46b7-977d-92c76e20f2e7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ee29992-b74e-40d9-a3e4-5e8203d35dff", "4d416349-453a-463a-ba8e-e60c1f73dda5", "Director", "DIRECTOR" });
        }
    }
}
