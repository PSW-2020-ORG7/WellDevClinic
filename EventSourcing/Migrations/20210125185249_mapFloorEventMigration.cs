using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EventSourcing.Migrations
{
    public partial class mapFloorEventMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mapEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    BuildingName = table.Column<string>(nullable: false),
                    FloorLevel = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mapEvent", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mapEvent");
        }
    }
}
