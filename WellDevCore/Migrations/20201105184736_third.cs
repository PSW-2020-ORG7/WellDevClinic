using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Person_PatientId",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_PatientId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Feedback");

            migrationBuilder.AddColumn<string>(
                name: "Patient",
                table: "Feedback",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Patient",
                table: "Feedback");

            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "Feedback",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_PatientId",
                table: "Feedback",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Person_PatientId",
                table: "Feedback",
                column: "PatientId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
