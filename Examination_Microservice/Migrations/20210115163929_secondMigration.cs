using Microsoft.EntityFrameworkCore.Migrations;

namespace Examination_Microservice.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FilledSurvey",
                table: "ExaminationDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ReferralId",
                table: "ExaminationDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationDetails_ReferralId",
                table: "ExaminationDetails",
                column: "ReferralId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExaminationDetails_Referral_ReferralId",
                table: "ExaminationDetails",
                column: "ReferralId",
                principalTable: "Referral",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExaminationDetails_Referral_ReferralId",
                table: "ExaminationDetails");

            migrationBuilder.DropIndex(
                name: "IX_ExaminationDetails_ReferralId",
                table: "ExaminationDetails");

            migrationBuilder.DropColumn(
                name: "FilledSurvey",
                table: "ExaminationDetails");

            migrationBuilder.DropColumn(
                name: "ReferralId",
                table: "ExaminationDetails");
        }
    }
}
