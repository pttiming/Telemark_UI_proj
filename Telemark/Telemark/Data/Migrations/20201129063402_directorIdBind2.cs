using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class directorIdBind2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca38b023-d842-400a-9a70-9ff918875586");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd1b1ed3-b935-49ae-a72c-fe6e53762778");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31bcfc3d-f01f-47c2-b750-286eb6750725", "af2cec71-540f-4ee1-b09b-f4e97a71a410", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92729399-f7f2-4b26-8b4b-2c828f666176", "ffebf3e5-f00b-4e4b-8986-40b4eef616a5", "Director", "DIRECTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31bcfc3d-f01f-47c2-b750-286eb6750725");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92729399-f7f2-4b26-8b4b-2c828f666176");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca38b023-d842-400a-9a70-9ff918875586", "7e40ba32-98d8-4738-b1cd-325c85660e52", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd1b1ed3-b935-49ae-a72c-fe6e53762778", "5c612ece-e248-4ee4-9d22-3ac2a3af8d36", "Director", "DIRECTOR" });
        }
    }
}
