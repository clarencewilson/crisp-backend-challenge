﻿// <auto-generated />
using System;
using CRISP.BackendChallenge.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRISP.BackendChallenge.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("CRISP.BackendChallenge.Context.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Department")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = 1,
                            Name = "John Doe",
                            StartDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Department = 2,
                            Name = "Jane Doe",
                            StartDate = new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Department = 1,
                            Name = "Joe Doe",
                            StartDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Department = 1,
                            EndDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Leroy Jenkins",
                            StartDate = new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CRISP.BackendChallenge.Context.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LoginDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Logins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 1,
                            LoginDate = new DateTime(2022, 7, 2, 8, 15, 55, 879, DateTimeKind.Local).AddTicks(2166)
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 1,
                            LoginDate = new DateTime(2022, 6, 2, 8, 15, 55, 879, DateTimeKind.Local).AddTicks(2195)
                        },
                        new
                        {
                            Id = 3,
                            EmployeeId = 1,
                            LoginDate = new DateTime(2022, 5, 2, 8, 15, 55, 879, DateTimeKind.Local).AddTicks(2197)
                        },
                        new
                        {
                            Id = 4,
                            EmployeeId = 2,
                            LoginDate = new DateTime(2022, 7, 2, 8, 15, 55, 879, DateTimeKind.Local).AddTicks(2199)
                        },
                        new
                        {
                            Id = 5,
                            EmployeeId = 2,
                            LoginDate = new DateTime(2022, 6, 2, 8, 15, 55, 879, DateTimeKind.Local).AddTicks(2200)
                        },
                        new
                        {
                            Id = 6,
                            EmployeeId = 3,
                            LoginDate = new DateTime(2022, 7, 2, 8, 15, 55, 879, DateTimeKind.Local).AddTicks(2202)
                        });
                });

            modelBuilder.Entity("CRISP.BackendChallenge.Context.Models.Login", b =>
                {
                    b.HasOne("CRISP.BackendChallenge.Context.Models.Employee", null)
                        .WithMany("Logins")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CRISP.BackendChallenge.Context.Models.Employee", b =>
                {
                    b.Navigation("Logins");
                });
#pragma warning restore 612, 618
        }
    }
}
