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
    public class DoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly IAddressRepository _addressRepository;
        public DoctorService(IDoctorRepository repository, IAddressRepository addresRepository)
        {
            _repository = repository;
            _addressRepository = addresRepository;
        }

        public DoctorDto GetById(int id)
        {
            var doctor = _repository.GetByIdIncludeAddress(id);
            return DoctorDto.CreateDoctorDto(doctor);
        }

        public IEnumerable<DoctorDto> GetAll()
        {
            var list = _repository.GetAll();
            return DoctorDto.CreatelistDto(list);
        }
        public DoctorDto CreateDoctor(DoctorCreateRequest doctor)
        {
            var newAdress = new Address()
            {
                Street = doctor.Address.Street,
                PostalCode = doctor.Address.PostalCode,
                City = doctor.Address.City,
                Province = doctor.Address.Province,
            };

            var entity = new Doctor()
            {
                Name = doctor.Name,
                LastName = doctor.LastName,
                PhoneNumber = doctor.PhoneNumber,
                DateOfBirth = doctor.DateOfBirth,
                Speciality = doctor.Speciality,
                LicenseNumber = doctor.LicenseNumber,
                Address = newAdress,
                Email = doctor.Email,
                Password = doctor.Password
            };

            try
            {
                var newEntity = _repository.Create(entity);
                return DoctorDto.CreateDoctorDto(newEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the patient.", ex);
            }
        }
        public DoctorDto DeleteDoctor(int id) 
        {
           var doctor = _repository.GetByIdIncludeAddress(id);
           var entity = _repository.Delete(doctor);
           return DoctorDto.CreateDoctorDto(entity);
            
        }
    }
}
