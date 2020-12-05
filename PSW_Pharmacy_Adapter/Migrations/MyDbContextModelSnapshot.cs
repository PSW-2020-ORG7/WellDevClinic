﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSW_Pharmacy_Adapter.Model;

namespace PSW_Pharmacy_Adapter.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("Id");

                    b.ToTable("ActionsAndBenefits");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            EndDate = new DateTime(2020, 12, 18, 1, 57, 10, 784, DateTimeKind.Local).AddTicks(5703),
                            MessageAboutAction = "Andol on sale! 50% off!!",
                            PharmacyName = "PH1",
                            StartDate = new DateTime(2020, 12, 13, 1, 57, 10, 774, DateTimeKind.Local).AddTicks(2347)
                        },
                        new
                        {
                            Id = 2L,
                            EndDate = new DateTime(2021, 1, 2, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(5847),
                            MessageAboutAction = "Cheap bromazepam on huge quantities!!",
                            PharmacyName = "PH1",
                            StartDate = new DateTime(2020, 12, 8, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(5804)
                        },
                        new
                        {
                            Id = 3L,
                            EndDate = new DateTime(2020, 12, 10, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(5983),
                            MessageAboutAction = "Aspirin C for free!!",
                            PharmacyName = "PH3",
                            StartDate = new DateTime(2020, 12, 4, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(5975)
                        },
                        new
                        {
                            Id = 4L,
                            EndDate = new DateTime(2020, 12, 25, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(6084),
                            MessageAboutAction = "Amazing deal!! Brufen was 5$, now 15$",
                            PharmacyName = "PH3",
                            StartDate = new DateTime(2020, 12, 5, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(6076)
                        },
                        new
                        {
                            Id = 5L,
                            EndDate = new DateTime(2020, 12, 5, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(6109),
                            MessageAboutAction = "Cant miss!! Vitamin C just for 99$",
                            PharmacyName = "PH2",
                            StartDate = new DateTime(2020, 12, 3, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(6103)
                        },
                        new
                        {
                            Id = 6L,
                            EndDate = new DateTime(2020, 12, 4, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(6123),
                            MessageAboutAction = "Cheap sedatives!",
                            PharmacyName = "PH1",
                            StartDate = new DateTime(2020, 12, 3, 1, 57, 10, 785, DateTimeKind.Local).AddTicks(6117)
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
                            Url = "localhost:4200/Ph1"
                        },
                        new
                        {
                            NameOfPharmacy = "PH2",
                            ApiKey = "7788-AV5R-zxQt-5845",
                            Url = "localhost:4200/Ph2"
                        },
                        new
                        {
                            NameOfPharmacy = "PH3",
                            ApiKey = "9745-At7S-Aqtr-5q8t",
                            Url = "localhost:4200/Ph3"
                        },
                        new
                        {
                            NameOfPharmacy = "PH4",
                            ApiKey = "HgT8-n47E-bE41-2gt5",
                            Url = "localhost:4200/Ph4"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
