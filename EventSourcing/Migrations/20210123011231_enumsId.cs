using Microsoft.EntityFrameworkCore.Migrations;

namespace EventSourcing.Migrations
{
    public partial class enumsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ScheduleId",
                table: "newExaminationTimeSpent",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "newExaminationTimeSpent");
        }
    }
}
