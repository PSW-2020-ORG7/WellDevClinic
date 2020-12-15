using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW_Pharmacy_Adapter.Migrations
{
    public partial class TestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActionsAndBenefits",
                columns: new[] { "Id", "EndDate", "MessageAboutAction", "PharmacyName", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 12, 29, 14, 15, 41, 798, DateTimeKind.Local).AddTicks(3210), "Andol on sale! 50% off!!", "PH1", new DateTime(2020, 12, 4, 14, 15, 41, 796, DateTimeKind.Local).AddTicks(6068), 1 },
                    { 2L, new DateTime(2021, 1, 13, 14, 15, 41, 798, DateTimeKind.Local).AddTicks(6497), "Cheap bromazepam on huge quantities!!", "PH1", new DateTime(2020, 12, 19, 14, 15, 41, 798, DateTimeKind.Local).AddTicks(6479), 0 },
                    { 3L, new DateTime(2020, 12, 21, 14, 15, 41, 798, DateTimeKind.Local).AddTicks(6558), "Aspirin C for free!!", "PH3", new DateTime(2020, 12, 15, 14, 15, 41, 798, DateTimeKind.Local).AddTicks(6554), 0 },
                    { 4L, new DateTime(2021, 1, 5, 14, 15, 41, 798, DateTimeKind.Local).AddTicks(6565), "Amazing deal!! Brufen was 5$, now 15$", "PH3", new DateTime(2020, 12, 16, 14, 15, 41, 798, DateTimeKind.Local).AddTicks(6562), 2 },
                    { 5L, new DateTime(2020, 12, 29, 14, 15, 41, 798, DateTimeKind.Local).AddTicks(6571), "Cant miss!! Vitamin C just for 99$", "PH2", new DateTime(2020, 12, 14, 14, 15, 41, 798, DateTimeKind.Local).AddTicks(6568), 2 },
                    { 6L, new DateTime(2020, 12, 13, 14, 15, 41, 798, DateTimeKind.Local).AddTicks(6577), "Cheap sedatives!", "PH1", new DateTime(2020, 12, 4, 14, 15, 41, 798, DateTimeKind.Local).AddTicks(6574), 1 }
                });

            migrationBuilder.InsertData(
                table: "ApiKeys",
                columns: new[] { "NameOfPharmacy", "ApiKey", "Url" },
                values: new object[,]
                {
                    { "PH1", "4545-as84-8s8g-zXCV", "http://localhost:4200/Ph1" },
                    { "PH2", "7788-AV5R-zxQt-5845", "http://localhost:4200/Ph2" },
                    { "PH3", "9745-At7S-Aqtr-5q8t", "http://localhost:4200/Ph3" },
                    { "PH4", "HgT8-n47E-bE41-2gt5", "http://localhost:4200/Ph4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ActionsAndBenefits",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ApiKeys",
                keyColumn: "NameOfPharmacy",
                keyValue: "PH1");

            migrationBuilder.DeleteData(
                table: "ApiKeys",
                keyColumn: "NameOfPharmacy",
                keyValue: "PH2");

            migrationBuilder.DeleteData(
                table: "ApiKeys",
                keyColumn: "NameOfPharmacy",
                keyValue: "PH3");

            migrationBuilder.DeleteData(
                table: "ApiKeys",
                keyColumn: "NameOfPharmacy",
                keyValue: "PH4");
        }
    }
}
