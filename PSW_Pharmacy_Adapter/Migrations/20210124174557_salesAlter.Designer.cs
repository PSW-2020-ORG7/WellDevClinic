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
    [Migration("20210124174557_salesAlter")]
    partial class salesAlter
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
                });

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model.Sale", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("PharmacyName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SaleMessage")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sales");
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

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model.Sale", b =>
                {
                    b.OwnsOne("PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Model.Period", "ValPeriod", b1 =>
                        {
                            b1.Property<long>("SaleId")
                                .HasColumnType("bigint");

                            b1.Property<DateTime>("EndDate")
                                .HasColumnType("datetime(6)");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("datetime(6)");

                            b1.HasKey("SaleId");

                            b1.ToTable("Sales");

                            b1.WithOwner()
                                .HasForeignKey("SaleId");
                        });
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

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.PharmacyEmails", b =>
                {
                    b.OwnsOne("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.Email", "Mail", b1 =>
                        {
                            b1.Property<long>("PharmacyEmailsId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Mail")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.HasKey("PharmacyEmailsId");

                            b1.ToTable("Email");

                            b1.WithOwner()
                                .HasForeignKey("PharmacyEmailsId");
                        });
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

            modelBuilder.Entity("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.TenderOffer", b =>
                {
                    b.OwnsOne("PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model.Email", "Mail", b1 =>
                        {
                            b1.Property<long>("TenderOfferId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Mail")
                                .HasColumnType("longtext CHARACTER SET utf8mb4");

                            b1.HasKey("TenderOfferId");

                            b1.ToTable("TenderOffers");

                            b1.WithOwner()
                                .HasForeignKey("TenderOfferId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}