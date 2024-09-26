using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DoctorRepository
    {
        private readonly ApplicationContext _repository;

        public DoctorRepository(ApplicationContext repository)
        {
            _repository = repository;
        }

        public Doctor? GetById(int id) 
        {
            return _repository.Doctors.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Doctor> GetBySpeciality(Speciality speciality) 
        {
            var doctors = _repository.Doctors
                                  .Where(a => a.Speciality == speciality)
                                  .ToList();
            return doctors;
        }

        public IEnumerable<Doctor> GetAll() 
        {
            return _repository.Doctors.ToList();
        }

        public Doctor CreateDoctor(Doctor doctor) 
        {
            _repository.Doctors.Add(doctor);
            _repository.SaveChanges();
            return doctor;
        }
        public Doctor DeleteDoctor(Doctor doctor) 
        {
            _repository.Doctors.Remove(doctor);
            _repository.SaveChanges();
            return doctor;
        }
        public Doctor UpdateDoctor(Doctor doctor)
        {
            _repository.Doctors.Update(doctor);
            _repository.SaveChanges();
            return doctor;
        }
    }
}
