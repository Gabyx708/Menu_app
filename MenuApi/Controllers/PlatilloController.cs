using Application.Interfaces.IPersonal;
using Application.Interfaces.IPlatillo;
using Application.Request;
using Application.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatilloController : ControllerBase
    {
        private readonly IPlatilloService _services;

        public PlatilloController(IPlatilloService services)
        {
            _services = services;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var platillos = _services.GetAll();
            return new JsonResult(platillos) { StatusCode = 200};
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonal(int id)
        {
            var platillo = _services.GetPlatilloById(id);
            return new JsonResult(platillo) { StatusCode = 200 };
        }

        [HttpPost]
        public IActionResult CrearPlatillo(PlatilloRequest request)
        {
            var nuevoPlato = _services.CreatePlatillo(request);
            return new JsonResult(nuevoPlato) { StatusCode = 200 };
        }

        [HttpPatch("{id}")]
        public IActionResult CambiarPrecio(int id,PlatilloRequest request)
        {
            var platoPrecio = _services.UpdatePrecio(id,request.precio);
            return new JsonResult(platoPrecio) { StatusCode = 200 };
        }
    }
}
