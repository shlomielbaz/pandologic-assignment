﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PA.Data;

#nullable disable

namespace PA.Data.Migrations
{
    [DbContext(typeof(JobContext))]
    [Migration("20240212054644_AddSeed")]
    partial class AddSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("PA.Domain.Job", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("date");

                    b.Property<int>("PredictedViews")
                        .HasColumnType("INTEGER")
                        .HasColumnName("predicted_views");

                    b.Property<int>("TotalJobs")
                        .HasColumnType("INTEGER")
                        .HasColumnName("total_jobs");

                    b.Property<int>("TotalViews")
                        .HasColumnType("INTEGER")
                        .HasColumnName("total_views");

                    b.HasKey("Id");

                    b.ToTable("jobs");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Date = new DateTime(2014, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PredictedViews = 0,
                            TotalJobs = 3,
                            TotalViews = 0
                        },
                        new
                        {
                            Id = 2L,
                            Date = new DateTime(2014, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PredictedViews = 1,
                            TotalJobs = 3,
                            TotalViews = 1
                        },
                        new
                        {
                            Id = 3L,
                            Date = new DateTime(2014, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PredictedViews = 3,
                            TotalJobs = 3,
                            TotalViews = 2
                        },
                        new
                        {
                            Id = 4L,
                            Date = new DateTime(2014, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PredictedViews = 3,
                            TotalJobs = 11,
                            TotalViews = 5
                        },
                        new
                        {
                            Id = 5L,
                            Date = new DateTime(2014, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PredictedViews = 4,
                            TotalJobs = 2,
                            TotalViews = 6
                        },
                        new
                        {
                            Id = 6L,
                            Date = new DateTime(2014, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PredictedViews = 8,
                            TotalJobs = 6,
                            TotalViews = 7
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
