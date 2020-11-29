using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica.Migrations
{
    public partial class doctor_grade2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
           
            migrationBuilder.AddColumn<string>(
                name: "Doctor",
                table: "DoctorGrade",
                nullable: true);

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "Doctor",
                table: "DoctorGrade");

          
           
        }
    }
}
