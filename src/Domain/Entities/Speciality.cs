﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [MaxLength(400)]
        public string Description { get; set; } = string.Empty;
        public IEnumerable<Doctor> SpecialityDoctors { get; set; } = new List<Doctor>();
    }
}
