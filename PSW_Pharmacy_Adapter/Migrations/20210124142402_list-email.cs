using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW_Pharmacy_Adapter.Migrations
{
    public partial class listemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Email",
                table: "TenderOffers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Mail_Mail",
                table: "TenderOffers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mail_Mail",
                table: "Email",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail_Mail",
                table: "TenderOffers");

            migrationBuilder.DropColumn(
                name: "Mail_Mail",
                table: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TenderOffers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Email",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
