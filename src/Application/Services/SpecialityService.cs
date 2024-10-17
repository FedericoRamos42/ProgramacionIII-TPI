using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SpecialityService : ISpecialityService
    {
        private readonly ISpecialityRepository _specialityRepository;

        public SpecialityService(ISpecialityRepository specialityRepository)
        {
            _specialityRepository = specialityRepository;
        }

        public SpecialityDto GetSpecialityById(int id)
        {
            var speciality = _specialityRepository.GetById(id);

            return SpecialityDto.CreateSpecilityDto(speciality);
        }

        public IEnumerable<SpecialityDto> GetAllSpecialities()
        {
            var list = _specialityRepository.GetAll();
            return SpecialityDto.CreateListDto(list);
        }

        public SpecialityDto CreateSpeciality(SpecialityForRequest speciality)
        {
            var entity = new Speciality()
            {
                Name = speciality.Name,
                Description = speciality.Description
            };
            var newSpeciality = _specialityRepository.Create(entity);
            return SpecialityDto.CreateSpecilityDto(newSpeciality);
        }
    }

   
}
