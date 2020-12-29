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
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
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
                values: new object[] { new DateTime(2021, 1, 12, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(4239), new DateTime(2020, 12, 18, 22, 1, 58, 53, DateTimeKind.Local).AddTicks(1455) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 27, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9745), new DateTime(2021, 1, 2, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9707) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 4, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9840), new DateTime(2020, 12, 29, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9836) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 19, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9849), new DateTime(2020, 12, 30, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9845) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 12, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9856), new DateTime(2020, 12, 28, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9852) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 12, 27, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9863), new DateTime(2020, 12, 18, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9859) });

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
                values: new object[] { new DateTime(2021, 1, 12, 16, 54, 23, 539, DateTimeKind.Local).AddTicks(8159), new DateTime(2020, 12, 18, 16, 54, 23, 535, DateTimeKind.Local).AddTicks(2299) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 27, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5124), new DateTime(2021, 1, 2, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5087) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 4, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5224), new DateTime(2020, 12, 29, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5219) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 19, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5232), new DateTime(2020, 12, 30, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5229) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 12, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5240), new DateTime(2020, 12, 28, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5236) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 12, 27, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5247), new DateTime(2020, 12, 18, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5244) });
        }
    }
}
