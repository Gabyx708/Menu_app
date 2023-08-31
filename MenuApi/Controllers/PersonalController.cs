using Application.Interfaces.IAuthentication;
using Application.Interfaces.IAutomation;
using Application.Interfaces.IPersonal;
using Application.Request.AutomationRequest;
using Application.Request.PersonalRequests;
using Application.Request.UsuarioLoginRequests;
using Application.Response.GenericResponses;
using Application.Response.PersonalResponses;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/v1.2/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly IPersonalService _services;
        private readonly IAuthenticationService _authService;
        private readonly IAutomation _automationServices;

        public PersonalController(IPersonalService services, IAuthenticationService authService, IAutomation automationServices)
        {
            _services = services;
            _authService = authService;
            _automationServices = automationServices;
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
        public IActionResult CreatePersonal(PersonalRequest request)
        {
            var personalNuevo = _services.createPersonal(request);
            return new JsonResult(personalNuevo) { StatusCode = 201 };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonalResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        public IActionResult GetPersonal(Guid id)
        {
            var personal = _services.GetPersonalById(id);
            string message = $"no se encontro un usuario con el id: {id}";

            if (personal == null) { return NotFound(message); };

            return new JsonResult(personal) { StatusCode = 200 };
        }

        [HttpPatch("{id}")]
        public IActionResult AlterarPersonal(Guid id,PersonalRequest request)
        {
            var personalAlterado = _services.UpdatePersonal(id, request);

            return Ok(personalAlterado);
        }

        [HttpPatch("automation")]
        public IActionResult AutomatizarPedido(AutomationRequest request)
        {
            try
            {
                var result = _automationServices.SetPedidoAutomatico(request);

                if (result ==null) { return NotFound(); };

                return new JsonResult(result) { StatusCode = 204};
            }
            catch(Exception e)
            {
                return new JsonResult(new SystemResponse { Message = "ocurrio un problema", StatusCode = 500 }) { StatusCode = 500 };
            }
            
        }
    }
}
