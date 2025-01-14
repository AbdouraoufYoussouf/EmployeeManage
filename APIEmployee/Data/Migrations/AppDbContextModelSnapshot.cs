﻿// <auto-generated />
using System;
using EmployeManagementAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIEmployee.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APIEmployee.Models.Departement", b =>
                {
                    b.Property<int>("DepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepId"), 1L, 1);

                    b.Property<string>("DepName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepId");

                    b.ToTable("Departements");

                    b.HasData(
                        new
                        {
                            DepId = 1,
                            DepName = "Informatique"
                        },
                        new
                        {
                            DepId = 2,
                            DepName = "Mathematique"
                        },
                        new
                        {
                            DepId = 3,
                            DepName = "Biologie"
                        },
                        new
                        {
                            DepId = 4,
                            DepName = "Geologie"
                        });
                });

            modelBuilder.Entity("APIEmployee.Models.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpId"), 1L, 1);

                    b.Property<DateTime>("DateOfBrith")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpId");

                    b.HasIndex("DepId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmpId = 1,
                            DateOfBrith = new DateTime(1980, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepId = 1,
                            Email = "David@pragimtech.com",
                            FirstName = "John",
                            LastName = "Hastings",
                            PhotoPath = "images/john.png"
                        },
                        new
                        {
                            EmpId = 2,
                            DateOfBrith = new DateTime(1981, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepId = 1,
                            Email = "Sam@pragimtech.com",
                            FirstName = "Sam",
                            LastName = "Galloway",
                            PhotoPath = "images/sam.jpg"
                        },
                        new
                        {
                            EmpId = 3,
                            DateOfBrith = new DateTime(1979, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepId = 4,
                            Email = "mary@pragimtech.com",
                            FirstName = "Mary",
                            LastName = "Smith",
                            PhotoPath = "images/mary.png"
                        },
                        new
                        {
                            EmpId = 4,
                            DateOfBrith = new DateTime(1982, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepId = 4,
                            Email = "sara@pragimtech.com",
                            FirstName = "Sara",
                            LastName = "Longway",
                            PhotoPath = "images/sara.png"
                        });
                });

            modelBuilder.Entity("APIEmployee.Models.Employee", b =>
                {
                    b.HasOne("APIEmployee.Models.Departement", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("APIEmployee.Models.Departement", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
