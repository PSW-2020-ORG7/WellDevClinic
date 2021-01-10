using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW_Pharmacy_Adapter.Migrations
{
    public partial class PharmacyEmailsAlter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TenderOffers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Tender",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "OfferWinner",
                table: "Tender",
                nullable: false,
                defaultValue: 0L);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "TenderOffers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Tender");

            migrationBuilder.DropColumn(
                name: "OfferWinner",
                table: "Tender");

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
    }
}
