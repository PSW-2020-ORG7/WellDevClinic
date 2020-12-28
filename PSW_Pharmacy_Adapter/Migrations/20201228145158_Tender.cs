using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW_Pharmacy_Adapter.Migrations
{
    public partial class Tender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TenderId",
                table: "Medication",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tender",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    startDate = table.Column<DateTime>(nullable: false),
                    endDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tender", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 12, 15, 51, 57, 582, DateTimeKind.Local).AddTicks(415), new DateTime(2020, 12, 18, 15, 51, 57, 579, DateTimeKind.Local).AddTicks(1863) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 27, 15, 51, 57, 582, DateTimeKind.Local).AddTicks(5695), new DateTime(2021, 1, 2, 15, 51, 57, 582, DateTimeKind.Local).AddTicks(5659) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 4, 15, 51, 57, 582, DateTimeKind.Local).AddTicks(5805), new DateTime(2020, 12, 29, 15, 51, 57, 582, DateTimeKind.Local).AddTicks(5801) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 19, 15, 51, 57, 582, DateTimeKind.Local).AddTicks(5813), new DateTime(2020, 12, 30, 15, 51, 57, 582, DateTimeKind.Local).AddTicks(5810) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 12, 15, 51, 57, 582, DateTimeKind.Local).AddTicks(5820), new DateTime(2020, 12, 28, 15, 51, 57, 582, DateTimeKind.Local).AddTicks(5817) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 12, 27, 15, 51, 57, 582, DateTimeKind.Local).AddTicks(5827), new DateTime(2020, 12, 18, 15, 51, 57, 582, DateTimeKind.Local).AddTicks(5824) });

            migrationBuilder.CreateIndex(
                name: "IX_Medication_TenderId",
                table: "Medication",
                column: "TenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medication_Tender_TenderId",
                table: "Medication",
                column: "TenderId",
                principalTable: "Tender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medication_Tender_TenderId",
                table: "Medication");

            migrationBuilder.DropTable(
                name: "Tender");

            migrationBuilder.DropIndex(
                name: "IX_Medication_TenderId",
                table: "Medication");

            migrationBuilder.DropColumn(
                name: "TenderId",
                table: "Medication");

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 10, 0, 44, 17, 339, DateTimeKind.Local).AddTicks(5074), new DateTime(2020, 12, 16, 0, 44, 17, 334, DateTimeKind.Local).AddTicks(7457) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 25, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3070), new DateTime(2020, 12, 31, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3038) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 2, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3173), new DateTime(2020, 12, 27, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3168) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 17, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3181), new DateTime(2020, 12, 28, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3178) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 10, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3190), new DateTime(2020, 12, 26, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3186) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 12, 25, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3198), new DateTime(2020, 12, 16, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3194) });
        }
    }
}
