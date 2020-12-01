using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class raceaddress2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceAddress_Races_race_id",
                table: "RaceAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceAddress",
                table: "RaceAddress");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "081fb6ab-7c5f-469f-8b57-5fa47d77578b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f060611-40f1-4eee-a5cd-b95ebb2d32d1");

            migrationBuilder.RenameTable(
                name: "RaceAddress",
                newName: "RaceAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_RaceAddress_race_id",
                table: "RaceAddresses",
                newName: "IX_RaceAddresses_race_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceAddresses",
                table: "RaceAddresses",
                column: "id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bbc5238c-299f-493f-81f2-c65eabbe49e7", "9cf4458e-d07f-4df5-8b6c-1a3684d681ba", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb3e9fa0-6ac0-4837-a94d-4a17eefb9093", "6c1500a7-c0e0-445d-9485-2c5620c5f936", "Director", "DIRECTOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_RaceAddresses_Races_race_id",
                table: "RaceAddresses",
                column: "race_id",
                principalTable: "Races",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceAddresses_Races_race_id",
                table: "RaceAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceAddresses",
                table: "RaceAddresses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbc5238c-299f-493f-81f2-c65eabbe49e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb3e9fa0-6ac0-4837-a94d-4a17eefb9093");

            migrationBuilder.RenameTable(
                name: "RaceAddresses",
                newName: "RaceAddress");

            migrationBuilder.RenameIndex(
                name: "IX_RaceAddresses_race_id",
                table: "RaceAddress",
                newName: "IX_RaceAddress_race_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceAddress",
                table: "RaceAddress",
                column: "id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "081fb6ab-7c5f-469f-8b57-5fa47d77578b", "542ae8b2-d131-436e-884c-440f31164b27", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f060611-40f1-4eee-a5cd-b95ebb2d32d1", "4e9be362-071a-4fce-bf5b-3c9c0ec627cc", "Director", "DIRECTOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_RaceAddress_Races_race_id",
                table: "RaceAddress",
                column: "race_id",
                principalTable: "Races",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
