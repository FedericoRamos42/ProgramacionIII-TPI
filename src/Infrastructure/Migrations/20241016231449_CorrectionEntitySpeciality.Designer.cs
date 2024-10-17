﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241016231449_CorrectionEntitySpeciality")]
    partial class CorrectionEntitySpeciality
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Springfield",
                            PatientId = 1,
                            PostalCode = "62701",
                            Province = "IL",
                            Street = "123 Main St"
                        },
                        new
                        {
                            Id = 2,
                            City = "Springfield",
                            PatientId = 2,
                            PostalCode = "62702",
                            Province = "IL",
                            Street = "456 Elm St"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Appoitment", b =>
                {
                    b.Property<int>("IdAppointment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("DoctorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Office")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("IdAppointment");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appoitments");
                });

            modelBuilder.Entity("Domain.Entities.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Specialities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "",
                            Name = "Cardiology"
                        },
                        new
                        {
                            Id = 2,
                            Description = "",
                            Name = "Dermatology"
                        },
                        new
                        {
                            Id = 3,
                            Description = "",
                            Name = "Pediatrics"
                        },
                        new
                        {
                            Id = 4,
                            Description = "",
                            Name = "Orthopedics"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);

                    b.HasDiscriminator<string>("UserRole");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Domain.Entities.Doctor", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.Property<int>("LicenseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpecialityId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Usuarios", (string)null);

                    b.HasDiscriminator().HasValue("Doctor");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(1975, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "dr.sarah@example.com",
                            IsAvailable = true,
                            LastName = "Johnson",
                            Name = "Dr. Sarah",
                            Password = "password123",
                            PhoneNumber = "1231231234",
                            UserRole = "Doctor",
                            LicenseNumber = 123456,
                            SpecialityId = 1
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(1985, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "dr.alex@example.com",
                            IsAvailable = true,
                            LastName = "Williams",
                            Name = "Dr. Alex",
                            Password = "password123",
                            PhoneNumber = "3213214321",
                            UserRole = "Doctor",
                            LicenseNumber = 654321,
                            SpecialityId = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.Patient", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.Property<string>("MedicalInsurance")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.ToTable("Usuarios", (string)null);

                    b.HasDiscriminator().HasValue("Patient");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john.doe@example.com",
                            IsAvailable = true,
                            LastName = "Doe",
                            Name = "John",
                            Password = "password123",
                            PhoneNumber = "1234567890",
                            UserRole = "Patient",
                            MedicalInsurance = "HealthInsure"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane.smith@example.com",
                            IsAvailable = true,
                            LastName = "Smith",
                            Name = "Jane",
                            Password = "password123",
                            PhoneNumber = "0987654321",
                            UserRole = "Patient",
                            MedicalInsurance = "HealthInsure"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.HasOne("Domain.Entities.Patient", "Patient")
                        .WithOne("Address")
                        .HasForeignKey("Domain.Entities.Address", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Entities.Appoitment", b =>
                {
                    b.HasOne("Domain.Entities.Doctor", "Doctor")
                        .WithMany("AssignedAppointment")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Patient", "Patient")
                        .WithMany("Appoitments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Entities.Doctor", b =>
                {
                    b.HasOne("Domain.Entities.Speciality", "Speciality")
                        .WithMany("SpecialityDoctors")
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("Domain.Entities.Speciality", b =>
                {
                    b.Navigation("SpecialityDoctors");
                });

            modelBuilder.Entity("Domain.Entities.Doctor", b =>
                {
                    b.Navigation("AssignedAppointment");
                });

            modelBuilder.Entity("Domain.Entities.Patient", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Appoitments");
                });
#pragma warning restore 612, 618
        }
    }
}
