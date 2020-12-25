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
                    { 1L, new DateTime(2021, 1, 10, 0, 44, 17, 339, DateTimeKind.Local).AddTicks(5074), "Andol on sale! 50% off!!", "PH1", new DateTime(2020, 12, 16, 0, 44, 17, 334, DateTimeKind.Local).AddTicks(7457), 1 },
                    { 2L, new DateTime(2021, 1, 25, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3070), "Cheap bromazepam on huge quantities!!", "PH1", new DateTime(2020, 12, 31, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3038), 0 },
                    { 3L, new DateTime(2021, 1, 2, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3173), "Aspirin C for free!!", "PH3", new DateTime(2020, 12, 27, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3168), 0 },
                    { 4L, new DateTime(2021, 1, 17, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3181), "Amazing deal!! Brufen was 5$, now 15$", "PH3", new DateTime(2020, 12, 28, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3178), 2 },
                    { 5L, new DateTime(2021, 1, 10, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3190), "Cant miss!! Vitamin C just for 99$", "PH2", new DateTime(2020, 12, 26, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3186), 2 },
                    { 6L, new DateTime(2020, 12, 25, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3198), "Cheap sedatives!", "PH1", new DateTime(2020, 12, 16, 0, 44, 17, 340, DateTimeKind.Local).AddTicks(3194), 1 }
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
