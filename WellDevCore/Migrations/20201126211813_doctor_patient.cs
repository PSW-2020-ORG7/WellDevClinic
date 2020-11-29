using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica.Migrations
{
    public partial class doctor_patient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Person_DoctorId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessDay_Person_doctorId",
                table: "BusinessDay");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessDayDTO_Person_DoctorId",
                table: "BusinessDayDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorReportDTO_Person_PatientId",
                table: "DoctorReportDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_Examination_Person_DoctorId",
                table: "Examination");

            migrationBuilder.DropForeignKey(
                name: "FK_Examination_Person_UserId",
                table: "Examination");

            migrationBuilder.DropForeignKey(
                name: "FK_ExaminationDTO_Person_DoctorId",
                table: "ExaminationDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_ExaminationDTO_Person_PatientId",
                table: "ExaminationDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitalization_Person_DoctorId",
                table: "Hospitalization");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitalization_Person_PatientId",
                table: "Hospitalization");

            migrationBuilder.DropForeignKey(
                name: "FK_Operation_Person_DoctorId",
                table: "Operation");

            migrationBuilder.DropForeignKey(
                name: "FK_Operation_Person_PatientId",
                table: "Operation");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientNotification_Person_PatientId",
                table: "PatientNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_DoctorGrade_DoctorGradeId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Speciality_SpecialtyId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_PatientFile_patientFileId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Address_AddressId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Referral_Person_DoctorId",
                table: "Referral");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Person_AddressId",
                table: "User",
                newName: "IX_User_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_patientFileId",
                table: "User",
                newName: "IX_User_patientFileId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_SpecialtyId",
                table: "User",
                newName: "IX_User_SpecialtyId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_DoctorGradeId",
                table: "User",
                newName: "IX_User_DoctorGradeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_User_DoctorId",
                table: "Article",
                column: "DoctorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessDay_User_doctorId",
                table: "BusinessDay",
                column: "doctorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessDayDTO_User_DoctorId",
                table: "BusinessDayDTO",
                column: "DoctorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorReportDTO_User_PatientId",
                table: "DoctorReportDTO",
                column: "PatientId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_User_DoctorId",
                table: "Examination",
                column: "DoctorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_User_UserId",
                table: "Examination",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExaminationDTO_User_DoctorId",
                table: "ExaminationDTO",
                column: "DoctorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExaminationDTO_User_PatientId",
                table: "ExaminationDTO",
                column: "PatientId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitalization_User_DoctorId",
                table: "Hospitalization",
                column: "DoctorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitalization_User_PatientId",
                table: "Hospitalization",
                column: "PatientId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_User_DoctorId",
                table: "Operation",
                column: "DoctorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_User_PatientId",
                table: "Operation",
                column: "PatientId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientNotification_User_PatientId",
                table: "PatientNotification",
                column: "PatientId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Referral_User_DoctorId",
                table: "Referral",
                column: "DoctorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_DoctorGrade_DoctorGradeId",
                table: "User",
                column: "DoctorGradeId",
                principalTable: "DoctorGrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Speciality_SpecialtyId",
                table: "User",
                column: "SpecialtyId",
                principalTable: "Speciality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_PatientFile_patientFileId",
                table: "User",
                column: "patientFileId",
                principalTable: "PatientFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Address_AddressId",
                table: "User",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_User_DoctorId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessDay_User_doctorId",
                table: "BusinessDay");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessDayDTO_User_DoctorId",
                table: "BusinessDayDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorReportDTO_User_PatientId",
                table: "DoctorReportDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_Examination_User_DoctorId",
                table: "Examination");

            migrationBuilder.DropForeignKey(
                name: "FK_Examination_User_UserId",
                table: "Examination");

            migrationBuilder.DropForeignKey(
                name: "FK_ExaminationDTO_User_DoctorId",
                table: "ExaminationDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_ExaminationDTO_User_PatientId",
                table: "ExaminationDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitalization_User_DoctorId",
                table: "Hospitalization");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitalization_User_PatientId",
                table: "Hospitalization");

            migrationBuilder.DropForeignKey(
                name: "FK_Operation_User_DoctorId",
                table: "Operation");

            migrationBuilder.DropForeignKey(
                name: "FK_Operation_User_PatientId",
                table: "Operation");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientNotification_User_PatientId",
                table: "PatientNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_Referral_User_DoctorId",
                table: "Referral");

            migrationBuilder.DropForeignKey(
                name: "FK_User_DoctorGrade_DoctorGradeId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Speciality_SpecialtyId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_PatientFile_patientFileId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Address_AddressId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Person");

            migrationBuilder.RenameIndex(
                name: "IX_User_AddressId",
                table: "Person",
                newName: "IX_Person_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_User_patientFileId",
                table: "Person",
                newName: "IX_Person_patientFileId");

            migrationBuilder.RenameIndex(
                name: "IX_User_SpecialtyId",
                table: "Person",
                newName: "IX_Person_SpecialtyId");

            migrationBuilder.RenameIndex(
                name: "IX_User_DoctorGradeId",
                table: "Person",
                newName: "IX_Person_DoctorGradeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Person_DoctorId",
                table: "Article",
                column: "DoctorId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessDay_Person_doctorId",
                table: "BusinessDay",
                column: "doctorId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessDayDTO_Person_DoctorId",
                table: "BusinessDayDTO",
                column: "DoctorId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorReportDTO_Person_PatientId",
                table: "DoctorReportDTO",
                column: "PatientId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_Person_DoctorId",
                table: "Examination",
                column: "DoctorId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_Person_UserId",
                table: "Examination",
                column: "UserId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExaminationDTO_Person_DoctorId",
                table: "ExaminationDTO",
                column: "DoctorId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExaminationDTO_Person_PatientId",
                table: "ExaminationDTO",
                column: "PatientId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitalization_Person_DoctorId",
                table: "Hospitalization",
                column: "DoctorId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitalization_Person_PatientId",
                table: "Hospitalization",
                column: "PatientId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_Person_DoctorId",
                table: "Operation",
                column: "DoctorId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Operation_Person_PatientId",
                table: "Operation",
                column: "PatientId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientNotification_Person_PatientId",
                table: "PatientNotification",
                column: "PatientId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_DoctorGrade_DoctorGradeId",
                table: "Person",
                column: "DoctorGradeId",
                principalTable: "DoctorGrade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Speciality_SpecialtyId",
                table: "Person",
                column: "SpecialtyId",
                principalTable: "Speciality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PatientFile_patientFileId",
                table: "Person",
                column: "patientFileId",
                principalTable: "PatientFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Address_AddressId",
                table: "Person",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Referral_Person_DoctorId",
                table: "Referral",
                column: "DoctorId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
