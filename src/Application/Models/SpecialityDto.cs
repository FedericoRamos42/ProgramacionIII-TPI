using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class SpecialityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description = string.Empty;

        public static SpecialityDto CreateSpecilityDto(Speciality speciality)
        {
            var specilityDto = new SpecialityDto() 
            {
                Id = speciality.Id,
                Name = speciality.Name,
                Description = speciality.Description,
            };

            return specilityDto;
        }

        public static IEnumerable<SpecialityDto> CreateListDto(IEnumerable<Speciality> list)
        {
            var listDto = new List<SpecialityDto>();

            foreach (Speciality s in list)
            {
                listDto.Add(CreateSpecilityDto(s));
            }

            return listDto;
        }
    }
}
