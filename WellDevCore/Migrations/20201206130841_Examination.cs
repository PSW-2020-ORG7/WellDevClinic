using Microsoft.EntityFrameworkCore.Migrations;

namespace WellDevCore.Migrations
{
    public partial class Examination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FilledSurvey",
                table: "Examination",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilledSurvey",
                table: "Examination");
        }
    }
}
