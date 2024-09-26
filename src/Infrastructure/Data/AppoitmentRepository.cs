using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppoitmentRepository
    {
        private readonly ApplicationContext _repository;

        public AppoitmentRepository(ApplicationContext repository)
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

        public IEnumerable<Appoitment> GetAppoitmentByPatientId(DateTime date)
        {
            var appoitments = _repository.Appoitments.
                                        Where(a=>a.Date == date)
                                        .ToList();
                                       
            return appoitments;
        }

        public Appoitment CreateAppoitment(Appoitment appoitment)
        {
            _repository.Appoitments.Add(appoitment);
            _repository.SaveChanges();
            return appoitment;
        }
        public Appoitment UpdateAppoitment (Appoitment appoitment)
        {
            _repository.Appoitments.Update(appoitment);
            _repository.SaveChanges();
            return appoitment;
        }
        public Appoitment DeleteAppoitment(Appoitment appoitment)
        {
            _repository.Appoitments.Remove(appoitment);
            _repository.SaveChanges();
            return appoitment;
        }
    }
}
