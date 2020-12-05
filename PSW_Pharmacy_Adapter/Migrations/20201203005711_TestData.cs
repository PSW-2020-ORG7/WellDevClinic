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
                columns: new[] { "Id", "EndDate", "MessageAboutAction", "PharmacyName", "StartDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 12, 18, 1, 57, 10, 784, DateTimeKind.Local).AddTicks(5703), "Andol on sale! 50% off!!", "PH1", new DateTime(2020, 12, 13, 1, 57, 10, 774, DateTimeKind.Local).AddTicks(2347) },
                    { 2L, new DateTime(2021, 1, 2, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(5847), "Cheap bromazepam on huge quantities!!", "PH1", new DateTime(2020, 12, 8, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(5804) },
                    { 3L, new DateTime(2020, 12, 10, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(5983), "Aspirin C for free!!", "PH3", new DateTime(2020, 12, 4, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(5975) },
                    { 4L, new DateTime(2020, 12, 25, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(6084), "Amazing deal!! Brufen was 5$, now 15$", "PH3", new DateTime(2020, 12, 5, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(6076) },
                    { 5L, new DateTime(2020, 12, 5, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(6109), "Cant miss!! Vitamin C just for 99$", "PH2", new DateTime(2020, 12, 3, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(6103) },
                    { 6L, new DateTime(2020, 12, 4, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(6123), "Cheap sedatives!", "PH1", new DateTime(2020, 12, 3, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(6117) }
                });

            migrationBuilder.InsertData(
                table: "ApiKeys",
                columns: new[] { "NameOfPharmacy", "ApiKey", "Url" },
                values: new object[,]
                {
                    { "PH1", "4545-as84-8s8g-zXCV", "localhost:4200/Ph1" },
                    { "PH2", "7788-AV5R-zxQt-5845", "localhost:4200/Ph2" },
                    { "PH3", "9745-At7S-Aqtr-5q8t", "localhost:4200/Ph3" },
                    { "PH4", "HgT8-n47E-bE41-2gt5", "localhost:4200/Ph4" }
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
