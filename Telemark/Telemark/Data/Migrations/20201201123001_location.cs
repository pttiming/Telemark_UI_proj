using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f263cb2-644b-4fc4-a1e5-b2039f086cc1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc007d36-cd54-4460-96ad-918d94c7ca6e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7476cb16-6f74-4d8c-a822-d7163a4ac707", "bab60f29-4c25-4d05-ab3a-9c4be70c8747", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bbc21345-0c0e-4063-8496-4b5de110bd43", "67f69c95-0623-4596-bef6-84b09b0ac2bb", "Director", "DIRECTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7476cb16-6f74-4d8c-a822-d7163a4ac707");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbc21345-0c0e-4063-8496-4b5de110bd43");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc007d36-cd54-4460-96ad-918d94c7ca6e", "6572ac77-f33e-4290-ad1b-4b33354a611c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f263cb2-644b-4fc4-a1e5-b2039f086cc1", "f7b86976-74a9-495c-8743-45a901aa60aa", "Director", "DIRECTOR" });
        }
    }
}
