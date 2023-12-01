using Application.Interfaces.IPlatillo;
using Application.Interfaces.IServices.IAutomationService;
using Application.Models;
using Application.Request.PlatilloRequests;
using Application.Response.GenericResponses;
using Application.Response.PlatilloResponses;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/v1.3/[controller]")]
    [ApiController]
    public class PlatilloController : ControllerBase
    {
        private readonly IPlatilloService _services;
        private readonly IAdapterAutomationPlatillo _adapterAutomationPlatillo;
        private readonly IAdapterAutomationCategoria _adapterAutomationCategoria;
        public PlatilloController(IPlatilloService services, IAdapterAutomationPlatillo adapterAutomationPlatillo, IAdapterAutomationCategoria adapterAutomationCategoria)
        {
            _services = services;
            _adapterAutomationPlatillo = adapterAutomationPlatillo;
            _adapterAutomationCategoria = adapterAutomationCategoria;
        }



        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PlatilloResponse), 200)]
        public IActionResult GetPLatillo(int id)
        {
            var platillo = _services.GetPlatilloById(id);
            return new JsonResult(platillo) { StatusCode = 200 };
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlatilloResponse), 201)]
        public IActionResult CrearPlatillo(PlatilloRequest request)
        {
            var nuevoPlato = _services.CreatePlatillo(request);

            var requestPlatoCategoria = new PlatilloRequestAutomation
            {
                id = nuevoPlato.id,
                descripcion = nuevoPlato.descripcion,
                categoria = request.categoria
            };

            try
            {
                _adapterAutomationPlatillo.inserPlatoInAutomation(requestPlatoCategoria);

            }
            catch (IOException)
            {
                //TODO: manejar esta excepcion
            };

            return new JsonResult(nuevoPlato) { StatusCode = 201 };
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PlatilloResponse), 200)]
        public IActionResult CambiarPrecio(int id, PlatilloRequest request)
        {
            var platoPrecio = _services.UpdatePrecio(id, request.precio);
            return new JsonResult(platoPrecio) { StatusCode = 200 };
        }

        [HttpPost("categoria")]
        [ProducesResponseType(typeof(CategoriaResponse), 201)]
        public IActionResult CrearUnaCategoria(CategoriaRequest request)
        {
            try { 

                var categoriaNueva = _adapterAutomationCategoria.insertNuevaCategoria(request);
                return new JsonResult(categoriaNueva) { StatusCode = 201 };

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
