using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class RaceAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_User_userid",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Address_addressid",
                table: "Races");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Races_addressid",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Participants_userid",
                table: "Participants");

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
                name: "user_id",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Participants");

            migrationBuilder.AddColumn<int>(
                name: "race_id",
                table: "Participants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "raceid",
                table: "Participants",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RaceAddress",
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
                    table.PrimaryKey("PK_RaceAddress", x => x.id);
                    table.ForeignKey(
                        name: "FK_RaceAddress_Races_race_id",
                        column: x => x.race_id,
                        principalTable: "Races",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33fa09bf-df8b-4b10-97ec-6b1d1476ee23", "1720b06d-7da1-419f-962d-d204a5406c67", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d75d8eae-acc3-4482-a9b6-382b715a2c13", "f63dcf35-6286-43dc-99ba-a8566b9c85d5", "Director", "DIRECTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_event_id",
                table: "Participants",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_raceid",
                table: "Participants",
                column: "raceid");

            migrationBuilder.CreateIndex(
                name: "IX_RaceAddress_race_id",
                table: "RaceAddress",
                column: "race_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Events_event_id",
                table: "Participants",
                column: "event_id",
                principalTable: "Events",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Races_raceid",
                table: "Participants",
                column: "raceid",
                principalTable: "Races",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Events_event_id",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Races_raceid",
                table: "Participants");

            migrationBuilder.DropTable(
                name: "RaceAddress");

            migrationBuilder.DropIndex(
                name: "IX_Participants_event_id",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_raceid",
                table: "Participants");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33fa09bf-df8b-4b10-97ec-6b1d1476ee23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d75d8eae-acc3-4482-a9b6-382b715a2c13");

            migrationBuilder.DropColumn(
                name: "race_id",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "raceid",
                table: "Participants");

            migrationBuilder.AddColumn<int>(
                name: "addressid",
                table: "Races",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "Participants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Participants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    street2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
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
                name: "IX_Participants_userid",
                table: "Participants",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_User_userid",
                table: "Participants",
                column: "userid",
                principalTable: "User",
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
    }
}
