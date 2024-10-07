using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class AppoitmentCreateRequest
    {
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Office { get; set; } = string.Empty;
    }
}
