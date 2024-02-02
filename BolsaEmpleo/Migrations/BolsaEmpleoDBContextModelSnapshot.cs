﻿// <auto-generated />
using BolsaEmpleo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BolsaEmpleo.Migrations
{
    [DbContext(typeof(BolsaEmpleoDBContext))]
    partial class BolsaEmpleoDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BolsaEmpleo.Models.Type", b =>
                {
                    b.Property<int>("typeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("typeId"));

                    b.Property<string>("typeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("typeId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("BolsaEmpleo.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<int>("typeId")
                        .HasColumnType("int");

                    b.Property<string>("userBirthday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userIdentification")
                        .HasColumnType("int");

                    b.Property<string>("userLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userProfession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userSalary")
                        .HasColumnType("int");

                    b.HasKey("userId");

                    b.HasIndex("typeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BolsaEmpleo.Models.Vacancies", b =>
                {
                    b.Property<int>("vacantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("vacantId"));

                    b.Property<string>("vacantCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vacantCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vacantDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vacantJobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vacantSalary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("vacantId");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("BolsaEmpleo.Models.VacantApplication", b =>
                {
                    b.Property<int>("vacantApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("vacantApplicationID"));

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.Property<int>("vacantId")
                        .HasColumnType("int");

                    b.HasKey("vacantApplicationID");

                    b.HasIndex("userId");

                    b.HasIndex("vacantId");

                    b.ToTable("VacantApplications");
                });

            modelBuilder.Entity("BolsaEmpleo.Models.User", b =>
                {
                    b.HasOne("BolsaEmpleo.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("typeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("BolsaEmpleo.Models.VacantApplication", b =>
                {
                    b.HasOne("BolsaEmpleo.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BolsaEmpleo.Models.Vacancies", "Vacancies")
                        .WithMany()
                        .HasForeignKey("vacantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Vacancies");
                });
#pragma warning restore 612, 618
        }
    }
}
