﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserInteraction_Microservice.Domain;

namespace UserInteraction_Microservice.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20210109225051_MigrationUserInteraction")]
    partial class MigrationUserInteraction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("FullAddress")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Article", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Topic")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Director", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserDetailsId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserLogInId")
                        .HasColumnType("bigint");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("UserDetailsId");

                    b.HasIndex("UserLogInId");

                    b.ToTable("Director");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Doctor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("DoctorGradeId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SpecialityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserDetailsId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserLogInId")
                        .HasColumnType("bigint");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorGradeId");

                    b.HasIndex("PersonId");

                    b.HasIndex("SpecialityId");

                    b.HasIndex("UserDetailsId");

                    b.HasIndex("UserLogInId");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.DoctorGrade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Doctor")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("NumberOfGrades")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DoctorGrade");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.DoctorGradeQuestion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("DoctorGradeId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DoctorGradeId1")
                        .HasColumnType("bigint");

                    b.Property<double>("Grade")
                        .HasColumnType("double");

                    b.Property<string>("Question")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("DoctorGradeId");

                    b.HasIndex("DoctorGradeId1");

                    b.ToTable("DoctorGradeQuestion");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Feedback", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("PatientId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Publish")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Patient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Blocked")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Guest")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserDetailsId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserLogInId")
                        .HasColumnType("bigint");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<bool>("Validation")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("UserDetailsId");

                    b.HasIndex("UserLogInId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Jmbg")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Secretary", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserDetailsId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserLogInId")
                        .HasColumnType("bigint");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("UserDetailsId");

                    b.HasIndex("UserLogInId");

                    b.ToTable("Secretary");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Speciality", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Speciality");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.UserDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<string>("BloodType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Image")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Race")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.UserLogIn", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Username")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("UserLogIn");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Address", b =>
                {
                    b.OwnsOne("UserInteraction_Microservice.Domain.Model.State", "State", b1 =>
                        {
                            b1.Property<long>("AddressId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Code")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("Name")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.HasKey("AddressId");

                            b1.ToTable("Address");

                            b1.WithOwner()
                                .HasForeignKey("AddressId");
                        });

                    b.OwnsOne("UserInteraction_Microservice.Domain.Model.Town", "Town", b1 =>
                        {
                            b1.Property<long>("AddressId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Name")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.Property<string>("PostalNumber")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.HasKey("AddressId");

                            b1.ToTable("Address");

                            b1.WithOwner()
                                .HasForeignKey("AddressId");
                        });
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Article", b =>
                {
                    b.HasOne("UserInteraction_Microservice.Domain.Model.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Director", b =>
                {
                    b.HasOne("UserInteraction_Microservice.Domain.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("UserInteraction_Microservice.Domain.Model.UserDetails", "UserDetails")
                        .WithMany()
                        .HasForeignKey("UserDetailsId");

                    b.HasOne("UserInteraction_Microservice.Domain.Model.UserLogIn", "UserLogIn")
                        .WithMany()
                        .HasForeignKey("UserLogInId");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Doctor", b =>
                {
                    b.HasOne("UserInteraction_Microservice.Domain.Model.DoctorGrade", "DoctorGrade")
                        .WithMany()
                        .HasForeignKey("DoctorGradeId");

                    b.HasOne("UserInteraction_Microservice.Domain.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("UserInteraction_Microservice.Domain.Model.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId");

                    b.HasOne("UserInteraction_Microservice.Domain.Model.UserDetails", "UserDetails")
                        .WithMany()
                        .HasForeignKey("UserDetailsId");

                    b.HasOne("UserInteraction_Microservice.Domain.Model.UserLogIn", "UserLogIn")
                        .WithMany()
                        .HasForeignKey("UserLogInId");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.DoctorGradeQuestion", b =>
                {
                    b.HasOne("UserInteraction_Microservice.Domain.Model.DoctorGrade", null)
                        .WithMany("AverageGrade")
                        .HasForeignKey("DoctorGradeId");

                    b.HasOne("UserInteraction_Microservice.Domain.Model.DoctorGrade", null)
                        .WithMany("DoctorGradeQuestions")
                        .HasForeignKey("DoctorGradeId1");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Feedback", b =>
                {
                    b.HasOne("UserInteraction_Microservice.Domain.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Patient", b =>
                {
                    b.HasOne("UserInteraction_Microservice.Domain.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("UserInteraction_Microservice.Domain.Model.UserDetails", "UserDetails")
                        .WithMany()
                        .HasForeignKey("UserDetailsId");

                    b.HasOne("UserInteraction_Microservice.Domain.Model.UserLogIn", "UserLogIn")
                        .WithMany()
                        .HasForeignKey("UserLogInId");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.Secretary", b =>
                {
                    b.HasOne("UserInteraction_Microservice.Domain.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("UserInteraction_Microservice.Domain.Model.UserDetails", "UserDetails")
                        .WithMany()
                        .HasForeignKey("UserDetailsId");

                    b.HasOne("UserInteraction_Microservice.Domain.Model.UserLogIn", "UserLogIn")
                        .WithMany()
                        .HasForeignKey("UserLogInId");
                });

            modelBuilder.Entity("UserInteraction_Microservice.Domain.Model.UserDetails", b =>
                {
                    b.HasOne("UserInteraction_Microservice.Domain.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });
#pragma warning restore 612, 618
        }
    }
}