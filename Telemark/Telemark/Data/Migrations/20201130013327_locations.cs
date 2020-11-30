using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class locations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31bcfc3d-f01f-47c2-b750-286eb6750725");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92729399-f7f2-4b26-8b4b-2c828f666176");

            migrationBuilder.AddColumn<int>(
                name: "race_id",
                table: "TextUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    race_id = table.Column<int>(nullable: false),
                    raceid = table.Column<int>(nullable: true),
                    keyword = table.Column<string>(nullable: true),
                    information = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.id);
                    table.ForeignKey(
                        name: "FK_Info_Races_raceid",
                        column: x => x.raceid,
                        principalTable: "Races",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    race_id = table.Column<int>(nullable: false),
                    LocationtName = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(10, 8)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(11, 8)", nullable: false),
                    Keyword = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Races_race_id",
                        column: x => x.race_id,
                        principalTable: "Races",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb0a975c-93bd-4e9b-91a5-ed04dc641c43", "f07876da-23db-4005-b115-638c58ecec23", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8dcd51a4-82f9-4a05-8183-655d9ee1a076", "9e298b27-7649-4165-a3a1-53fb4be13ae9", "Director", "DIRECTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Info_raceid",
                table: "Info",
                column: "raceid");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_race_id",
                table: "Locations",
                column: "race_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Info");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dcd51a4-82f9-4a05-8183-655d9ee1a076");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb0a975c-93bd-4e9b-91a5-ed04dc641c43");

            migrationBuilder.DropColumn(
                name: "race_id",
                table: "TextUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31bcfc3d-f01f-47c2-b750-286eb6750725", "af2cec71-540f-4ee1-b09b-f4e97a71a410", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92729399-f7f2-4b26-8b4b-2c828f666176", "ffebf3e5-f00b-4e4b-8986-40b4eef616a5", "Director", "DIRECTOR" });
        }
    }
}
