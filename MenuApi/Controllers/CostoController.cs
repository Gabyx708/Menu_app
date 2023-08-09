using Application.Interfaces.ICostos;
using Application.Interfaces.IDescuento;
using Application.Response.CostoResponses;
using Application.Response.DescuentoResponse;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostoController : Controller
    {
       
        private readonly ICostoService _services;

        public CostoController(ICostoService services)
        {
            _services = services;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CostoDiaResponse), 200)]
        public IActionResult GetDescuento(DateTime fecha)
        {
            var descuento = _services.GetCostosDia(fecha);
            return new JsonResult(descuento) { StatusCode = 200 };
        }
    }
}
