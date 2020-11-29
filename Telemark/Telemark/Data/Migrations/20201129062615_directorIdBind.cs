using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class directorIdBind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a686e80a-6dc4-4407-a2ed-5aff3325537a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b211dbff-5c6c-44d6-9860-623521627b67");

            migrationBuilder.AddColumn<int>(
                name: "director_id",
                table: "Races",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca38b023-d842-400a-9a70-9ff918875586", "7e40ba32-98d8-4738-b1cd-325c85660e52", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd1b1ed3-b935-49ae-a72c-fe6e53762778", "5c612ece-e248-4ee4-9d22-3ac2a3af8d36", "Director", "DIRECTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Races_director_id",
                table: "Races",
                column: "director_id");

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
                name: "FK_Races_Directors_director_id",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_director_id",
                table: "Races");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca38b023-d842-400a-9a70-9ff918875586");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd1b1ed3-b935-49ae-a72c-fe6e53762778");

            migrationBuilder.DropColumn(
                name: "director_id",
                table: "Races");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b211dbff-5c6c-44d6-9860-623521627b67", "72834eda-55bb-4c1f-bc7e-68c60cb54571", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a686e80a-6dc4-4407-a2ed-5aff3325537a", "98c07e47-a425-4256-bb56-680fc63fb214", "Director", "DIRECTOR" });
        }
    }
}
