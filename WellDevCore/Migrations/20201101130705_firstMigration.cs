using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anemnesis",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anemnesis", x => x.Id);
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
                name: "DoctorGrade",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumberOfGrades = table.Column<int>(nullable: false),
                    AverageGrade = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorGrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientFile",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFile", x => x.Id);
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
                name: "SecretaryReportDTO",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretaryReportDTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Symptom",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptom", x => x.Id);
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
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoomCode = table.Column<string>(nullable: true),
                    RoomTypeId = table.Column<long>(nullable: true),
                    MaxNumberOfPatientsForHospitalization = table.Column<int>(nullable: false),
                    CurrentNumberOfPatients = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_RoomType_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Town",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PostalNumber = table.Column<string>(nullable: true),
                    StateId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Town_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    FullAddress = table.Column<string>(nullable: true),
                    TownId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Town_TownId",
                        column: x => x.TownId,
                        principalTable: "Town",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Jmbg = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    AddressId = table.Column<long>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    SpecialtyId = table.Column<long>(nullable: true),
                    DoctorGradeId = table.Column<long>(nullable: true),
                    patientFileId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_DoctorGrade_DoctorGradeId",
                        column: x => x.DoctorGradeId,
                        principalTable: "DoctorGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Speciality_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Speciality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_PatientFile_patientFileId",
                        column: x => x.patientFileId,
                        principalTable: "PatientFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DatePublished = table.Column<DateTime>(nullable: false),
                    DoctorId = table.Column<long>(nullable: true),
                    Topic = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_Person_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<long>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    IsPrivate = table.Column<bool>(nullable: false),
                    Publish = table.Column<bool>(nullable: false),
                    IsAnonymous = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_Person_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientNotification",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<long>(nullable: true),
                    Read = table.Column<bool>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientNotification_Person_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorReportDTO",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    prescriptionId = table.Column<long>(nullable: true),
                    AnemnesisId = table.Column<long>(nullable: true),
                    PatientId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorReportDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorReportDTO_Anemnesis_AnemnesisId",
                        column: x => x.AnemnesisId,
                        principalTable: "Anemnesis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorReportDTO_Person_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Examination",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: true),
                    DoctorId = table.Column<long>(nullable: true),
                    PeriodId = table.Column<long>(nullable: true),
                    DiagnosisId = table.Column<long>(nullable: true),
                    PrescriptionId = table.Column<long>(nullable: true),
                    AnemnesisId = table.Column<long>(nullable: true),
                    TherapyId = table.Column<long>(nullable: true),
                    RefferalId = table.Column<long>(nullable: true),
                    PatientFileId = table.Column<long>(nullable: true),
                    RoomOccupationReportDTOId = table.Column<long>(nullable: true),
                    RoomOccupationReportDTOId1 = table.Column<long>(nullable: true),
                    SecretaryReportDTOId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examination_Anemnesis_AnemnesisId",
                        column: x => x.AnemnesisId,
                        principalTable: "Anemnesis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examination_Diagnosis_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnosis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examination_Person_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examination_PatientFile_PatientFileId",
                        column: x => x.PatientFileId,
                        principalTable: "PatientFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examination_SecretaryReportDTO_SecretaryReportDTOId",
                        column: x => x.SecretaryReportDTOId,
                        principalTable: "SecretaryReportDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examination_Person_UserId",
                        column: x => x.UserId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    BusinessDayId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessDay",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ShiftId = table.Column<long>(nullable: true),
                    doctorId = table.Column<long>(nullable: true),
                    roomId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessDay_Period_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessDay_Person_doctorId",
                        column: x => x.doctorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessDay_Room_roomId",
                        column: x => x.roomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessDayDTO",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoctorId = table.Column<long>(nullable: true),
                    PeriodId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDayDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessDayDTO_Person_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessDayDTO_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExaminationDTO",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoctorId = table.Column<long>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    RoomId = table.Column<long>(nullable: true),
                    PeriodId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminationDTO_Person_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExaminationDTO_Person_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExaminationDTO_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExaminationDTO_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotifyDoctorBusinessDay",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    shiftId = table.Column<long>(nullable: true),
                    roomId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotifyDoctorBusinessDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotifyDoctorBusinessDay_Room_roomId",
                        column: x => x.roomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotifyDoctorBusinessDay_Period_shiftId",
                        column: x => x.shiftId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PeriodId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescription_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Referral",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PeriodId = table.Column<long>(nullable: true),
                    DoctorId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referral_Person_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Referral_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomOccupationReportDTO",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    roomId = table.Column<long>(nullable: true),
                    periodId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomOccupationReportDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomOccupationReportDTO_Period_periodId",
                        column: x => x.periodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomOccupationReportDTO_Room_roomId",
                        column: x => x.roomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Therapy",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Note = table.Column<string>(nullable: true),
                    PeriodId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Therapy_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hospitalization",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PeriodId = table.Column<long>(nullable: true),
                    RoomId = table.Column<long>(nullable: true),
                    DoctorId = table.Column<long>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    PatientFileId = table.Column<long>(nullable: true),
                    RoomOccupationReportDTOId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitalization_Person_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hospitalization_PatientFile_PatientFileId",
                        column: x => x.PatientFileId,
                        principalTable: "PatientFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hospitalization_Person_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hospitalization_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hospitalization_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hospitalization_RoomOccupationReportDTO_RoomOccupationReport~",
                        column: x => x.RoomOccupationReportDTOId,
                        principalTable: "RoomOccupationReportDTO",
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
                    PeriodId = table.Column<long>(nullable: true),
                    RoomId = table.Column<long>(nullable: true),
                    PatientId = table.Column<long>(nullable: true),
                    PatientFileId = table.Column<long>(nullable: true),
                    RoomOccupationReportDTOId = table.Column<long>(nullable: true),
                    SecretaryReportDTOId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operation_Person_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operation_PatientFile_PatientFileId",
                        column: x => x.PatientFileId,
                        principalTable: "PatientFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operation_Person_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operation_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operation_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operation_RoomOccupationReportDTO_RoomOccupationReportDTOId",
                        column: x => x.RoomOccupationReportDTOId,
                        principalTable: "RoomOccupationReportDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operation_SecretaryReportDTO_SecretaryReportDTOId",
                        column: x => x.SecretaryReportDTOId,
                        principalTable: "SecretaryReportDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Renovation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    PeriodId = table.Column<long>(nullable: true),
                    RoomId = table.Column<long>(nullable: true),
                    RoomOccupationReportDTOId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renovation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Renovation_Period_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Renovation_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Renovation_RoomOccupationReportDTO_RoomOccupationReportDTOId",
                        column: x => x.RoomOccupationReportDTOId,
                        principalTable: "RoomOccupationReportDTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_Address_TownId",
                table: "Address",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergy_PatientFileId",
                table: "Allergy",
                column: "PatientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_DoctorId",
                table: "Article",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDay_ShiftId",
                table: "BusinessDay",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDay_doctorId",
                table: "BusinessDay",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDay_roomId",
                table: "BusinessDay",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDayDTO_DoctorId",
                table: "BusinessDayDTO",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDayDTO_PeriodId",
                table: "BusinessDayDTO",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReportDTO_AnemnesisId",
                table: "DoctorReportDTO",
                column: "AnemnesisId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReportDTO_PatientId",
                table: "DoctorReportDTO",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReportDTO_prescriptionId",
                table: "DoctorReportDTO",
                column: "prescriptionId");

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
                name: "IX_Examination_AnemnesisId",
                table: "Examination",
                column: "AnemnesisId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_DiagnosisId",
                table: "Examination",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_DoctorId",
                table: "Examination",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_PatientFileId",
                table: "Examination",
                column: "PatientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_PeriodId",
                table: "Examination",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_PrescriptionId",
                table: "Examination",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_RefferalId",
                table: "Examination",
                column: "RefferalId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_RoomOccupationReportDTOId",
                table: "Examination",
                column: "RoomOccupationReportDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_RoomOccupationReportDTOId1",
                table: "Examination",
                column: "RoomOccupationReportDTOId1");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_SecretaryReportDTOId",
                table: "Examination",
                column: "SecretaryReportDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_TherapyId",
                table: "Examination",
                column: "TherapyId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_UserId",
                table: "Examination",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationDTO_DoctorId",
                table: "ExaminationDTO",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationDTO_PatientId",
                table: "ExaminationDTO",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationDTO_PeriodId",
                table: "ExaminationDTO",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ExaminationDTO_RoomId",
                table: "ExaminationDTO",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_PatientId",
                table: "Feedback",
                column: "PatientId");

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
                name: "IX_Hospitalization_PeriodId",
                table: "Hospitalization",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalization_RoomId",
                table: "Hospitalization",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalization_RoomOccupationReportDTOId",
                table: "Hospitalization",
                column: "RoomOccupationReportDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_DrugId",
                table: "Ingredient",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifyDoctorBusinessDay_roomId",
                table: "NotifyDoctorBusinessDay",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifyDoctorBusinessDay_shiftId",
                table: "NotifyDoctorBusinessDay",
                column: "shiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_DoctorId",
                table: "Operation",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_PatientFileId",
                table: "Operation",
                column: "PatientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_PatientId",
                table: "Operation",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_PeriodId",
                table: "Operation",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_RoomId",
                table: "Operation",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_RoomOccupationReportDTOId",
                table: "Operation",
                column: "RoomOccupationReportDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_SecretaryReportDTOId",
                table: "Operation",
                column: "SecretaryReportDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientNotification_PatientId",
                table: "PatientNotification",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Period_BusinessDayId",
                table: "Period",
                column: "BusinessDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_DoctorGradeId",
                table: "Person",
                column: "DoctorGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_SpecialtyId",
                table: "Person",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_patientFileId",
                table: "Person",
                column: "patientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressId",
                table: "Person",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PeriodId",
                table: "Prescription",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Referral_DoctorId",
                table: "Referral",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Referral_PeriodId",
                table: "Referral",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Renovation_PeriodId",
                table: "Renovation",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Renovation_RoomId",
                table: "Renovation",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Renovation_RoomOccupationReportDTOId",
                table: "Renovation",
                column: "RoomOccupationReportDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeId",
                table: "Room",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomOccupationReportDTO_periodId",
                table: "RoomOccupationReportDTO",
                column: "periodId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomOccupationReportDTO_roomId",
                table: "RoomOccupationReportDTO",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapy_PeriodId",
                table: "Therapy",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Town_StateId",
                table: "Town",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorReportDTO_Prescription_prescriptionId",
                table: "DoctorReportDTO",
                column: "prescriptionId",
                principalTable: "Prescription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_Period_PeriodId",
                table: "Examination",
                column: "PeriodId",
                principalTable: "Period",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_Prescription_PrescriptionId",
                table: "Examination",
                column: "PrescriptionId",
                principalTable: "Prescription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_Therapy_TherapyId",
                table: "Examination",
                column: "TherapyId",
                principalTable: "Therapy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_Referral_RefferalId",
                table: "Examination",
                column: "RefferalId",
                principalTable: "Referral",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_RoomOccupationReportDTO_RoomOccupationReportDTOId",
                table: "Examination",
                column: "RoomOccupationReportDTOId",
                principalTable: "RoomOccupationReportDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Examination_RoomOccupationReportDTO_RoomOccupationReportDTOI~",
                table: "Examination",
                column: "RoomOccupationReportDTOId1",
                principalTable: "RoomOccupationReportDTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Period_BusinessDay_BusinessDayId",
                table: "Period",
                column: "BusinessDayId",
                principalTable: "BusinessDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Town_TownId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_PatientFile_patientFileId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessDay_Person_doctorId",
                table: "BusinessDay");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessDay_Period_ShiftId",
                table: "BusinessDay");

            migrationBuilder.DropTable(
                name: "Allergy");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "BusinessDayDTO");

            migrationBuilder.DropTable(
                name: "DoctorReportDTO");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Examination");

            migrationBuilder.DropTable(
                name: "ExaminationDTO");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Hospitalization");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "NotifyDoctorBusinessDay");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "PatientNotification");

            migrationBuilder.DropTable(
                name: "Renovation");

            migrationBuilder.DropTable(
                name: "Symptom");

            migrationBuilder.DropTable(
                name: "Anemnesis");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "Referral");

            migrationBuilder.DropTable(
                name: "Drug");

            migrationBuilder.DropTable(
                name: "SecretaryReportDTO");

            migrationBuilder.DropTable(
                name: "RoomOccupationReportDTO");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Therapy");

            migrationBuilder.DropTable(
                name: "Town");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "PatientFile");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "DoctorGrade");

            migrationBuilder.DropTable(
                name: "Speciality");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "BusinessDay");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "RoomType");
        }
    }
}
