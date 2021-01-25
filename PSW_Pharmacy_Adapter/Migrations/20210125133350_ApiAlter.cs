using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW_Pharmacy_Adapter.Migrations
{
    public partial class ApiAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "ApiKeys",
                newName: "Url_Url");

            migrationBuilder.AlterColumn<string>(
                name: "ApiKey",
                table: "ApiKeys",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url_Url",
                table: "ApiKeys",
                newName: "Url");

            migrationBuilder.AlterColumn<string>(
                name: "ApiKey",
                table: "ApiKeys",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
