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
                    { 1L, new DateTime(2020, 12, 30, 21, 26, 18, 775, DateTimeKind.Local).AddTicks(676), "Andol on sale! 50% off!!", "PH1", new DateTime(2020, 12, 5, 21, 26, 18, 773, DateTimeKind.Local).AddTicks(2931), 1 },
                    { 2L, new DateTime(2021, 1, 14, 21, 26, 18, 775, DateTimeKind.Local).AddTicks(6075), "Cheap bromazepam on huge quantities!!", "PH1", new DateTime(2020, 12, 20, 21, 26, 18, 775, DateTimeKind.Local).AddTicks(5844), 0 },
                    { 3L, new DateTime(2020, 12, 22, 21, 26, 18, 775, DateTimeKind.Local).AddTicks(6151), "Aspirin C for free!!", "PH3", new DateTime(2020, 12, 16, 21, 26, 18, 775, DateTimeKind.Local).AddTicks(6148), 0 },
                    { 4L, new DateTime(2021, 1, 6, 21, 26, 18, 775, DateTimeKind.Local).AddTicks(6197), "Amazing deal!! Brufen was 5$, now 15$", "PH3", new DateTime(2020, 12, 17, 21, 26, 18, 775, DateTimeKind.Local).AddTicks(6193), 2 },
                    { 5L, new DateTime(2020, 12, 30, 21, 26, 18, 775, DateTimeKind.Local).AddTicks(6203), "Cant miss!! Vitamin C just for 99$", "PH2", new DateTime(2020, 12, 15, 21, 26, 18, 775, DateTimeKind.Local).AddTicks(6200), 2 },
                    { 6L, new DateTime(2020, 12, 14, 21, 26, 18, 775, DateTimeKind.Local).AddTicks(6208), "Cheap sedatives!", "PH1", new DateTime(2020, 12, 5, 21, 26, 18, 775, DateTimeKind.Local).AddTicks(6205), 1 }
                });

            migrationBuilder.InsertData(
                table: "ApiKeys",
                columns: new[] { "NameOfPharmacy", "ApiKey", "Subscribed", "Url" },
                values: new object[,]
                {
                    { "PH1", "4545-as84-8s8g-zXCV", true, "http://localhost:4200/Ph1" },
                    { "PH2", "7788-AV5R-zxQt-5845", true, "http://localhost:4200/Ph2" },
                    { "PH3", "9745-At7S-Aqtr-5q8t", true, "http://localhost:4200/Ph3" },
                    { "PH4", "HgT8-n47E-bE41-2gt5", true, "http://localhost:4200/Ph4" }
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
