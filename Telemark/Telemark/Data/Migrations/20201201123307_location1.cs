using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class location1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "f5e2f4e8-d911-4a37-908e-5d3934eddd59", "f0d46fae-25e4-4e52-9615-e1913284a897", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d53271aa-a7aa-4e0b-8eae-c9c1ed75543f", "ea115caa-af29-43f2-a496-33da9a8f2146", "Director", "DIRECTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d53271aa-a7aa-4e0b-8eae-c9c1ed75543f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5e2f4e8-d911-4a37-908e-5d3934eddd59");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7476cb16-6f74-4d8c-a822-d7163a4ac707", "bab60f29-4c25-4d05-ab3a-9c4be70c8747", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bbc21345-0c0e-4063-8496-4b5de110bd43", "67f69c95-0623-4596-bef6-84b09b0ac2bb", "Director", "DIRECTOR" });
        }
    }
}
