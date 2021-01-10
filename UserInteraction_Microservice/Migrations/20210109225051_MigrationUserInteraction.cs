using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserInteraction_Microservice.Migrations
{
    public partial class MigrationUserInteraction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    FullAddress = table.Column<string>(nullable: true),
                    Town_Name = table.Column<string>(nullable: true),
                    Town_PostalNumber = table.Column<string>(nullable: true),
                    State_Name = table.Column<string>(nullable: true),
                    State_Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorGrade",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumberOfGrades = table.Column<int>(nullable: false),
                    Doctor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorGrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Jmbg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
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
                name: "UserLogIn",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogIn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    BloodType = table.Column<string>(nullable: true),
                    AddressId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetails_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorGradeQuestion",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<double>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    DoctorGradeId = table.Column<long>(nullable: true),
                    DoctorGradeId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorGradeQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorGradeQuestion_DoctorGrade_DoctorGradeId",
                        column: x => x.DoctorGradeId,
                        principalTable: "DoctorGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorGradeQuestion_DoctorGrade_DoctorGradeId1",
                        column: x => x.DoctorGradeId1,
                        principalTable: "DoctorGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<long>(nullable: true),
                    UserDetailsId = table.Column<long>(nullable: true),
                    UserLogInId = table.Column<long>(nullable: true),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Director_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Director_UserDetails_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "UserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Director_UserLogIn_UserLogInId",
                        column: x => x.UserLogInId,
                        principalTable: "UserLogIn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<long>(nullable: true),
                    UserDetailsId = table.Column<long>(nullable: true),
                    UserLogInId = table.Column<long>(nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    SpecialityId = table.Column<long>(nullable: true),
                    DoctorGradeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_DoctorGrade_DoctorGradeId",
                        column: x => x.DoctorGradeId,
                        principalTable: "DoctorGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctor_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctor_Speciality_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Speciality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctor_UserDetails_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "UserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctor_UserLogIn_UserLogInId",
                        column: x => x.UserLogInId,
                        principalTable: "UserLogIn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<long>(nullable: true),
                    UserDetailsId = table.Column<long>(nullable: true),
                    UserLogInId = table.Column<long>(nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    Guest = table.Column<bool>(nullable: false),
                    Blocked = table.Column<bool>(nullable: false),
                    Validation = table.Column<bool>(nullable: false),
                    VerificationToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_UserDetails_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "UserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_UserLogIn_UserLogInId",
                        column: x => x.UserLogInId,
                        principalTable: "UserLogIn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Secretary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<long>(nullable: true),
                    UserDetailsId = table.Column<long>(nullable: true),
                    UserLogInId = table.Column<long>(nullable: true),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Secretary_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Secretary_UserDetails_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "UserDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Secretary_UserLogIn_UserLogInId",
                        column: x => x.UserLogInId,
                        principalTable: "UserLogIn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
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
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
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
                        name: "FK_Feedback_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_DoctorId",
                table: "Articles",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Director_PersonId",
                table: "Director",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Director_UserDetailsId",
                table: "Director",
                column: "UserDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Director_UserLogInId",
                table: "Director",
                column: "UserLogInId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_DoctorGradeId",
                table: "Doctor",
                column: "DoctorGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_PersonId",
                table: "Doctor",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_SpecialityId",
                table: "Doctor",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_UserDetailsId",
                table: "Doctor",
                column: "UserDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_UserLogInId",
                table: "Doctor",
                column: "UserLogInId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorGradeQuestion_DoctorGradeId",
                table: "DoctorGradeQuestion",
                column: "DoctorGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorGradeQuestion_DoctorGradeId1",
                table: "DoctorGradeQuestion",
                column: "DoctorGradeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_PatientId",
                table: "Feedback",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_PersonId",
                table: "Patient",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_UserDetailsId",
                table: "Patient",
                column: "UserDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_UserLogInId",
                table: "Patient",
                column: "UserLogInId");

            migrationBuilder.CreateIndex(
                name: "IX_Secretary_PersonId",
                table: "Secretary",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Secretary_UserDetailsId",
                table: "Secretary",
                column: "UserDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Secretary_UserLogInId",
                table: "Secretary",
                column: "UserLogInId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_AddressId",
                table: "UserDetails",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogIn_Username",
                table: "UserLogIn",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "DoctorGradeQuestion");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Secretary");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "DoctorGrade");

            migrationBuilder.DropTable(
                name: "Speciality");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "UserLogIn");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
