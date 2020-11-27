using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation",
                table: "Person",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerificationToken",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Validation",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "VerificationToken",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Person",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
