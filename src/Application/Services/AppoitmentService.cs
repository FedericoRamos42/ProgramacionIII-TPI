using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Services
{
    public class AppoitmentService: IAppoitmentService
    {
        private readonly IAppoitmentRepository _appoitmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public AppoitmentService(IAppoitmentRepository repository, IDoctorRepository doctorRepository, IPatientRepository patientRepository)
        {
            _appoitmentRepository = repository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
        }
        public void GenerateAppointmentForDoctor(int doctorId, DateRangeRequest Date)
        {
            var doctor = _doctorRepository.GetById(doctorId);
            if (doctor == null)
            {
                throw new Exception("Doctor no encontrado.");
            }

            for (var date = Date.StartDate; date <= Date.EndDate; date = date.AddDays(1)) // Iterar sobre los días
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue; // Saltar sábados y domingos
                }


                for (var time = new TimeSpan(9, 0, 0); time < new TimeSpan(12, 0, 0); time = time.Add(new TimeSpan(1, 0, 0))) // Iterar de 9:00 a 12:00
                {
                    var appointment = new Appoitment
                    {
                        DoctorId = doctorId,
                        Date = date.Date,
                        Time = time,
                        Status = AppoitmentStatus.Available // Precarga como disponible
                    };
                    _appoitmentRepository.Create(appointment);
                }


                for (var time = new TimeSpan(14, 0, 0); time < new TimeSpan(18, 0, 0); time = time.Add(new TimeSpan(1, 0, 0))) // Iterar de 14:00 a 18:00
                {
                    var appointment = new Appoitment
                    {
                        DoctorId = doctorId,
                        Date = date.Date,
                        Time = time,
                        Status = AppoitmentStatus.Available, // Precarga como disponible
                        PatientId = null
                    };
                    _appoitmentRepository.Create(appointment);
                }
            }

        }
        public AppoitmentDto GetById(int id)
        {
            var appoitment = _appoitmentRepository.GetAppoitmentByWithPatientAndDoctor(id);

            return AppoitmentDto.CreateDto(appoitment);
        }

        public AppoitmentDto CreateAppoinment(AppoitmentCreateRequest appoitment)
        {
            var newAppoitment = new Appoitment()
            {
                //Doctor = appoitment.Doctor,
                //Patient = appoitment.Patient,
                Time = appoitment.Time,
                Date = appoitment.Date,
                Office = appoitment.Office,
            };

            var enitity = _appoitmentRepository.Create(newAppoitment);
            return AppoitmentDto.CreateDto(enitity);
        }

        public IEnumerable<AppoitmentDto> GetAllByDoctorId(int id)
        {
             var listAppointments = _appoitmentRepository.GetAppoitmentByDoctorId(id);
            return AppoitmentDto.CreateList(listAppointments);
        }
    }
}
