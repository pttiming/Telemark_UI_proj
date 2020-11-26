using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class directors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Director_AspNetUsers_IdentityUserId",
                table: "Director");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Director",
                table: "Director");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4885d96e-4803-48ea-b656-1a363f6a5a04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e718afe3-7d76-48ef-9119-2491e02e9aa0");

            migrationBuilder.RenameTable(
                name: "Director",
                newName: "Directors");

            migrationBuilder.RenameIndex(
                name: "IX_Director_IdentityUserId",
                table: "Directors",
                newName: "IX_Directors_IdentityUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    race_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    last_date = table.Column<string>(nullable: true),
                    last_end_date = table.Column<string>(nullable: true),
                    next_date = table.Column<string>(nullable: true),
                    next_end_date = table.Column<string>(nullable: true),
                    is_draft_race = table.Column<string>(nullable: true),
                    is_private_race = table.Column<string>(nullable: true),
                    is_registration_open = table.Column<string>(nullable: true),
                    created = table.Column<string>(nullable: true),
                    last_modified = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    external_race_url = table.Column<string>(nullable: true),
                    external_results_url = table.Column<string>(nullable: true),
                    fb_page_id = table.Column<string>(nullable: true),
                    fb_event_id = table.Column<string>(nullable: true),
                    timezone = table.Column<string>(nullable: true),
                    logo_url = table.Column<string>(nullable: true),
                    can_use_registration_api = table.Column<string>(nullable: true),
                    real_time_notifications_enabled = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    race_id = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Address_Race_race_id",
                        column: x => x.race_id,
                        principalTable: "Race",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    race_id = table.Column<int>(nullable: false),
                    event_id = table.Column<int>(nullable: false),
                    race_event_days_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    details = table.Column<string>(nullable: true),
                    start_time = table.Column<string>(nullable: true),
                    end_time = table.Column<string>(nullable: true),
                    age_calc_base_date = table.Column<string>(nullable: true),
                    registration_opens = table.Column<string>(nullable: true),
                    event_type = table.Column<string>(nullable: true),
                    distance = table.Column<string>(nullable: true),
                    volunteer = table.Column<string>(nullable: true),
                    require_dob = table.Column<string>(nullable: true),
                    require_phone = table.Column<string>(nullable: true),
                    giveaway = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.id);
                    table.ForeignKey(
                        name: "FK_Events_Race_race_id",
                        column: x => x.race_id,
                        principalTable: "Race",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    raceid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.id);
                    table.ForeignKey(
                        name: "FK_Races_Race_raceid",
                        column: x => x.raceid,
                        principalTable: "Race",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registration_Periods",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    registration_opens = table.Column<string>(nullable: true),
                    registration_closes = table.Column<string>(nullable: true),
                    race_fee = table.Column<string>(nullable: true),
                    processing_fee = table.Column<string>(nullable: true),
                    Eventid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration_Periods", x => x.id);
                    table.ForeignKey(
                        name: "FK_Registration_Periods_Events_Eventid",
                        column: x => x.Eventid,
                        principalTable: "Events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0b9e899-27f8-44ff-b424-273b074e280d", "603501ad-5a70-4e51-9f09-161aaffd8224", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cab3b5ab-9f9f-4190-9a9e-99bd851e22f3", "e26d078e-445d-4adf-8bfc-4cd3636ae0b5", "Director", "DIRECTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Address_race_id",
                table: "Address",
                column: "race_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_race_id",
                table: "Events",
                column: "race_id");

            migrationBuilder.CreateIndex(
                name: "IX_Races_raceid",
                table: "Races",
                column: "raceid");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_Periods_Eventid",
                table: "Registration_Periods",
                column: "Eventid");

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_AspNetUsers_IdentityUserId",
                table: "Directors",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directors_AspNetUsers_IdentityUserId",
                table: "Directors");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Registration_Periods");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cab3b5ab-9f9f-4190-9a9e-99bd851e22f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0b9e899-27f8-44ff-b424-273b074e280d");

            migrationBuilder.RenameTable(
                name: "Directors",
                newName: "Director");

            migrationBuilder.RenameIndex(
                name: "IX_Directors_IdentityUserId",
                table: "Director",
                newName: "IX_Director_IdentityUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Director",
                table: "Director",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4885d96e-4803-48ea-b656-1a363f6a5a04", "6b8916c1-2f43-4d21-aeed-d8e04ebb6d3f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e718afe3-7d76-48ef-9119-2491e02e9aa0", "a11ff938-642f-4cec-b122-cddf4bbb0d0b", "Director", "DIRECTOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Director_AspNetUsers_IdentityUserId",
                table: "Director",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
