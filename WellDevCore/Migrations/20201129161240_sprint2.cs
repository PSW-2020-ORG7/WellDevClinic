using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bolnica.Migrations
{
    public partial class sprint2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gradeDTO",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    DoctorGradeId = table.Column<long>(nullable: true),
                    DoctorGradeId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gradeDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gradeDTO_DoctorGrade_DoctorGradeId",
                        column: x => x.DoctorGradeId,
                        principalTable: "DoctorGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_gradeDTO_DoctorGrade_DoctorGradeId1",
                        column: x => x.DoctorGradeId1,
                        principalTable: "DoctorGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gradeDTO_DoctorGradeId",
                table: "gradeDTO",
                column: "DoctorGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_gradeDTO_DoctorGradeId1",
                table: "gradeDTO",
                column: "DoctorGradeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gradeDTO");
        }
    }
}
