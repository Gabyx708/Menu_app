using Application.Interfaces.IPlatillo;
using Application.Interfaces.IServices.IAutomationService;
using Application.Models;
using Application.Response.GenericResponses;
using Application.Response.PlatilloResponses;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/v1.3/[controller]")]
    [ApiController]
    public class PlatillosController : ControllerBase
    {
        private readonly IPlatilloService _services;
        private readonly IAdapterAutomationCategoria _adapterAutomationCategoria;


        public PlatillosController(IPlatilloService services, IAdapterAutomationCategoria adapterAutomationCategoria)
        {
            _services = services;
            _adapterAutomationCategoria = adapterAutomationCategoria;
        }

        [HttpPatch]
        [ProducesResponseType(typeof(NoContentResult), 204)]
        public IActionResult AlterarPrecios(decimal nuevoPrecio)
        {
            var result = _services.AlterarPreciosMasivamente(nuevoPrecio);


            if (result) { return NoContent(); }

            return new JsonResult("ocurrio un problema durante los cambios");
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PlatilloResponse>), 200)]
        public IActionResult GetAll()
        {
            var platillos = _services.GetAll();
            return new JsonResult(platillos) { StatusCode = 200 };
        }

        [HttpGet("categoria")]
        [ProducesResponseType(typeof(List<CategoriaResponse>), 200)]
        public IActionResult ConseguirCategorias()
        {
            try
            {
                var categorias = _adapterAutomationCategoria.listaCategorias();
                return new JsonResult(categorias) { StatusCode = 200 };
            }
            catch (Exception)
            {
                return new JsonResult(new SystemResponse
                {
                    Message = "es posible que el servicio de automatizacion no funcione",
                    StatusCode = 500
                })
                { StatusCode = 500 };
            }

        }
    }
}
