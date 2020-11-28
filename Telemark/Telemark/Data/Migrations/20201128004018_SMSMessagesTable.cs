using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class SMSMessagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceObject");

            migrationBuilder.DropTable(
                name: "RsuRaces");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a4174b3-a66d-40a7-bfa1-844ec24f944d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dfa4b45-f6bc-4065-834a-4e6b610e70f8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "903a8e98-750d-4d77-b22d-67f3b3e90246", "839f1bc5-e818-42ba-842c-3a9b9af83439", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "195fb7d7-90a8-4216-8cd4-0af6edffe4af", "41c05c74-0ace-4f44-8122-ee3f30185d92", "Director", "DIRECTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "RsuRaces",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RsuRaces", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RaceObject",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RsuRacesid = table.Column<int>(type: "int", nullable: true),
                    raceid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceObject", x => x.id);
                    table.ForeignKey(
                        name: "FK_RaceObject_RsuRaces_RsuRacesid",
                        column: x => x.RsuRacesid,
                        principalTable: "RsuRaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaceObject_Races_raceid",
                        column: x => x.raceid,
                        principalTable: "Races",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a4174b3-a66d-40a7-bfa1-844ec24f944d", "e32551cb-b265-47fb-8815-c0181dcbbb98", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7dfa4b45-f6bc-4065-834a-4e6b610e70f8", "7e9c264d-9be2-43a3-a0ce-0661e00c0f6d", "Director", "DIRECTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_RaceObject_RsuRacesid",
                table: "RaceObject",
                column: "RsuRacesid");

            migrationBuilder.CreateIndex(
                name: "IX_RaceObject_raceid",
                table: "RaceObject",
                column: "raceid");
        }
    }
}
