﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSW_Pharmacy_Adapter.Model;

namespace PSW_Pharmacy_Adapter.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20201228210159_Tender")]
    partial class Tender
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Model.ActionAndBenefit", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MessageAboutAction")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PharmacyName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ActionsAndBenefits");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            EndDate = new DateTime(2021, 1, 12, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(4239),
                            MessageAboutAction = "Andol on sale! 50% off!!",
                            PharmacyName = "PH1",
                            StartDate = new DateTime(2020, 12, 18, 22, 1, 58, 53, DateTimeKind.Local).AddTicks(1455),
                            Status = 1
                        },
                        new
                        {
                            Id = 2L,
                            EndDate = new DateTime(2021, 1, 27, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9745),
                            MessageAboutAction = "Cheap bromazepam on huge quantities!!",
                            PharmacyName = "PH1",
                            StartDate = new DateTime(2021, 1, 2, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9707),
                            Status = 0
                        },
                        new
                        {
                            Id = 3L,
                            EndDate = new DateTime(2021, 1, 4, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9840),
                            MessageAboutAction = "Aspirin C for free!!",
                            PharmacyName = "PH3",
                            StartDate = new DateTime(2020, 12, 29, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9836),
                            Status = 0
                        },
                        new
                        {
                            Id = 4L,
                            EndDate = new DateTime(2021, 1, 19, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9849),
                            MessageAboutAction = "Amazing deal!! Brufen was 5$, now 15$",
                            PharmacyName = "PH3",
                            StartDate = new DateTime(2020, 12, 30, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9845),
                            Status = 2
                        },
                        new
                        {
                            Id = 5L,
                            EndDate = new DateTime(2021, 1, 12, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9856),
                            MessageAboutAction = "Cant miss!! Vitamin C just for 99$",
                            PharmacyName = "PH2",
                            StartDate = new DateTime(2020, 12, 28, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9852),
                            Status = 2
                        },
                        new
                        {
                            Id = 6L,
                            EndDate = new DateTime(2020, 12, 27, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9863),
                            MessageAboutAction = "Cheap sedatives!",
                            PharmacyName = "PH1",
                            StartDate = new DateTime(2020, 12, 18, 22, 1, 58, 56, DateTimeKind.Local).AddTicks(9859),
                            Status = 1
                        });
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Model.Api", b =>
                {
                    b.Property<string>("NameOfPharmacy")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ApiKey")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("NameOfPharmacy");

                    b.ToTable("ApiKeys");

                    b.HasData(
                        new
                        {
                            NameOfPharmacy = "PH1",
                            ApiKey = "4545-as84-8s8g-zXCV",
                            Url = "http://localhost:4200/Ph1"
                        },
                        new
                        {
                            NameOfPharmacy = "PH2",
                            ApiKey = "7788-AV5R-zxQt-5845",
                            Url = "http://localhost:4200/Ph2"
                        },
                        new
                        {
                            NameOfPharmacy = "PH3",
                            ApiKey = "9745-At7S-Aqtr-5q8t",
                            Url = "http://localhost:4200/Ph3"
                        },
                        new
                        {
                            NameOfPharmacy = "PH4",
                            ApiKey = "HgT8-n47E-bE41-2gt5",
                            Url = "http://localhost:4200/Ph4"
                        });
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Model.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("MedicationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicationId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Model.Medication", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<bool>("Approved")
                        .HasColumnType("tinyint(1)");

                    b.Property<long?>("MedicationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long?>("TenderId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TenderOfferId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MedicationId");

                    b.HasIndex("TenderId");

                    b.HasIndex("TenderOfferId");

                    b.ToTable("Medication");
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Model.Pharmacy.Tender", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Tender");
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Model.Pharmacy.TenderOffer", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Message")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PharmacyName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("TenderOffers");
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Model.Ingredient", b =>
                {
                    b.HasOne("PSW_Pharmacy_Adapter.Model.Medication", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("MedicationId");
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Model.Medication", b =>
                {
                    b.HasOne("PSW_Pharmacy_Adapter.Model.Medication", null)
                        .WithMany("Alternative")
                        .HasForeignKey("MedicationId");

                    b.HasOne("PSW_Pharmacy_Adapter.Model.Pharmacy.Tender", null)
                        .WithMany("Medications")
                        .HasForeignKey("TenderId");

                    b.HasOne("PSW_Pharmacy_Adapter.Model.Pharmacy.TenderOffer", null)
                        .WithMany("Medications")
                        .HasForeignKey("TenderOfferId");
                });
#pragma warning restore 612, 618
        }
    }
}