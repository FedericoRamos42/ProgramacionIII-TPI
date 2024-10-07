﻿using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PatientRepository : BaseRepository<Patient>,IPatientRepository
    {
        private readonly ApplicationContext _repository;

        public PatientRepository(ApplicationContext repository) : base(repository)
        {
            _repository = repository;
        }

        public Patient? GetByIdIncludeAddress(int id) 
        {
            var entity = _repository.Patients.Include(a=>a.Address)
                                             .FirstOrDefault(c => c.Id == id);
            return entity;
        }
    }
}
