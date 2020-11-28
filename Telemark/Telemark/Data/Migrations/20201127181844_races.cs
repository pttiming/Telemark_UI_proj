using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class races : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Races_race_id",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Directors_director_id",
                table: "Races");

            migrationBuilder.DropTable(
                name: "RaceAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Races_director_id",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Events_race_id",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "778bf6b1-f638-4fad-846d-ee2ee43e23b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed39b553-76da-4225-8948-bae60d165b05");

            migrationBuilder.DropColumn(
                name: "director_id",
                table: "Races");

            migrationBuilder.AlterColumn<long>(
                name: "fb_event_id",
                table: "Races",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "addressid",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "age_calc_base_date",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "giveaway",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "raceid",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "registration_opens",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "require_dob",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "require_phone",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "volunteer",
                table: "Events",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street = table.Column<string>(nullable: true),
                    street2 = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zipcode = table.Column<string>(nullable: true),
                    country_code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RsuRaces",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
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
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    raceid = table.Column<int>(nullable: true),
                    RsuRacesid = table.Column<int>(nullable: true)
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
                values: new object[] { "69766ac1-777c-43c1-8c67-fc8b2471d91b", "c519b453-15d8-42b1-a61c-cc3e450e89de", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05d8875a-21eb-4f7a-b84a-7416aaa59f22", "df2a3576-7139-497c-beea-589cf6876dd6", "Director", "DIRECTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Races_addressid",
                table: "Races",
                column: "addressid");

            migrationBuilder.CreateIndex(
                name: "IX_Events_raceid",
                table: "Events",
                column: "raceid");

            migrationBuilder.CreateIndex(
                name: "IX_RaceObject_RsuRacesid",
                table: "RaceObject",
                column: "RsuRacesid");

            migrationBuilder.CreateIndex(
                name: "IX_RaceObject_raceid",
                table: "RaceObject",
                column: "raceid");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Races_raceid",
                table: "Events",
                column: "raceid",
                principalTable: "Races",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Address_addressid",
                table: "Races",
                column: "addressid",
                principalTable: "Address",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Races_raceid",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Address_addressid",
                table: "Races");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "RaceObject");

            migrationBuilder.DropTable(
                name: "RsuRaces");

            migrationBuilder.DropIndex(
                name: "IX_Races_addressid",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Events_raceid",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05d8875a-21eb-4f7a-b84a-7416aaa59f22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69766ac1-777c-43c1-8c67-fc8b2471d91b");

            migrationBuilder.DropColumn(
                name: "addressid",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "age_calc_base_date",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "giveaway",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "raceid",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "registration_opens",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "require_dob",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "require_phone",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "volunteer",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "fb_event_id",
                table: "Races",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "director_id",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RaceAddresses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    race_id = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    street2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceAddresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_RaceAddresses_Races_race_id",
                        column: x => x.race_id,
                        principalTable: "Races",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "778bf6b1-f638-4fad-846d-ee2ee43e23b5", "593a1f75-d89f-4d8c-84f2-08c6ac35992a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed39b553-76da-4225-8948-bae60d165b05", "c396deca-7a0d-48da-8e4c-17533ee92b74", "Director", "DIRECTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Races_director_id",
                table: "Races",
                column: "director_id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_race_id",
                table: "Events",
                column: "race_id");

            migrationBuilder.CreateIndex(
                name: "IX_RaceAddresses_race_id",
                table: "RaceAddresses",
                column: "race_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Races_race_id",
                table: "Events",
                column: "race_id",
                principalTable: "Races",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Directors_director_id",
                table: "Races",
                column: "director_id",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
