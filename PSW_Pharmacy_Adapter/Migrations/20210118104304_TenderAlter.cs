using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW_Pharmacy_Adapter.Migrations
{
    public partial class TenderAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Tender",
                newName: "Period_StartDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Tender",
                newName: "Period_EndDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Period_StartDate",
                table: "Tender",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Period_EndDate",
                table: "Tender",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 2, 2, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(1090), new DateTime(2021, 1, 8, 11, 43, 3, 351, DateTimeKind.Local).AddTicks(6393) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 2, 17, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8367), new DateTime(2021, 1, 23, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8323) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 25, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8468), new DateTime(2021, 1, 19, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8463) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 2, 9, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8478), new DateTime(2021, 1, 20, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8474) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 2, 2, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8486), new DateTime(2021, 1, 18, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8482) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 17, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8494), new DateTime(2021, 1, 8, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8491) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Period_StartDate",
                table: "Tender",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "Period_EndDate",
                table: "Tender",
                newName: "EndDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Tender",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Tender",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 25, 12, 30, 48, 77, DateTimeKind.Local).AddTicks(9641), new DateTime(2020, 12, 31, 12, 30, 48, 74, DateTimeKind.Local).AddTicks(6830) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 2, 9, 12, 30, 48, 78, DateTimeKind.Local).AddTicks(8051), new DateTime(2021, 1, 15, 12, 30, 48, 78, DateTimeKind.Local).AddTicks(7989) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 17, 12, 30, 48, 78, DateTimeKind.Local).AddTicks(8162), new DateTime(2021, 1, 11, 12, 30, 48, 78, DateTimeKind.Local).AddTicks(8158) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 2, 1, 12, 30, 48, 78, DateTimeKind.Local).AddTicks(8170), new DateTime(2021, 1, 12, 12, 30, 48, 78, DateTimeKind.Local).AddTicks(8167) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 25, 12, 30, 48, 78, DateTimeKind.Local).AddTicks(8177), new DateTime(2021, 1, 10, 12, 30, 48, 78, DateTimeKind.Local).AddTicks(8174) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 9, 12, 30, 48, 78, DateTimeKind.Local).AddTicks(8184), new DateTime(2020, 12, 31, 12, 30, 48, 78, DateTimeKind.Local).AddTicks(8181) });
        }
    }
}
