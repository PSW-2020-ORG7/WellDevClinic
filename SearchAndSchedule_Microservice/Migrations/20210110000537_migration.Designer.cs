﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SearchAndSchedule_Microservice.Domain;

namespace SearchAndSchedule_Microservice.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20210110000537_migration")]
    partial class migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.BusinessDay", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("RoomId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("RoomId");

                    b.ToTable("BussinesDay");
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.Doctor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SpecialityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.Equipment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.EquipmentStatistic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<long?>("EquipmentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("EquipmentStatistic");
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.Operation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long?>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PatientId")
                        .HasColumnType("bigint");

                    b.Property<long?>("RoomId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("RoomId");

                    b.ToTable("Operation");
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.Patient", b =>
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

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.Person", b =>
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

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.Room", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("CurrentNumberOfPatients")
                        .HasColumnType("int");

                    b.Property<long?>("EquipmentStatisticId")
                        .HasColumnType("bigint");

                    b.Property<int>("MaxNumberOfPatientsForHospitalization")
                        .HasColumnType("int");

                    b.Property<string>("RoomCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long?>("RoomTypeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentStatisticId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.RoomType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("RoomType");
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.Speciality", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Speciality");
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.UpcomingExamination", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Canceled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CanceledDate")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PatientId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Examination");
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.BusinessDay", b =>
                {
                    b.HasOne("SearchAndSchedule_Microservice.Domain.Model.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("SearchAndSchedule_Microservice.Domain.Model.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.OwnsMany("SearchAndSchedule_Microservice.Domain.Model.Period", "ScheduledPeriods", b1 =>
                        {
                            b1.Property<long>("BusinessDayId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<DateTime>("EndDate")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("datetime(6)");

                            b1.HasKey("BusinessDayId", "Id");

                            b1.ToTable("BussinesDay_ScheduledPeriods");

                            b1.WithOwner()
                                .HasForeignKey("BusinessDayId");
                        });

                    b.OwnsOne("SearchAndSchedule_Microservice.Domain.Model.Period", "Shift", b1 =>
                        {
                            b1.Property<long>("BusinessDayId")
                                .HasColumnType("bigint");

                            b1.Property<DateTime>("EndDate")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("datetime(6)");

                            b1.HasKey("BusinessDayId");

                            b1.ToTable("BussinesDay");

                            b1.WithOwner()
                                .HasForeignKey("BusinessDayId");
                        });
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.Doctor", b =>
                {
                    b.HasOne("SearchAndSchedule_Microservice.Domain.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("SearchAndSchedule_Microservice.Domain.Model.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId");
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.EquipmentStatistic", b =>
                {
                    b.HasOne("SearchAndSchedule_Microservice.Domain.Model.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentId");
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.Operation", b =>
                {
                    b.HasOne("SearchAndSchedule_Microservice.Domain.Model.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("SearchAndSchedule_Microservice.Domain.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.HasOne("SearchAndSchedule_Microservice.Domain.Model.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.OwnsOne("SearchAndSchedule_Microservice.Domain.Model.Period", "Period", b1 =>
                        {
                            b1.Property<long>("OperationId")
                                .HasColumnType("bigint");

                            b1.Property<DateTime>("EndDate")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("datetime(6)");

                            b1.HasKey("OperationId");

                            b1.ToTable("Operation");

                            b1.WithOwner()
                                .HasForeignKey("OperationId");
                        });
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.Patient", b =>
                {
                    b.HasOne("SearchAndSchedule_Microservice.Domain.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.Room", b =>
                {
                    b.HasOne("SearchAndSchedule_Microservice.Domain.Model.EquipmentStatistic", "EquipmentStatistic")
                        .WithMany()
                        .HasForeignKey("EquipmentStatisticId");

                    b.HasOne("SearchAndSchedule_Microservice.Domain.Model.RoomType", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId");
                });

            modelBuilder.Entity("SearchAndSchedule_Microservice.Domain.Model.UpcomingExamination", b =>
                {
                    b.HasOne("SearchAndSchedule_Microservice.Domain.Model.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("SearchAndSchedule_Microservice.Domain.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.OwnsOne("SearchAndSchedule_Microservice.Domain.Model.Period", "Period", b1 =>
                        {
                            b1.Property<long>("UpcomingExaminationId")
                                .HasColumnType("bigint");

                            b1.Property<DateTime>("EndDate")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("datetime(6)");

                            b1.HasKey("UpcomingExaminationId");

                            b1.ToTable("Examination");

                            b1.WithOwner()
                                .HasForeignKey("UpcomingExaminationId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
