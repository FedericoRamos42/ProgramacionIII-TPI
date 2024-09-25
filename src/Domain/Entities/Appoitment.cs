using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appoitment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAppointment { get; set; }
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime Date {  get; set; }
        public TimeSpan Time{ get; set; }
        public string Office {  get; set; } = string.Empty;
        public AppoitmentStatus Status { get; set; }
        
    }
}
