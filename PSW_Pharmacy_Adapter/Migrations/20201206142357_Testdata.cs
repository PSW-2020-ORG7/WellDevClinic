using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSW_Pharmacy_Adapter.Migrations
{
    public partial class Testdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActionsAndBenefits",
                columns: new[] { "Id", "EndDate", "MessageAboutAction", "PharmacyName", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 12, 21, 15, 23, 57, 498, DateTimeKind.Local).AddTicks(5081), "Andol on sale! 50% off!!", "PH1", new DateTime(2020, 11, 26, 15, 23, 57, 496, DateTimeKind.Local).AddTicks(8302), 1 },
                    { 2L, new DateTime(2021, 1, 5, 15, 23, 57, 498, DateTimeKind.Local).AddTicks(8512), "Cheap bromazepam on huge quantities!!", "PH1", new DateTime(2020, 12, 11, 15, 23, 57, 498, DateTimeKind.Local).AddTicks(8496), 0 },
                    { 3L, new DateTime(2020, 12, 13, 15, 23, 57, 498, DateTimeKind.Local).AddTicks(8575), "Aspirin C for free!!", "PH3", new DateTime(2020, 12, 7, 15, 23, 57, 498, DateTimeKind.Local).AddTicks(8571), 0 },
                    { 4L, new DateTime(2020, 12, 28, 15, 23, 57, 498, DateTimeKind.Local).AddTicks(8581), "Amazing deal!! Brufen was 5$, now 15$", "PH3", new DateTime(2020, 12, 8, 15, 23, 57, 498, DateTimeKind.Local).AddTicks(8578), 2 },
                    { 5L, new DateTime(2020, 12, 21, 15, 23, 57, 498, DateTimeKind.Local).AddTicks(8586), "Cant miss!! Vitamin C just for 99$", "PH2", new DateTime(2020, 12, 6, 15, 23, 57, 498, DateTimeKind.Local).AddTicks(8584), 2 },
                    { 6L, new DateTime(2020, 12, 5, 15, 23, 57, 498, DateTimeKind.Local).AddTicks(8592), "Cheap sedatives!", "PH1", new DateTime(2020, 11, 26, 15, 23, 57, 498, DateTimeKind.Local).AddTicks(8589), 1 }
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
