using Application.Interfaces.IPagos;
using Application.Request;
using Application.Response.PagoResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IPagoService _services;

        public PagoController(IPagoService services)
        {
            _services = services;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PagoResponse), 201)]
        public IActionResult RegistrarUnPago(PagoRequest request)
        {
            var result = _services.HacerUnPago(request);

            return new JsonResult(result) { StatusCode = 201};
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PagoResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        public IActionResult ConsultarPago(long id)
        {
            var result = _services.GetPagoResponseById(id);

            if(result == null)
            {
                return NotFound();
            }

            return new JsonResult(result);
        }
    }
}
