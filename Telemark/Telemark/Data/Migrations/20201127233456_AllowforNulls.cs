using Microsoft.EntityFrameworkCore.Migrations;

namespace Telemark.Data.Migrations
{
    public partial class AllowforNulls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33fa09bf-df8b-4b10-97ec-6b1d1476ee23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d75d8eae-acc3-4482-a9b6-382b715a2c13");

            migrationBuilder.AlterColumn<int>(
                name: "team_type_id",
                table: "Participants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "team_id",
                table: "Participants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "last_modified",
                table: "Participants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "bib_num",
                table: "Participants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "Participants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a4174b3-a66d-40a7-bfa1-844ec24f944d", "e32551cb-b265-47fb-8815-c0181dcbbb98", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7dfa4b45-f6bc-4065-834a-4e6b610e70f8", "7e9c264d-9be2-43a3-a0ce-0661e00c0f6d", "Director", "DIRECTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a4174b3-a66d-40a7-bfa1-844ec24f944d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7dfa4b45-f6bc-4065-834a-4e6b610e70f8");

            migrationBuilder.AlterColumn<int>(
                name: "team_type_id",
                table: "Participants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "team_id",
                table: "Participants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "last_modified",
                table: "Participants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "bib_num",
                table: "Participants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "Participants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33fa09bf-df8b-4b10-97ec-6b1d1476ee23", "1720b06d-7da1-419f-962d-d204a5406c67", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d75d8eae-acc3-4482-a9b6-382b715a2c13", "f63dcf35-6286-43dc-99ba-a8566b9c85d5", "Director", "DIRECTOR" });
        }
    }
}
