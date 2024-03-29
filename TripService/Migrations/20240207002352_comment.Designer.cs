﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using KayakTracker.Infrastructure;

#nullable disable

namespace KayakTracker.Migrations
{
    [DbContext(typeof(TripDbContext))]
    [Migration("20240207002352_comment")]
    partial class comment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KayakTracker.Domain.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TripId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Comment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Text = "My test comment about the river",
                            TripId = 1,
                            UserId = "1"
                        });
                });

            modelBuilder.Entity("KayakTracker.Domain.Models.Highlight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Coordinates")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TripId")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Highlight");
                });

            modelBuilder.Entity("KayakTracker.Domain.Models.River", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("River");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Test River",
                            Name = "Test River",
                            State = 34
                        });
                });

            modelBuilder.Entity("KayakTracker.Domain.Models.TripAttendee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("TripId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("TripAttendee");
                });

            modelBuilder.Entity("KayakTracker.Domain.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double?>("AvgSpeed")
                        .HasColumnType("double precision");

                    b.Property<double>("DistanceMiles")
                        .HasColumnType("double precision");

                    b.Property<string>("EndCoordinates")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EndName")
                        .HasColumnType("text");

                    b.Property<double?>("Flow")
                        .HasColumnType("double precision");

                    b.Property<string>("MeasuredAt")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RiverId")
                        .HasColumnType("integer");

                    b.Property<string>("Stage")
                        .HasColumnType("text");

                    b.Property<string>("StartCoordinates")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("StartName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<double?>("TimeMinutes")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("RiverId");

                    b.ToTable("Trips");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvgSpeed = 6.0,
                            DistanceMiles = 10.0,
                            EndDate = new DateTime(2024, 2, 7, 0, 23, 51, 960, DateTimeKind.Utc).AddTicks(8104),
                            Notes = "notes",
                            OwnerId = "1",
                            RiverId = 1,
                            StartCoordinates = "37.362,-91.543",
                            StartDate = new DateTime(2024, 2, 7, 0, 23, 51, 960, DateTimeKind.Utc).AddTicks(8095),
                            StartName = "boat ramp",
                            State = 0,
                            TimeMinutes = 600.0
                        });
                });

            modelBuilder.Entity("KayakTracker.Domain.Models.Comment", b =>
                {
                    b.HasOne("KayakTracker.Domain.Models.Trip", null)
                        .WithMany("Comments")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KayakTracker.Domain.Models.Highlight", b =>
                {
                    b.HasOne("KayakTracker.Domain.Models.Trip", "Trip")
                        .WithMany("Highlights")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("KayakTracker.Domain.Models.TripAttendee", b =>
                {
                    b.HasOne("KayakTracker.Domain.Models.Trip", null)
                        .WithMany("TripAttendees")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KayakTracker.Domain.Models.Trip", b =>
                {
                    b.HasOne("KayakTracker.Domain.Models.River", "River")
                        .WithMany()
                        .HasForeignKey("RiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("River");
                });

            modelBuilder.Entity("KayakTracker.Domain.Models.Trip", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Highlights");

                    b.Navigation("TripAttendees");
                });
#pragma warning restore 612, 618
        }
    }
}
