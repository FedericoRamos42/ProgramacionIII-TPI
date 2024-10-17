using Application.Models;
using Application.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISpecialityService
    {
        SpecialityDto GetSpecialityById(int id);
        IEnumerable<SpecialityDto> GetAllSpecialities();
        SpecialityDto CreateSpeciality(SpecialityForRequest speciality);
    }
}
