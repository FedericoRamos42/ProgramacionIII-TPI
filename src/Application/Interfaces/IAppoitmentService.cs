using Application.Models;
using Application.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAppoitmentService
    {
        public void GenerateAppointmentForDoctor(int doctorId, DateRangeRequest Date);
        AppoitmentDto GetById(int id);
        //AppoitmentDto CreateAppoinment(AppoitmentCreateRequest appoitment);
        IEnumerable<AppoitmentDto> GetAllByDoctorId(int id);
        IEnumerable<AppoitmentDto> GetByDoctorAndDate(int idDoctor, DateTime date);
    }
}
