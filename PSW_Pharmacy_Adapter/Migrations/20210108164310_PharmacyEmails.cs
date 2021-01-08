using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW_Pharmacy_Adapter.Migrations
{
    public partial class PharmacyEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 23, 17, 43, 10, 71, DateTimeKind.Local).AddTicks(7798), new DateTime(2020, 12, 29, 17, 43, 10, 66, DateTimeKind.Local).AddTicks(7617) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 2, 7, 17, 43, 10, 72, DateTimeKind.Local).AddTicks(6727), new DateTime(2021, 1, 13, 17, 43, 10, 72, DateTimeKind.Local).AddTicks(6664) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 15, 17, 43, 10, 72, DateTimeKind.Local).AddTicks(6944), new DateTime(2021, 1, 9, 17, 43, 10, 72, DateTimeKind.Local).AddTicks(6923) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 30, 17, 43, 10, 72, DateTimeKind.Local).AddTicks(6977), new DateTime(2021, 1, 10, 17, 43, 10, 72, DateTimeKind.Local).AddTicks(6962) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 23, 17, 43, 10, 72, DateTimeKind.Local).AddTicks(7006), new DateTime(2021, 1, 8, 17, 43, 10, 72, DateTimeKind.Local).AddTicks(6992) });

            migrationBuilder.UpdateData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 1, 7, 17, 43, 10, 72, DateTimeKind.Local).AddTicks(7039), new DateTime(2020, 12, 29, 17, 43, 10, 72, DateTimeKind.Local).AddTicks(7023) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Email");

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
    }
}
