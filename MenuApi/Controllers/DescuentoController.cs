using Application.Interfaces.IDescuento;
using Application.Interfaces.IMenu;
using Application.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescuentoController : ControllerBase
    {
        private readonly IDescuentoService _services;

        public DescuentoController(IDescuentoService services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public IActionResult GetDescuento(Guid id)
        {
            var descuento = _services.GetDescuentoById(id);
            return new JsonResult(descuento) { StatusCode = 200 };
        }

        [HttpGet]
        public IActionResult GetVigente()
        {
            var vigente = _services.GetDescuentoVigente();
            return new JsonResult(vigente) { StatusCode = 200 };
        }

        [HttpPost]
        public IActionResult CreateDescuento(DescuentoRequest request)
        {
            var nuevoDescuento = _services.crearDescuento(request);
            return new JsonResult(nuevoDescuento) { StatusCode = 200 };
        }
    }
}
