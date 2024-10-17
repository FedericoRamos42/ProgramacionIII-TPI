using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Doctor : User
    {
        [Required]
        public int LicenseNumber { get; set; }
        public Speciality Speciality { get; set; }
        public int SpecialityId { get; set; }
        public ICollection<Appoitment> AssignedAppointment { get; set; } = new List<Appoitment>();

        public Doctor() 
        {
            UserRole = UserRole.Doctor;
        } 

    }
}
