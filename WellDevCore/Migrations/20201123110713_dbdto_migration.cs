using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica.Migrations
{
    public partial class dbdto_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExaminationDbDtos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    DoctorId = table.Column<long>(nullable: false),
                    PeriodId = table.Column<long>(nullable: false),
                    DiagnosisId = table.Column<long>(nullable: false),
                    PrescriptionId = table.Column<long>(nullable: false),
                    AnemnesisId = table.Column<long>(nullable: false),
                    TherapyId = table.Column<long>(nullable: false),
                    RefferalId = table.Column<long>(nullable: false),
                    PatientFileId = table.Column<long>(nullable: false),
                    RoomOccuoationreportDTOId = table.Column<long>(nullable: false),
                    RoomOccuoationreportDTOId1 = table.Column<long>(nullable: false),
                    SecretaryReportDTOId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationDbDtos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExaminationDbDtos");
        }
    }
}
