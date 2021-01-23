using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SearchAndSchedule_Microservice.Migrations
{
    public partial class editorsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropForeignKey(
                name: "FK_Room_EquipmentStatistic_EquipmentStatisticId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_EquipmentStatisticId",
                table: "Room");

            
            migrationBuilder.DropColumn(
                name: "EquipmentStatisticId",
                table: "Room");


            migrationBuilder.AddColumn<long>(
                name: "RoomId",
                table: "EquipmentStatistic",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentStatistic_RoomId",
                table: "EquipmentStatistic",
                column: "RoomId");


            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentStatistic_Room_RoomId",
                table: "EquipmentStatistic",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentStatistic_Room_RoomId",
                table: "EquipmentStatistic");



            migrationBuilder.DropIndex(
                name: "IX_EquipmentStatistic_RoomId",
                table: "EquipmentStatistic");

           

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "EquipmentStatistic");


            migrationBuilder.AddColumn<long>(
                name: "EquipmentStatisticId",
                table: "Room",
                type: "bigint",
                nullable: true);


            migrationBuilder.CreateIndex(
                name: "IX_Room_EquipmentStatisticId",
                table: "Room",
                column: "EquipmentStatisticId");


            migrationBuilder.AddForeignKey(
                name: "FK_Room_EquipmentStatistic_EquipmentStatisticId",
                table: "Room",
                column: "EquipmentStatisticId",
                principalTable: "EquipmentStatistic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
