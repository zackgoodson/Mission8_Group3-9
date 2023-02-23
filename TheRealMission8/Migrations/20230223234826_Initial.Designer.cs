﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheRealMission8.Models;

namespace TheRealMission8.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20230223234826_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("TheRealMission8.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Home"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Work"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "School"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Church"
                        });
                });

            modelBuilder.Entity("TheRealMission8.Models.TaskResponse", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Due")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quadrant")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TaskID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            TaskID = 1,
                            CategoryID = 3,
                            Completed = false,
                            Due = "2/24/2023",
                            Quadrant = 1,
                            Task = "Mission 8"
                        },
                        new
                        {
                            TaskID = 2,
                            CategoryID = 3,
                            Completed = false,
                            Due = "2/29/2023",
                            Quadrant = 1,
                            Task = "Mission 9"
                        },
                        new
                        {
                            TaskID = 3,
                            CategoryID = 3,
                            Completed = true,
                            Due = "2/21/2023",
                            Quadrant = 1,
                            Task = "Mission 7"
                        });
                });

            modelBuilder.Entity("TheRealMission8.Models.TaskResponse", b =>
                {
                    b.HasOne("TheRealMission8.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}