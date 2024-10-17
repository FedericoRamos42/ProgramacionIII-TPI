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

        public PatientService(IPatientRepository patientRepository)
        {
            _repository = patientRepository;
        }

        public PatientDto? GetPatientById(int id) 
        {
            var Patient = _repository.GetByIdIncludeAddress(id);
            if (Patient != null) 
            {
                return PatientDto.CreatePatient(Patient);

            }

            throw new ArgumentException("failled");

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

                var newEntity = _repository.Create(entity);
                return PatientDto.CreatePatient(newEntity);
            
            
        }

        public PatientDto UpdatePatient(int id, UpdatePatientRequest patient)
        {
            var entity = _repository.GetByIdIncludeAddress(id);

            if (entity != null)
            {
                entity.Name = patient.Name;
                entity.LastName = patient.LastName;
                entity.PhoneNumber = patient.PhoneNumber;
                entity.DateOfBirth = patient.DateOfBirth;
                entity.MedicalInsurance = patient.MedicalInsurance;

                if (patient.Address != null ) 
                {
                    entity.Address.City = patient.Address.City;
                    entity.Address.Street = patient.Address.Street;
                    entity.Address.Province = patient.Address.Province;
                    entity.Address.PostalCode = patient.Address.PostalCode;

                }
                var newEntity = _repository.Update(entity);
                return PatientDto.CreatePatient(newEntity);
            }

            throw new ArgumentException("All fields are required.");
        }

        public PatientDto DeletePatient(int id) 
        {
            
            var entity = _repository.GetByIdIncludeAddress(id);

            if (entity != null) 
            {
                var patient = _repository.Delete(entity);
                return PatientDto.CreatePatient(patient);
            }
            throw new ArgumentException("failled");
            
        }

    }
}
