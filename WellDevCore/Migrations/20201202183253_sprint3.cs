using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WellDevCore.Migrations
{
    public partial class sprint3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DoctorId",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Canceled",
                table: "Examination",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "Examination",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Canceled",
                table: "Examination");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "Examination");
        }
    }
}
