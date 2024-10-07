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

        public PatientService(IPatientRepository patient)
        {
            _repository = patient;
        }
        public Patient? GetPatientById(int id) 
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Patient> GetAllPatients() 
        {
            return _repository.GetAll();
        }

        public Patient CreatePatient(UpdatePatientRequest patient) 
        {

            var entity = new Patient()
            {
                Name = patient.Name,
                LastName = patient.LastName,
                PhoneNumber = patient.PhoneNumber,
                DateOfBirth = patient.DateOfBirth,
                MedicalInsurance = patient.MedicalInsurance,
            };

            return _repository.Create(entity);
        }

        public Patient UpdatePatient(int id, UpdatePatientRequest patient)
        {
            var entity = _repository.GetById(id);
            
            entity.Name = patient.Name;
            entity.LastName = patient.LastName;
            entity.PhoneNumber = patient.PhoneNumber;
            entity.DateOfBirth = patient.DateOfBirth;
            entity.MedicalInsurance = patient.MedicalInsurance;

            return _repository.Update(entity);
        }

        public Patient DeletePatient(int id) 
        {
            var entity = _repository.GetById(id);

            return _repository.Delete(entity);
        }

    }
}
