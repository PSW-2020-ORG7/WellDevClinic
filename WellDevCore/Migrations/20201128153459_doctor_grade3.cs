using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica.Migrations
{
    public partial class doctor_grade3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Grade",
                table: "gradeDTO",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "gradeDTO",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
