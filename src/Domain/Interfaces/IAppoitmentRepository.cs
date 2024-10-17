using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Interfaces
{
    public interface IAppoitmentRepository : IBaseRepository<Appoitment>
    {
        Appoitment? GetAppoitmentByWithPatientAndDoctor(int id);
        IEnumerable<Appoitment> GetAppoitmentByPatientId(int patientId);
        IEnumerable<Appoitment> GetAppoitmentByDoctorId(int doctorId);
        IEnumerable<Appoitment> GetAvailableAppointmentsByDoctorAndDate(int doctorId, DateTime date);
        
    }
}
