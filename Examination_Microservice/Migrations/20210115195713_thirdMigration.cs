using Microsoft.EntityFrameworkCore.Migrations;

namespace Examination_Microservice.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
               name: "Period_StartDate",
               table: "ExaminationDetails",
               nullable: false,
               defaultValue: false);

            migrationBuilder.AddColumn<bool>(
               name: "Period_EndDate",
               table: "ExaminationDetails",
               nullable: false,
               defaultValue: false);

            migrationBuilder.AddColumn<bool>(
               name: "Period_StartDate",
               table: "Prescription",
               nullable: false,
               defaultValue: false);

            migrationBuilder.AddColumn<bool>(
               name: "Period_EndDate",
               table: "Prescription",
               nullable: false,
               defaultValue: false);

            migrationBuilder.AddColumn<bool>(
             name: "Period_StartDate",
             table: "Referral",
             nullable: false,
             defaultValue: false);

            migrationBuilder.AddColumn<bool>(
               name: "Period_EndDate",
               table: "Referral",
               nullable: false,
               defaultValue: false);


            migrationBuilder.AddColumn<bool>(
             name: "Period_StartDate",
             table: "Therapy",
             nullable: false,
             defaultValue: false);

            migrationBuilder.AddColumn<bool>(
               name: "Period_EndDate",
               table: "Therapy",
               nullable: false,
               defaultValue: false);

            migrationBuilder.AddColumn<bool>(
          name: "Period_StartDate",
          table: "Hospitalization",
          nullable: false,
          defaultValue: false);

            migrationBuilder.AddColumn<bool>(
               name: "Period_EndDate",
               table: "Hospitalization",
               nullable: false,
               defaultValue: false);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
             name: "Period_StartDate",
             table: "ExaminationDetails");
            migrationBuilder.DropColumn(
             name: "Period_EndDate",
             table: "ExaminationDetails");
            migrationBuilder.DropColumn(
             name: "Period_StartDate",
             table: "Prescription");
            migrationBuilder.DropColumn(
             name: "Period_EndDate",
             table: "Prescription");
            migrationBuilder.DropColumn(
             name: "Period_StartDate",
             table: "Referral");
            migrationBuilder.DropColumn(
             name: "Period_EndDate",
             table: "Referral");
            migrationBuilder.DropColumn(
             name: "Period_StartDate",
             table: "Therapy");
            migrationBuilder.DropColumn(
             name: "Period_EndDate",
             table: "Therapy");
            migrationBuilder.DropColumn(
             name: "Period_StartDate",
             table: "Hospitalization");
            migrationBuilder.DropColumn(
             name: "Period_EndDate",
             table: "Hospitalization");
        }
    }
}
