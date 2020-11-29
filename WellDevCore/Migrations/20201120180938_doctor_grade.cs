using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica.Migrations
{
    public partial class doctor_grade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GradeDTO",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    DoctorGradeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeDTO_DoctorGrade_DoctorGradeId",
                        column: x => x.DoctorGradeId,
                        principalTable: "DoctorGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradeDTO_DoctorGradeId",
                table: "GradeDTO",
                column: "DoctorGradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradeDTO");
        }
    }
}
