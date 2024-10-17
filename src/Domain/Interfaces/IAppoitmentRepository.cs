using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAppoitmentRepository : IBaseRepository<Appoitment>
    {
        Appoitment? GetAppoitmentByWithPatientAndDoctor(int id);
        IEnumerable<Appoitment> GetAppoitmentByDoctorId(int doctorId);
    }
}
