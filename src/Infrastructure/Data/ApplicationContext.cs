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

            var doctorSpeciality = new EnumToStringConverter<Speciality>();
            modelBuilder.Entity<Doctor>()
                .Property(e => e.Speciality)
                .HasConversion(doctorSpeciality);

            modelBuilder.Entity<Doctor>()
               .HasMany(d => d.AssignedAppointment)
               .WithOne(a => a.Doctor)
               .HasForeignKey(a => a.DoctorId);

            
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Appoitments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)   
                .WithOne(a => a.User)     
                .HasForeignKey<Address>(a => a.UserId); 

        }
    }
}
