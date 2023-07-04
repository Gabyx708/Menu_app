using Application.Interfaces.IAuthentication;
using Application.Interfaces.IPersonal;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly IPersonalService _services;
        private readonly IAuthenticationService _authService;

        public PersonalController(IPersonalService services, IAuthenticationService authService)
        {
            _services = services;
            _authService = authService;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(PersonalResponse), 200)]
        public IActionResult loginUser(UsuarioLoginRequest request)
        {
            var usuarioLog = _authService.autenticarUsuario(request);
            if (usuarioLog == null) { return Unauthorized(); }
            return Ok(usuarioLog);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PersonalResponse>), 200)]
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
            return new JsonResult(personalNuevo) { StatusCode = 201 };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonalResponse), 200)]
        [ProducesResponseType(typeof(NotFoundObjectResult), 404)]
        public IActionResult GetPersonal(Guid id)
        {
            var personal = _services.GetPersonalById(id);
            string message = $"no se encontro un usuario con el id: {id}";

            if (personal == null) { return NotFound(message); };

            return new JsonResult(personal) { StatusCode = 200 };
        }
    }
}
