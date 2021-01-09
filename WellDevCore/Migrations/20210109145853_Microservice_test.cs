using Microsoft.EntityFrameworkCore.Migrations;

namespace WellDevCore.Migrations
{
    public partial class Microservice_test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilledSurvey",
                table: "Examination");

            migrationBuilder.EnsureSchema(
                name: "newmydb");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Town",
                newName: "Town",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Therapy",
                newName: "Therapy",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Symptom",
                newName: "Symptom",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "State",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Speciality",
                newName: "Speciality",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "SecretaryReportDTO",
                newName: "SecretaryReportDTO",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "RoomType",
                newName: "RoomType",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "RoomOccupationReportDTO",
                newName: "RoomOccupationReportDTO",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Room",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Renovation",
                newName: "Renovation",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Referral",
                newName: "Referral",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Prescription",
                newName: "Prescription",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Period",
                newName: "Period",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "PatientNotification",
                newName: "PatientNotification",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "PatientFile",
                newName: "PatientFile",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Operation",
                newName: "Operation",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "NotifyDoctorBusinessDay",
                newName: "NotifyDoctorBusinessDay",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Ingredient",
                newName: "Ingredient",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Hospitalization",
                newName: "Hospitalization",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "gradeDTO",
                newName: "gradeDTO",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Feedback",
                newName: "Feedback",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "ExaminationDTO",
                newName: "ExaminationDTO",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Examination",
                newName: "Examination",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "EquipmentDTO",
                newName: "EquipmentDTO",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Equipment",
                newName: "Equipment",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Drug",
                newName: "Drug",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "DoctorReportDTO",
                newName: "DoctorReportDTO",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "DoctorGrade",
                newName: "DoctorGrade",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Diagnosis",
                newName: "Diagnosis",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "BusinessDayDTO",
                newName: "BusinessDayDTO",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "BusinessDay",
                newName: "BusinessDay",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Article",
                newName: "Article",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Anemnesis",
                newName: "Anemnesis",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Allergy",
                newName: "Allergy",
                newSchema: "newmydb");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Address",
                newSchema: "newmydb");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                schema: "newmydb",
                table: "BusinessDayDTO",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                schema: "newmydb",
                table: "BusinessDayDTO");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "newmydb",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Town",
                schema: "newmydb",
                newName: "Town");

            migrationBuilder.RenameTable(
                name: "Therapy",
                schema: "newmydb",
                newName: "Therapy");

            migrationBuilder.RenameTable(
                name: "Symptom",
                schema: "newmydb",
                newName: "Symptom");

            migrationBuilder.RenameTable(
                name: "State",
                schema: "newmydb",
                newName: "State");

            migrationBuilder.RenameTable(
                name: "Speciality",
                schema: "newmydb",
                newName: "Speciality");

            migrationBuilder.RenameTable(
                name: "SecretaryReportDTO",
                schema: "newmydb",
                newName: "SecretaryReportDTO");

            migrationBuilder.RenameTable(
                name: "RoomType",
                schema: "newmydb",
                newName: "RoomType");

            migrationBuilder.RenameTable(
                name: "RoomOccupationReportDTO",
                schema: "newmydb",
                newName: "RoomOccupationReportDTO");

            migrationBuilder.RenameTable(
                name: "Room",
                schema: "newmydb",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Renovation",
                schema: "newmydb",
                newName: "Renovation");

            migrationBuilder.RenameTable(
                name: "Referral",
                schema: "newmydb",
                newName: "Referral");

            migrationBuilder.RenameTable(
                name: "Prescription",
                schema: "newmydb",
                newName: "Prescription");

            migrationBuilder.RenameTable(
                name: "Period",
                schema: "newmydb",
                newName: "Period");

            migrationBuilder.RenameTable(
                name: "PatientNotification",
                schema: "newmydb",
                newName: "PatientNotification");

            migrationBuilder.RenameTable(
                name: "PatientFile",
                schema: "newmydb",
                newName: "PatientFile");

            migrationBuilder.RenameTable(
                name: "Operation",
                schema: "newmydb",
                newName: "Operation");

            migrationBuilder.RenameTable(
                name: "NotifyDoctorBusinessDay",
                schema: "newmydb",
                newName: "NotifyDoctorBusinessDay");

            migrationBuilder.RenameTable(
                name: "Ingredient",
                schema: "newmydb",
                newName: "Ingredient");

            migrationBuilder.RenameTable(
                name: "Hospitalization",
                schema: "newmydb",
                newName: "Hospitalization");

            migrationBuilder.RenameTable(
                name: "gradeDTO",
                schema: "newmydb",
                newName: "gradeDTO");

            migrationBuilder.RenameTable(
                name: "Feedback",
                schema: "newmydb",
                newName: "Feedback");

            migrationBuilder.RenameTable(
                name: "ExaminationDTO",
                schema: "newmydb",
                newName: "ExaminationDTO");

            migrationBuilder.RenameTable(
                name: "Examination",
                schema: "newmydb",
                newName: "Examination");

            migrationBuilder.RenameTable(
                name: "EquipmentDTO",
                schema: "newmydb",
                newName: "EquipmentDTO");

            migrationBuilder.RenameTable(
                name: "Equipment",
                schema: "newmydb",
                newName: "Equipment");

            migrationBuilder.RenameTable(
                name: "Drug",
                schema: "newmydb",
                newName: "Drug");

            migrationBuilder.RenameTable(
                name: "DoctorReportDTO",
                schema: "newmydb",
                newName: "DoctorReportDTO");

            migrationBuilder.RenameTable(
                name: "DoctorGrade",
                schema: "newmydb",
                newName: "DoctorGrade");

            migrationBuilder.RenameTable(
                name: "Diagnosis",
                schema: "newmydb",
                newName: "Diagnosis");

            migrationBuilder.RenameTable(
                name: "BusinessDayDTO",
                schema: "newmydb",
                newName: "BusinessDayDTO");

            migrationBuilder.RenameTable(
                name: "BusinessDay",
                schema: "newmydb",
                newName: "BusinessDay");

            migrationBuilder.RenameTable(
                name: "Article",
                schema: "newmydb",
                newName: "Article");

            migrationBuilder.RenameTable(
                name: "Anemnesis",
                schema: "newmydb",
                newName: "Anemnesis");

            migrationBuilder.RenameTable(
                name: "Allergy",
                schema: "newmydb",
                newName: "Allergy");

            migrationBuilder.RenameTable(
                name: "Address",
                schema: "newmydb",
                newName: "Address");

            migrationBuilder.AddColumn<bool>(
                name: "FilledSurvey",
                table: "Examination",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
