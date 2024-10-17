using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
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
    public class DoctorRepository: BaseRepository<Doctor>,IDoctorRepository
    {
        private readonly ApplicationContext _repository;

        public DoctorRepository(ApplicationContext repository) : base(repository) 
        {
            _repository = repository;
        }
        
        public IEnumerable<Doctor> GetDoctorsBySpeciality(int id)
        {
            var doctors = _repository.Doctors.Where(p => p.SpecialityId == id)
                                             .ToList();

            return doctors;

        }
    }
}
