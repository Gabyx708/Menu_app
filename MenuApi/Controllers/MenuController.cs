using Application.Interfaces.IMenu;
using Application.Request;
using Application.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _services;

        public MenuController(IMenuService services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetMenu(string? id)
        {
            MenuResponse? resultado = null;

            if (id != null)
            {
                resultado = _services.GetMenuById(Guid.Parse(id));
                return new JsonResult(resultado) { StatusCode = 200 };
            }

            resultado = _services.GetUltimoMenu();
            return new JsonResult(resultado) { StatusCode = 200 };
        }

        [HttpGet("fecha/{fechaConsumo}")]
        public IActionResult GetMenuByFecha(string fechaConsumo)
        {   
            var menu = _services.GetUltimoMenu();
            return new JsonResult(menu) { StatusCode = 200 };
        }

        [HttpPost]
        public IActionResult CreateMenu(MenuRequest request)
        {
            var nuevoMenu = _services.CreateMenu(request);
            return new JsonResult(nuevoMenu) { StatusCode = 200 };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenu(Guid id)
        {
            var menuBorrado = _services.BorrarMenu(id);
            return new JsonResult(menuBorrado) { StatusCode = 200 };
        }
    }
}
