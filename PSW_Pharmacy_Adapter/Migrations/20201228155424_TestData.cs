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
                    { 1L, new DateTime(2021, 1, 12, 16, 54, 23, 539, DateTimeKind.Local).AddTicks(8159), "Andol on sale! 50% off!!", "PH1", new DateTime(2020, 12, 18, 16, 54, 23, 535, DateTimeKind.Local).AddTicks(2299), 1 },
                    { 2L, new DateTime(2021, 1, 27, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5124), "Cheap bromazepam on huge quantities!!", "PH1", new DateTime(2021, 1, 2, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5087), 0 },
                    { 3L, new DateTime(2021, 1, 4, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5224), "Aspirin C for free!!", "PH3", new DateTime(2020, 12, 29, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5219), 0 },
                    { 4L, new DateTime(2021, 1, 19, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5232), "Amazing deal!! Brufen was 5$, now 15$", "PH3", new DateTime(2020, 12, 30, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5229), 2 },
                    { 5L, new DateTime(2021, 1, 12, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5240), "Cant miss!! Vitamin C just for 99$", "PH2", new DateTime(2020, 12, 28, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5236), 2 },
                    { 6L, new DateTime(2020, 12, 27, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5247), "Cheap sedatives!", "PH1", new DateTime(2020, 12, 18, 16, 54, 23, 540, DateTimeKind.Local).AddTicks(5244), 1 }
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
