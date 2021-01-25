using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventSourcing.Migrations
{
    public partial class enums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "newExaminationTimeSpent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    StepId = table.Column<int>(nullable: false),
                    StepType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newExaminationTimeSpent", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "newExaminationTimeSpent");
        }
    }
}
