using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW_Pharmacy_Adapter.Migrations
{
    public partial class TenderOfferAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TenderId",
                table: "TenderOffers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 13, 13, 27, 22, 600, DateTimeKind.Local).AddTicks(5779), new DateTime(2020, 12, 19, 13, 27, 22, 596, DateTimeKind.Local).AddTicks(4118) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 28, 13, 27, 22, 601, DateTimeKind.Local).AddTicks(1305), new DateTime(2021, 1, 3, 13, 27, 22, 601, DateTimeKind.Local).AddTicks(1277) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 5, 13, 27, 22, 601, DateTimeKind.Local).AddTicks(1397), new DateTime(2020, 12, 30, 13, 27, 22, 601, DateTimeKind.Local).AddTicks(1392) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 20, 13, 27, 22, 601, DateTimeKind.Local).AddTicks(1405), new DateTime(2020, 12, 31, 13, 27, 22, 601, DateTimeKind.Local).AddTicks(1402) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 13, 13, 27, 22, 601, DateTimeKind.Local).AddTicks(1413), new DateTime(2020, 12, 29, 13, 27, 22, 601, DateTimeKind.Local).AddTicks(1409) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 12, 28, 13, 27, 22, 601, DateTimeKind.Local).AddTicks(1420), new DateTime(2020, 12, 19, 13, 27, 22, 601, DateTimeKind.Local).AddTicks(1417) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenderId",
                table: "TenderOffers");

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
        }
    }
}
