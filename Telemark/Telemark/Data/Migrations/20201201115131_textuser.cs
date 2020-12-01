using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class textuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbc5238c-299f-493f-81f2-c65eabbe49e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb3e9fa0-6ac0-4837-a94d-4a17eefb9093");

            migrationBuilder.DropColumn(
                name: "last_request_tem",
                table: "TextUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "last_request_time",
                table: "TextUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: false),
                    race_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_TextUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "TextUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc007d36-cd54-4460-96ad-918d94c7ca6e", "6572ac77-f33e-4290-ad1b-4b33354a611c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f263cb2-644b-4fc4-a1e5-b2039f086cc1", "f7b86976-74a9-495c-8743-45a901aa60aa", "Director", "DIRECTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_user_id",
                table: "Subscriptions",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f263cb2-644b-4fc4-a1e5-b2039f086cc1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc007d36-cd54-4460-96ad-918d94c7ca6e");

            migrationBuilder.DropColumn(
                name: "last_request_time",
                table: "TextUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "last_request_tem",
                table: "TextUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bbc5238c-299f-493f-81f2-c65eabbe49e7", "9cf4458e-d07f-4df5-8b6c-1a3684d681ba", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb3e9fa0-6ac0-4837-a94d-4a17eefb9093", "6c1500a7-c0e0-445d-9485-2c5620c5f936", "Director", "DIRECTOR" });
        }
    }
}
