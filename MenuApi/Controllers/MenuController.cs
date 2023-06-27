using Application.Interfaces.IMenu;
using Application.Request;
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

        [HttpGet("{id}")]
        public IActionResult GetMenu(Guid id)
        {
            var personal = _services.GetMenuById(id);
            return new JsonResult(personal) { StatusCode = 200 };
        }

        [HttpGet("fecha/{fechaConsumo}")]
        public IActionResult GetMenuByFecha(string fechaConsumo)
        {   
            var fecha = DateTime.Parse(fechaConsumo);

            var menu = _services.GetNextMenu(fecha);
            return new JsonResult(menu) { StatusCode = 200 };
        }

        [HttpPost]
        public IActionResult CreateMenu(MenuRequest request)
        {
            var nuevoMenu = _services.CreateMenu(request);
            return new JsonResult(nuevoMenu) { StatusCode = 200 };
        }
    }
}
