using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }


        [HttpGet("doctor/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
        [HttpGet("speciality/{id}")]
        public IActionResult GetBySpeciality(int id) 
        {
            return Ok(_service?.GetBySpeciality(id));
        }
        [HttpGet]
        public IActionResult GetDoctor()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult AddDoctor([FromBody] DoctorCreateRequest request)
        {
            return Ok(_service.CreateDoctor(request));
        }

        [HttpPut("/doctor{id}")]
        public IActionResult UpdateDoctor(int id, [FromBody] DoctorUpdateRequest request)
        {
            return Ok(_service.UpdateDoctor(id, request));
        }

        [HttpDelete("doctor/{id}")]

        public IActionResult DeleteDoctor(int id)
        {
            return Ok(_service.DeleteDoctor(id));
        }
    }
};
