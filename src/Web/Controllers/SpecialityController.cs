using Application.Interfaces;
using Application.Models.Request;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityService _service;

        public SpecialityController(ISpecialityService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetSpecialityById(id));
        }

        [HttpGet]
        public IActionResult GetAllSpecialities()
        {
            return Ok(_service.GetAllSpecialities());
        }

        [HttpPost]
        public IActionResult AddPatient([FromBody] SpecialityForRequest request)
        {
            return Ok(_service.CreateSpeciality(request));
        }
    }
}
