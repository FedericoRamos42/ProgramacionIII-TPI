using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DoctorService
    {
        private readonly IDoctorRepository _repository;
        public DoctorService(IDoctorRepository repository)
        {
            _repository = repository;
        }

    }
}
