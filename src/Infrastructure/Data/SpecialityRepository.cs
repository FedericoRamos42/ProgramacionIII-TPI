using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SpecialityRepository: BaseRepository<Speciality>, ISpecialityRepository

    {
        private readonly ApplicationContext _repository;

        public SpecialityRepository(ApplicationContext repository):base( repository)
        {
            repository = _repository;
        }

    }
}
