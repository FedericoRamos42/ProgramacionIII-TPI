using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class AppoitmentDto
    {
        public int IdAppointment { get; set; }
        public int DoctorId { get; set; }
        public int? PatientId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Office { get; set; } = string.Empty;

        public static AppoitmentDto CreateDto(Appoitment appoitment)
        {
            var newAppoitmentDto = new AppoitmentDto() 
            {
                IdAppointment = appoitment.IdAppointment,
                DoctorId = appoitment.DoctorId,
                PatientId = appoitment.PatientId,
                Date = appoitment.Date,
                Time = appoitment.Time,
                Office = appoitment.Office,
            };
            return newAppoitmentDto;
        }

        public static IEnumerable<AppoitmentDto> CreateList(IEnumerable<Appoitment> list) 
        {
            List<AppoitmentDto>listDto = new List<AppoitmentDto>();
            foreach(Appoitment a in list)
            {
                listDto.Add(CreateDto(a));
            }
            return listDto;
        }

    }
}
