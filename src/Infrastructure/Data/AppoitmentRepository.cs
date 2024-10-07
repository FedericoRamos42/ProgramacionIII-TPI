using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppoitmentRepository : BaseRepository<Appoitment>
    {
        private readonly ApplicationContext _repository;

        public AppoitmentRepository(ApplicationContext repository) : base(repository) 
        {
            _repository = repository;
        }

        //public IEnumerable<Appoitment> GetAppoitmentByDoctorId(int doctorId)
        //{
        //    var appoitments = _repository.Appoitments
        //                                .Where(a => a.DoctorId == doctorId)
        //                                .Include(a => a.Patient)
        //                                .ToList();
        //    return appoitments;
        //}
        //public IEnumerable<Appoitment> GetAppoitmentByPatientId(int patientId)
        //{
        //    var appoitments = _repository.Appoitments
        //                                .Where(a => a.PatientId == patientId)
        //                                .Include(a => a.DoctorId)
        //                                .ToList();

        //    return appoitments;
        //}

        public IEnumerable<Appoitment> GetAppoitmentByDate(DateTime date)
        {
            var appoitments = _repository.Appoitments
                                        .Where(a=>a.Date == date)
                                        .ToList();
            return appoitments;
        }
    }
}
