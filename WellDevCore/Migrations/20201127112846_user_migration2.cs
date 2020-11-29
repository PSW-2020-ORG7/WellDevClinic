using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica.Migrations
{
    public partial class user_migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examination_User_UserId",
                table: "Examination");

            migrationBuilder.DropIndex(
                name: "IX_Examination_UserId",
                table: "Examination");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Examination");

            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "Examination",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Examination_PatientId",
                table: "Examination",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_User_PatientId",
                table: "Examination",
                column: "PatientId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examination_User_PatientId",
                table: "Examination");

            migrationBuilder.DropIndex(
                name: "IX_Examination_PatientId",
                table: "Examination");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Examination");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Examination",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Examination_UserId",
                table: "Examination",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_User_UserId",
                table: "Examination",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
