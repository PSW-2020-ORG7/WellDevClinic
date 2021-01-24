using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW_Pharmacy_Adapter.Migrations
{
    public partial class salesAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionsAndBenefits");

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PharmacyName = table.Column<string>(nullable: true),
                    SaleMessage = table.Column<string>(nullable: true),
                    ValPeriod_StartDate = table.Column<DateTime>(nullable: true),
                    ValPeriod_EndDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.CreateTable(
                name: "ActionsAndBenefits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MessageAboutAction = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PharmacyName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionsAndBenefits", x => x.Id);
                });
        }
    }
}
