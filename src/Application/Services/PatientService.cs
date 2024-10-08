using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IAddressRepository _addressRepository;

        public PatientService(IPatientRepository patientRepository, IAddressRepository addressRepository)
        {
            _repository = patientRepository;
            _addressRepository = addressRepository;
        }
        public PatientDto? GetPatientById(int id) 
        {
            var Patient = _repository.GetByIdIncludeAddress(id);
            return PatientDto.CreatePatient(Patient);

        }

        public IEnumerable<PatientDto> GetAllPatients() 
        {
            var listPatient = _repository.GetAllPatientWithAddress();
            return PatientDto.CreateList(listPatient);
        }

        public PatientDto CreatePatient(PatientCreateRequest patient) 
        {
            var newAdress = new Address()
            {
                Street = patient.Address.Street,
                PostalCode = patient.Address.PostalCode,
                City = patient.Address.City,
                Province = patient.Address.Province,
            };

            var entity = new Patient()
            {
                Name = patient.Name,
                LastName = patient.LastName,
                PhoneNumber = patient.PhoneNumber,
                DateOfBirth = patient.DateOfBirth,
                MedicalInsurance = patient.MedicalInsurance,
                Address = newAdress,
                Email = patient.Email,
                Password = patient.Password,
            };

            try
            {
                var address = _addressRepository.Create(newAdress);
                var newEntity = _repository.Create(entity);
                return PatientDto.CreatePatient(newEntity);
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred while creating the patient.", ex);
            }
        }

        public PatientDto UpdatePatient(int id, UpdatePatientRequest patient)
        {
            var entity = _repository.GetById(id);
            
            entity.Name = patient.Name;
            entity.LastName = patient.LastName;
            entity.PhoneNumber = patient.PhoneNumber;
            entity.DateOfBirth = patient.DateOfBirth;
            entity.MedicalInsurance = patient.MedicalInsurance;

            var newEntity = _repository.Update(entity);
            return PatientDto.CreatePatient(newEntity);
        }

        public PatientDto DeletePatient(int id) 
        {
                var entity = _repository.GetByIdIncludeAddress(id);
                var patient = _repository.Delete(entity);
                return PatientDto.CreatePatient(entity);
            
        }

    }
}
