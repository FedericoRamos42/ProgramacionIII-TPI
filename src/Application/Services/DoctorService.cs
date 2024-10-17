using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly ISpecialityRepository _speciality;

        public DoctorService(IDoctorRepository repository , ISpecialityRepository speciality)
        {
            _repository = repository;
            _speciality = speciality;
        }

        public DoctorDto GetById(int id)
        {
            var doctor = _repository.GetById(id);
            return DoctorDto.CreateDoctorDto(doctor);
        }
        public IEnumerable<DoctorDto> GetBySpeciality(int id) 
        {
            var listDoctor = _repository.GetDoctorsBySpeciality(id);    
            return DoctorDto.CreatelistDto(listDoctor);
        }

        public IEnumerable<DoctorDto> GetAll()
        {
            var list = _repository.GetAll();
            return DoctorDto.CreatelistDto(list);
        }
        public DoctorDto CreateDoctor( DoctorCreateRequest doctor)
        {

            var speciality = _speciality.GetById(doctor.SpecialityId);
            if (speciality == null) 
            {
                throw new ArgumentException("ERROR");
            }
            var entity = new Doctor()
            {
                Name = doctor.Name,
                LastName = doctor.LastName,
                PhoneNumber = doctor.PhoneNumber,
                DateOfBirth = doctor.DateOfBirth,
                LicenseNumber = doctor.LicenseNumber,
                SpecialityId = doctor.SpecialityId,
                Email = doctor.Email,
                Password = doctor.Password
            };

            
                var newEntity = _repository.Create(entity);
                return DoctorDto.CreateDoctorDto(newEntity);
        }

        public DoctorDto UpdateDoctor(int id,DoctorUpdateRequest doctor)
        {
            var entity = _repository.GetById(id);
            var Speciality = _speciality.GetById(doctor.SpecialityId);
            if (Speciality == null)
            {
                throw new ArgumentException("error");
            }

            if (entity != null)
            {
                entity.Name = doctor.Name;
                entity.LastName = doctor.LastName;
                entity.PhoneNumber = doctor.PhoneNumber;
                entity.DateOfBirth = doctor.DateOfBirth;
                entity.SpecialityId = doctor.SpecialityId;

               
                var newEntity = _repository.Update(entity);
                return DoctorDto.CreateDoctorDto(newEntity);
            }

            throw new ArgumentException("All fields are required.");
        }
        public DoctorDto DeleteDoctor(int id) 
        {
           var doctor = _repository.GetById(id);
           var entity = _repository.Delete(doctor);
           return DoctorDto.CreateDoctorDto(entity);
            
        }
    }
    
}
