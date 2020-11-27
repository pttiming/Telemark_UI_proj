using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class director3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c70cef9-a68c-4061-985f-0fcda1a0f2fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d760680a-216c-42cb-8e51-9e83e892ccfd");

            migrationBuilder.AddColumn<string>(
                name: "real_time_notifications_enabled",
                table: "Races",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "778bf6b1-f638-4fad-846d-ee2ee43e23b5", "593a1f75-d89f-4d8c-84f2-08c6ac35992a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed39b553-76da-4225-8948-bae60d165b05", "c396deca-7a0d-48da-8e4c-17533ee92b74", "Director", "DIRECTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "778bf6b1-f638-4fad-846d-ee2ee43e23b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed39b553-76da-4225-8948-bae60d165b05");

            migrationBuilder.DropColumn(
                name: "real_time_notifications_enabled",
                table: "Races");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d760680a-216c-42cb-8e51-9e83e892ccfd", "6b240e6f-a269-46c5-bf30-0a172bdf022b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c70cef9-a68c-4061-985f-0fcda1a0f2fe", "c6127419-7158-4a9d-8763-6118ac01bb98", "Director", "DIRECTOR" });
        }
    }
}
