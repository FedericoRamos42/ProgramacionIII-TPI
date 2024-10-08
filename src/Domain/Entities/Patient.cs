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
    public class Patient : User
    {
        [MaxLength(50)]
        public string MedicalInsurance { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public ICollection<Appoitment> Appoitments { get; set;} = new List<Appoitment>();

        public Patient()
        {
            UserRole = UserRole.Patient;
            IsAvailable = true;
        }
    }
}
