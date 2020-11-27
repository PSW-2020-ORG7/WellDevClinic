using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW_Pharmacy_Adapter.Migrations
{
    public partial class APIKeysMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiKeys",
                columns: table => new
                {
                    NameOfHospital = table.Column<string>(nullable: false),
                    ApiKey = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKeys", x => x.NameOfHospital);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiKeys");
        }
    }
}
