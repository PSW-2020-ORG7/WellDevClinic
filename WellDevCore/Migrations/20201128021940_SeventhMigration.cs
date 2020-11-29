using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica.Migrations
{
    public partial class SeventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExaminationDbDtos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExaminationDbDtos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AnemnesisId = table.Column<long>(type: "bigint", nullable: false),
                    DiagnosisId = table.Column<long>(type: "bigint", nullable: false),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    PatientFileId = table.Column<long>(type: "bigint", nullable: false),
                    PeriodId = table.Column<long>(type: "bigint", nullable: false),
                    PrescriptionId = table.Column<long>(type: "bigint", nullable: false),
                    RefferalId = table.Column<long>(type: "bigint", nullable: false),
                    RoomOccuoationreportDTOId = table.Column<long>(type: "bigint", nullable: false),
                    RoomOccuoationreportDTOId1 = table.Column<long>(type: "bigint", nullable: false),
                    SecretaryReportDTOId = table.Column<long>(type: "bigint", nullable: false),
                    TherapyId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationDbDtos", x => x.Id);
                });
        }
    }
}
