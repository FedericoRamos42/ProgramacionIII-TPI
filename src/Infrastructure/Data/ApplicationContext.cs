using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        private readonly bool isTestingEnviroment;

        public ApplicationContext(DbContextOptions<ApplicationContext> options, bool isTestingEnviroment = false) : base(options)
        {
            this.isTestingEnviroment = isTestingEnviroment;
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appoitment> Appoitments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Speciality> Specialities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasDiscriminator<UserRole>("UserRole")
                .HasValue<Doctor>(UserRole.Doctor)
                .HasValue<Patient>(UserRole.Patient)
                .HasValue<Admin>(UserRole.Admin);

            modelBuilder.Entity<Doctor>()
                .ToTable("Usuarios");

            modelBuilder.Entity<Patient>()
                .ToTable("Usuarios");

            modelBuilder.Entity<User>().ToTable("Usuarios");

            var userRoleConverter = new EnumToStringConverter<UserRole>();
            modelBuilder.Entity<User>()
                .Property(e => e.UserRole)
                .HasConversion(userRoleConverter);

            var appointmetStatusConverter = new EnumToStringConverter<AppoitmentStatus>();
            modelBuilder.Entity<Appoitment>()
                .Property(e => e.Status)
                .HasConversion(appointmetStatusConverter);

           

            modelBuilder.Entity<Doctor>()
               .HasMany(d => d.AssignedAppointment)
               .WithOne(a => a.Doctor)
               .HasForeignKey(a => a.DoctorId);

            
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Appoitments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Patient>()
                .HasOne(u => u.Address)   
                .WithOne(a => a.Patient)     
                .HasForeignKey<Address>(a => a.PatientId);

            modelBuilder.Entity<Speciality>()
                        .HasMany(p => p.SpecialityDoctors)
                        .WithOne(a => a.Speciality)
                        .HasForeignKey(a => a.SpecialityId);


            ///data harcodeada
          modelBuilder.Entity<Speciality>().HasData(
          new Speciality
          {
              Id = 1,
              Name = "Cardiology",
              Description = "Cardiology focuses on the diagnosis and treatment of heart conditions and disorders of the cardiovascular system."
          },
          new Speciality
          {
              Id = 2,
              Name = "Dermatology",
              Description = "Dermatology deals with the study, diagnosis, and treatment of skin, hair, and nail disorders."
          },
          new Speciality
          {
              Id = 3,
              Name = "Pediatrics",
              Description = "Pediatrics involves the medical care of infants, children, and adolescents up to the age of 18."
          },
          new Speciality
          {
              Id = 4,
              Name = "Orthopedics",
              Description = "Orthopedics specializes in the diagnosis, correction, prevention, and treatment of skeletal deformities, including bones, joints, muscles, and ligaments."
          },
          new Speciality
          {
              Id = 5,
              Name = "Dentist",
              Description = "Dentistry is the branch of medicine that involves the study, diagnosis, prevention, and treatment of diseases and conditions of the oral cavity."
          }
      );

            // Agregar direcciones (proporcionando Ids)
            modelBuilder.Entity<Patient>().HasData(
            new Patient { Id = 1, Name = "John", LastName = "Doe", PhoneNumber = "1234567890", DateOfBirth = new DateTime(1980, 1, 1), Email = "john.doe@example.com", Password = "password123", MedicalInsurance = "HealthInsure" },
            new Patient { Id = 2, Name = "Jane", LastName = "Smith", PhoneNumber = "0987654321", DateOfBirth = new DateTime(1990, 2, 2), Email = "jane.smith@example.com", Password = "password123", MedicalInsurance = "HealthInsure" }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, Street = "123 Main St", City = "Springfield", Province = "IL", PostalCode = "62701", PatientId = 1 },
                new Address { Id = 2, Street = "456 Elm St", City = "Springfield", Province = "IL", PostalCode = "62702", PatientId = 2 }
            );

            // Agregar doctores
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 3, Name = "Dr. Sarah", LastName = "Johnson", PhoneNumber = "1231231234", DateOfBirth = new DateTime(1975, 3, 3), Email = "dr.sarah@example.com", Password = "password123", LicenseNumber = 123456, SpecialityId = 1 },
                new Doctor { Id = 4, Name = "Dr. Alex", LastName = "Williams", PhoneNumber = "3213214321", DateOfBirth = new DateTime(1985, 4, 4), Email = "dr.alex@example.com", Password = "password123", LicenseNumber = 654321, SpecialityId = 2 }
            );
        }
    }
}
