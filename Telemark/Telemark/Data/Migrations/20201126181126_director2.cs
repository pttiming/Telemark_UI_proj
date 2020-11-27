using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class director2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Race_race_id",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Race_raceid",
                table: "Races");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Registration_Periods");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropIndex(
                name: "IX_Races_raceid",
                table: "Races");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cab3b5ab-9f9f-4190-9a9e-99bd851e22f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0b9e899-27f8-44ff-b424-273b074e280d");

            migrationBuilder.DropColumn(
                name: "raceid",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "age_calc_base_date",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "giveaway",
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

            migrationBuilder.AddColumn<string>(
                name: "created",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "director_id",
                table: "Races",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "external_race_url",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "external_results_url",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fb_event_id",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fb_page_id",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "is_draft_race",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "is_private_race",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "is_registration_open",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "last_date",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "last_end_date",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "last_modified",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "logo_url",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "next_date",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "next_end_date",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "race_id",
                table: "Races",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "timezone",
                table: "Races",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "Races",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RaceAddresses",
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
                    table.PrimaryKey("PK_RaceAddresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_RaceAddresses_Races_race_id",
                        column: x => x.race_id,
                        principalTable: "Races",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextUsers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullNumber = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    participant_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextUsers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: false),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    dob = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: false),
                    userid = table.Column<int>(nullable: true),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    dob = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    registration_id = table.Column<int>(nullable: false),
                    event_id = table.Column<int>(nullable: false),
                    bib_num = table.Column<int>(nullable: false),
                    chip_num = table.Column<string>(nullable: true),
                    age = table.Column<int>(nullable: false),
                    registration_date = table.Column<string>(nullable: true),
                    team_id = table.Column<int>(nullable: false),
                    team_name = table.Column<string>(nullable: true),
                    team_type_id = table.Column<int>(nullable: false),
                    team_type = table.Column<string>(nullable: true),
                    team_gender = table.Column<string>(nullable: true),
                    team_bib_num = table.Column<string>(nullable: true),
                    last_modified = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.id);
                    table.ForeignKey(
                        name: "FK_Participants_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d760680a-216c-42cb-8e51-9e83e892ccfd", "6b240e6f-a269-46c5-bf30-0a172bdf022b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c70cef9-a68c-4061-985f-0fcda1a0f2fe", "c6127419-7158-4a9d-8763-6118ac01bb98", "Director", "DIRECTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Races_director_id",
                table: "Races",
                column: "director_id");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_userid",
                table: "Participants",
                column: "userid");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Races_race_id",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Directors_director_id",
                table: "Races");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "RaceAddresses");

            migrationBuilder.DropTable(
                name: "TextUsers");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Races_director_id",
                table: "Races");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c70cef9-a68c-4061-985f-0fcda1a0f2fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d760680a-216c-42cb-8e51-9e83e892ccfd");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "director_id",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "external_race_url",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "external_results_url",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "fb_event_id",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "fb_page_id",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "is_draft_race",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "is_private_race",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "is_registration_open",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "last_date",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "last_end_date",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "last_modified",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "logo_url",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "next_date",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "next_end_date",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "race_id",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "timezone",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "url",
                table: "Races");

            migrationBuilder.AddColumn<int>(
                name: "raceid",
                table: "Races",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "age_calc_base_date",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "giveaway",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "registration_opens",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "require_dob",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "require_phone",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "volunteer",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    can_use_registration_api = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    external_race_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    external_results_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fb_event_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fb_page_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_draft_race = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_private_race = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_registration_open = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_end_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_modified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logo_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    next_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    next_end_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    race_id = table.Column<int>(type: "int", nullable: false),
                    real_time_notifications_enabled = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timezone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Registration_Periods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eventid = table.Column<int>(type: "int", nullable: true),
                    processing_fee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    race_fee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registration_closes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registration_opens = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Address",
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
                    table.PrimaryKey("PK_Address", x => x.id);
                    table.ForeignKey(
                        name: "FK_Address_Race_race_id",
                        column: x => x.race_id,
                        principalTable: "Race",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Races_raceid",
                table: "Races",
                column: "raceid");

            migrationBuilder.CreateIndex(
                name: "IX_Address_race_id",
                table: "Address",
                column: "race_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registration_Periods_Eventid",
                table: "Registration_Periods",
                column: "Eventid");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Race_race_id",
                table: "Events",
                column: "race_id",
                principalTable: "Race",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Race_raceid",
                table: "Races",
                column: "raceid",
                principalTable: "Race",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
