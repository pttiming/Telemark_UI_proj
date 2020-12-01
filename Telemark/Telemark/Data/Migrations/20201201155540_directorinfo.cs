using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class directorinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d53271aa-a7aa-4e0b-8eae-c9c1ed75543f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5e2f4e8-d911-4a37-908e-5d3934eddd59");

            migrationBuilder.AddColumn<int>(
                name: "Director",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "director_id",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Director",
                table: "Info",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "director_id",
                table: "Info",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27b92aed-7ecb-4afb-a7f0-dbdc4623aaf4", "571c13bf-74f4-4069-a36a-9e86b765575b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5dce5135-bc70-4b6f-867c-98093bbd6912", "11de821e-e486-4c45-af94-fcb30bb1bf49", "Director", "DIRECTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Director",
                table: "Locations",
                column: "Director");

            migrationBuilder.CreateIndex(
                name: "IX_Info_Director",
                table: "Info",
                column: "Director");

            migrationBuilder.AddForeignKey(
                name: "FK_Info_Directors_Director",
                table: "Info",
                column: "Director",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Directors_Director",
                table: "Locations",
                column: "Director",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Info_Directors_Director",
                table: "Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Directors_Director",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_Director",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Info_Director",
                table: "Info");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27b92aed-7ecb-4afb-a7f0-dbdc4623aaf4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dce5135-bc70-4b6f-867c-98093bbd6912");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "director_id",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Info");

            migrationBuilder.DropColumn(
                name: "director_id",
                table: "Info");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5e2f4e8-d911-4a37-908e-5d3934eddd59", "f0d46fae-25e4-4e52-9615-e1913284a897", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d53271aa-a7aa-4e0b-8eae-c9c1ed75543f", "ea115caa-af29-43f2-a496-33da9a8f2146", "Director", "DIRECTOR" });
        }
    }
}
