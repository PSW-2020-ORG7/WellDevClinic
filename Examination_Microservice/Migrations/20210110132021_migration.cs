﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Examination_Microservice.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Anamnesis",
            columns: table => new
            {
                Id = table.Column<long>(nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                Text = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Anamnesis", x => x.Id);
            });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "Sympthom",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sympthom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Therapy",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drug",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    DrugId = table.Column<long>(nullable: true),
                    PrescriptionId = table.Column<long>(nullable: true),
                    TherapyId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drug", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drug_Drug_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drug",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Drug_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Drug_Therapy_TherapyId",
                        column: x => x.TherapyId,
                        principalTable: "Therapy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientFile",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientFile_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Referral",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    DoctorId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referral_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    DrugId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_Drug_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drug",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Allergy",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PatientFileId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergy_PatientFile_PatientFileId",
                        column: x => x.PatientFileId,
                        principalTable: "PatientFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExaminationDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DiagnosisId = table.Column<long>(nullable: true),
                    PrescriptionId = table.Column<long>(nullable: true),
                    AnamnesisId = table.Column<long>(nullable: true),
                    TherapyId = table.Column<long>(nullable: true),
                    SympthomId = table.Column<long>(nullable: true),
                    DoctorId = table.Column<long>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    PatientFileId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationDetails_Anamnesis_AnamnesisId",
                        column: x => x.AnamnesisId,
                        principalTable: "Anamnesis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExaminationDetails_Diagnosis_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnosis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExaminationDetails_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExaminationDetails_PatientFile_PatientFileId",
                        column: x => x.PatientFileId,
                        principalTable: "PatientFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExaminationDetails_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExaminationDetails_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExaminationDetails_Sympthom_SympthomId",
                        column: x => x.SympthomId,
                        principalTable: "Sympthom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExaminationDetails_Therapy_TherapyId",
                        column: x => x.TherapyId,
                        principalTable: "Therapy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hospitalization",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoomId = table.Column<long>(nullable: true),
                    DoctorId = table.Column<long>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    PatientFileId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitalization_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hospitalization_PatientFile_PatientFileId",
                        column: x => x.PatientFileId,
                        principalTable: "PatientFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hospitalization_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hospitalization_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergy_PatientFileId",
                table: "Allergy",
                column: "PatientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Drug_DrugId",
                table: "Drug",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Drug_PrescriptionId",
                table: "Drug",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Drug_TherapyId",
                table: "Drug",
                column: "TherapyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationDetails_AnamnesisId",
                table: "ExaminationDetails",
                column: "AnamnesisId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationDetails_DiagnosisId",
                table: "ExaminationDetails",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationDetails_DoctorId",
                table: "ExaminationDetails",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationDetails_PatientFileId",
                table: "ExaminationDetails",
                column: "PatientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationDetails_PatientId",
                table: "ExaminationDetails",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationDetails_PrescriptionId",
                table: "ExaminationDetails",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationDetails_SympthomId",
                table: "ExaminationDetails",
                column: "SympthomId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationDetails_TherapyId",
                table: "ExaminationDetails",
                column: "TherapyId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalization_DoctorId",
                table: "Hospitalization",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalization_PatientFileId",
                table: "Hospitalization",
                column: "PatientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalization_PatientId",
                table: "Hospitalization",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalization_RoomId",
                table: "Hospitalization",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_DrugId",
                table: "Ingredient",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFile_PatientId",
                table: "PatientFile",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Referral_DoctorId",
                table: "Referral",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergy");

            migrationBuilder.DropTable(
                name: "ExaminationDetails");

            migrationBuilder.DropTable(
                name: "Hospitalization");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Referral");

            migrationBuilder.DropTable(
                name: "Anamnesis");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "Sympthom");

            migrationBuilder.DropTable(
                name: "Drug");

            migrationBuilder.DropTable(
                name: "PatientFile");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Therapy");
        }
    }
}
