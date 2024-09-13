﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SQL;

#nullable disable

namespace SQL.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    partial class CompanyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Area", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AreaId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AreaId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InitiationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("LeaderId")
                        .HasColumnType("int");

                    b.Property<bool>("ModifyOverTimeReport")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("AreaId");

                    b.HasIndex("LeaderId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Entities.OverTimeReport", b =>
                {
                    b.Property<int>("OverTimeReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OverTimeReportId"));

                    b.Property<DateTime>("DateReport")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("GetState")
                        .HasColumnType("int");

                    b.Property<bool>("IsRemunerated")
                        .HasColumnType("bit");

                    b.Property<string>("Motive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ReportedHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("OverTimeReportId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("OverTimeReports");
                });

            modelBuilder.Entity("Entities.Employee", b =>
                {
                    b.HasOne("Entities.Area", "Area")
                        .WithMany("Employees")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Employee", "Leader")
                        .WithMany("Subordinates")
                        .HasForeignKey("LeaderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Area");

                    b.Navigation("Leader");
                });

            modelBuilder.Entity("Entities.OverTimeReport", b =>
                {
                    b.HasOne("Entities.Employee", "Employee")
                        .WithMany("OverTimeReports")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Entities.Area", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Entities.Employee", b =>
                {
                    b.Navigation("OverTimeReports");

                    b.Navigation("Subordinates");
                });
#pragma warning restore 612, 618
        }
    }
}
