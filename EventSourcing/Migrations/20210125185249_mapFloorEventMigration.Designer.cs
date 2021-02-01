﻿// <auto-generated />
using System;
using EventSourcing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventSourcing.Migrations
{
    [DbContext(typeof(EventDbContext))]
    [Migration("20210125185249_mapFloorEventMigration")]
    partial class mapFloorEventMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EventSourcing.Events.MapEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("BuildingName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("FloorLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("mapEvent");
                });

            modelBuilder.Entity("EventSourcing.Events.RoomEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("roomEvents");
                });

            modelBuilder.Entity("EventSourcing.FeedbackSubmittedEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long>("FeedbackId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("feedbackSubmittedEvents");
                });

            modelBuilder.Entity("EventSourcing.NewExaminationTimeSpent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<long>("ScheduleId")
                        .HasColumnType("bigint");

                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.Property<int>("StepType")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("newExaminationTimeSpent");
                });
#pragma warning restore 612, 618
        }
    }
}