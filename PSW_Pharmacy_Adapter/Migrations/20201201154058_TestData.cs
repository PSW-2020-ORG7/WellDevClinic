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
                    { 1L, 15L, "Andol on sale! 50% off!!", "PH1", 10L },
                    { 2L, 30L, "Cheap bromazepam on huge quantities!!", "PH1", 1L },
                    { 3L, 13L, "Aspirin C for free!!", "PH3", 8L },
                    { 4L, 45L, "Amazing deal!! Brufen was 5$, now 15$", "PH3", 10L },
                    { 5L, 50L, "Cant miss!! Vitamin C just for 99$", "PH2", 18L },
                    { 6L, 15L, "Cheap sedatives!", "PH1", 10L }
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
