using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppoitmentRepository : BaseRepository<Appoitment>,IAppoitmentRepository
    {
        private readonly ApplicationContext _repository;

        public AppoitmentRepository(ApplicationContext repository) : base(repository) 
        {
            _repository = repository;
        }

        public IEnumerable<Appoitment> GetAppoitmentByDoctorId(int doctorId)
        {
            var appoitments = _repository.Appoitments
                                        .Where(a => a.DoctorId == doctorId)
                                        .Include(a => a.Patient)
                                        .ToList();
            return appoitments;
        }
        public IEnumerable<Appoitment> GetAppoitmentByPatientId(int patientId)
        {
            var appoitments = _repository.Appoitments
                                        .Where(a => a.PatientId == patientId)
                                        .Include(a => a.DoctorId)
                                        .ToList();

            return appoitments;
        }

        public Appoitment? GetAppoitmentByWithPatientAndDoctor(int id)
        {
            var appoitment = _repository.Appoitments
                                        .Include(c => c.Patient)
                                        .Include(c => c.Doctor)
                                        .FirstOrDefault(c => c.IdAppointment == id);
            return appoitment;

        }


        public IEnumerable<Appoitment> GetAvailableAppointmentsByDoctorAndDate(int doctorId, DateTime date) 
        {
            return _repository.Appoitments.Where(d=>d.Date == date && d.DoctorId == doctorId)
                                          .Include(d => d.Doctor)
                                          .Include(d=>d.Patient)
                                          .ToList();  
        }
    }
}
