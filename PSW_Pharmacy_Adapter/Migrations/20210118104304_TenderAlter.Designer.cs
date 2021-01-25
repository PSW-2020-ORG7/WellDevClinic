﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSW_Pharmacy_Adapter;

namespace PSW_Pharmacy_Adapter.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20210118104304_TenderAlter")]
    partial class TenderAlter
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Pharmacy_Microservice.Domain.Model.Api", b =>
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

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model.ActionAndBenefit", b =>
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
                            EndDate = new DateTime(2021, 2, 2, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(1090),
                            MessageAboutAction = "Andol on sale! 50% off!!",
                            PharmacyName = "PH1",
                            StartDate = new DateTime(2021, 1, 8, 11, 43, 3, 351, DateTimeKind.Local).AddTicks(6393),
                            Status = 1
                        },
                        new
                        {
                            Id = 2L,
                            EndDate = new DateTime(2021, 2, 17, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8367),
                            MessageAboutAction = "Cheap bromazepam on huge quantities!!",
                            PharmacyName = "PH1",
                            StartDate = new DateTime(2021, 1, 23, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8323),
                            Status = 0
                        },
                        new
                        {
                            Id = 3L,
                            EndDate = new DateTime(2021, 1, 25, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8468),
                            MessageAboutAction = "Aspirin C for free!!",
                            PharmacyName = "PH3",
                            StartDate = new DateTime(2021, 1, 19, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8463),
                            Status = 0
                        },
                        new
                        {
                            Id = 4L,
                            EndDate = new DateTime(2021, 2, 9, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8478),
                            MessageAboutAction = "Amazing deal!! Brufen was 5$, now 15$",
                            PharmacyName = "PH3",
                            StartDate = new DateTime(2021, 1, 20, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8474),
                            Status = 2
                        },
                        new
                        {
                            Id = 5L,
                            EndDate = new DateTime(2021, 2, 2, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8486),
                            MessageAboutAction = "Cant miss!! Vitamin C just for 99$",
                            PharmacyName = "PH2",
                            StartDate = new DateTime(2021, 1, 18, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8482),
                            Status = 2
                        },
                        new
                        {
                            Id = 6L,
                            EndDate = new DateTime(2021, 1, 17, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8494),
                            MessageAboutAction = "Cheap sedatives!",
                            PharmacyName = "PH1",
                            StartDate = new DateTime(2021, 1, 8, 11, 43, 3, 355, DateTimeKind.Local).AddTicks(8491),
                            Status = 1
                        });
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.Ingredient", b =>
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

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.Medication", b =>
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

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.PharmacyEmails", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.Tender", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("OfferWinner")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Tender");
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.TenderOffer", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Message")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PharmacyName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<long>("TenderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("TenderOffers");
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.Ingredient", b =>
                {
                    b.HasOne("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.Medication", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("MedicationId");
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.Medication", b =>
                {
                    b.HasOne("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.Medication", null)
                        .WithMany("Alternative")
                        .HasForeignKey("MedicationId");

                    b.HasOne("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.Tender", null)
                        .WithMany("Medications")
                        .HasForeignKey("TenderId");

                    b.HasOne("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.TenderOffer", null)
                        .WithMany("Medications")
                        .HasForeignKey("TenderOfferId");
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.Tender", b =>
                {
                    b.OwnsOne("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.Period", "Period", b1 =>
                        {
                            b1.Property<long>("TenderId")
                                .HasColumnType("bigint");

                            b1.Property<DateTime>("EndDate")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("datetime(6)");

                            b1.HasKey("TenderId");

                            b1.ToTable("Tender");

                            b1.WithOwner()
                                .HasForeignKey("TenderId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}