using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW_Pharmacy_Adapter.Migrations
{
    public partial class TenderOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenderOffers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PharmacyName = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    MedicationId = table.Column<long>(nullable: true),
                    TenderOfferId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medication_Medication_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medication_TenderOffers_TenderOfferId",
                        column: x => x.TenderOfferId,
                        principalTable: "TenderOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    MedicationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Ingredient_Medication_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_MedicationId",
                table: "Ingredient",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_MedicationId",
                table: "Medication",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_TenderOfferId",
                table: "Medication",
                column: "TenderOfferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "TenderOffers");
        }
    }
}
