using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class SMSMessagesTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "195fb7d7-90a8-4216-8cd4-0af6edffe4af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "903a8e98-750d-4d77-b22d-67f3b3e90246");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Recevied = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87d7f458-9eee-4ddf-aa7f-bd6bb82507bf", "e788a050-f502-4b19-9304-8cad5ba1b418", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ca323fa-f83f-40ab-94ee-1b9eed39fde6", "4aa89e30-0571-48b7-ace0-e890d2e1768d", "Director", "DIRECTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87d7f458-9eee-4ddf-aa7f-bd6bb82507bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ca323fa-f83f-40ab-94ee-1b9eed39fde6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "903a8e98-750d-4d77-b22d-67f3b3e90246", "839f1bc5-e818-42ba-842c-3a9b9af83439", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "195fb7d7-90a8-4216-8cd4-0af6edffe4af", "41c05c74-0ace-4f44-8122-ee3f30185d92", "Director", "DIRECTOR" });
        }
    }
}
