using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SearchAndSchedule_Microservice.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    EquipmentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            
            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.Id);
                });

            
            migrationBuilder.CreateTable(
                name: "EquipmentStatistic",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    EquipmentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentStatistic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentStatistic_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

           
           

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EquipmentStatisticId = table.Column<long>(nullable: true),
                    RoomCode = table.Column<string>(nullable: true),
                    RoomTypeId = table.Column<long>(nullable: true),
                    MaxNumberOfPatientsForHospitalization = table.Column<int>(nullable: false),
                    CurrentNumberOfPatients = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_EquipmentStatistic_EquipmentStatisticId",
                        column: x => x.EquipmentStatisticId,
                        principalTable: "EquipmentStatistic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Room_RoomType_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Examination",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<long>(nullable: true),
                    DoctorId = table.Column<long>(nullable: true),
                    Period_StartDate = table.Column<DateTime>(nullable: true),
                    Period_EndDate = table.Column<DateTime>(nullable: true),
                    Canceled = table.Column<bool>(nullable: false),
                    CanceledDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examination_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examination_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BussinesDay",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Shift_StartDate = table.Column<DateTime>(nullable: true),
                    Shift_EndDate = table.Column<DateTime>(nullable: true),
                    DoctorId = table.Column<long>(nullable: true),
                    RoomId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BussinesDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BussinesDay_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BussinesDay_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoctorId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Period_StartDate = table.Column<DateTime>(nullable: true),
                    Period_EndDate = table.Column<DateTime>(nullable: true),
                    RoomId = table.Column<long>(nullable: true),
                    PatientId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operation_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operation_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operation_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BussinesDay_ScheduledPeriods",
                columns: table => new
                {
                    BusinessDayId = table.Column<long>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BussinesDay_ScheduledPeriods", x => new { x.BusinessDayId, x.Id });
                    table.ForeignKey(
                        name: "FK_BussinesDay_ScheduledPeriods_BussinesDay_BusinessDayId",
                        column: x => x.BusinessDayId,
                        principalTable: "BussinesDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BussinesDay_DoctorId",
                table: "BussinesDay",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_BussinesDay_RoomId",
                table: "BussinesDay",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentStatistic_EquipmentId",
                table: "EquipmentStatistic",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_DoctorId",
                table: "Examination",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_PatientId",
                table: "Examination",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_DoctorId",
                table: "Operation",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_PatientId",
                table: "Operation",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_RoomId",
                table: "Operation",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_EquipmentStatisticId",
                table: "Room",
                column: "EquipmentStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeId",
                table: "Room",
                column: "RoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BussinesDay_ScheduledPeriods");

            migrationBuilder.DropTable(
                name: "Examination");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "BussinesDay");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "EquipmentStatistic");

            migrationBuilder.DropTable(
                name: "RoomType");

            migrationBuilder.DropTable(
                name: "Equipment");
        }
    }
}
