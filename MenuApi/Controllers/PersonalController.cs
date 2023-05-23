using Application.Interfaces.IPersonal;
using Application.Request;
using Application.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly IPersonalService _services;

        public PersonalController(IPersonalService services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetTodoElpersonal()
        {
            var empleados = _services.GetAllPersonal();
            return new JsonResult(empleados) { StatusCode = 200 };
        }

        [HttpPost]
        [ProducesResponseType(typeof(PersonalResponse), 201)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult CreatePersonal(PersonalRequest request)
        {
            var personalNuevo = _services.createPersonal(request);
            return new JsonResult(personalNuevo) { StatusCode = 201};
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonal(Guid id)
        {
           var personal = _services.GetPersonalById(id);
            return new JsonResult(personal) { StatusCode = 200 };
        }
    }
}
