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
    public class DoctorRepository: BaseRepository<Doctor>
    {
        private readonly ApplicationContext _repository;

        public DoctorRepository(ApplicationContext repository) : base(repository) 
        {
            _repository = repository;
        }
        public IEnumerable<Doctor> GetBySpeciality(Speciality speciality) 
        {
            var doctors = _repository.Doctors
                                  .Where(a => a.Speciality == speciality)
                                  .ToList();
            return doctors;
        }
    }
}
