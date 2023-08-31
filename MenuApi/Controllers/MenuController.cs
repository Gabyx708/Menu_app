using Application.Interfaces.IAutomation;
using Application.Interfaces.IMenu;
using Application.Request.MenuRequests;
using Application.Response.MenuResponses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/v1.2/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _services;
        private readonly IAutomation _automationService;

        public MenuController(IMenuService services, IAutomation automationService)
        {
            _services = services;
            _automationService = automationService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(MenuResponse), 200)]
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
        [ProducesResponseType(typeof(MenuResponse), 200)]
        public IActionResult GetMenuByFecha(string fechaConsumo)
        {   
            var menu = _services.GetUltimoMenu();
            return new JsonResult(menu) { StatusCode = 200 };
        }

        [HttpPost]
        [ProducesResponseType(typeof(MenuResponse), 201)]
        public IActionResult CreateMenu(MenuRequest request)
        {
            var nuevoMenu = _services.CreateMenu(request);

            //Hacer pedidos automaticos
            _automationService.HacerPedidosAutomatico();

            return new JsonResult(nuevoMenu) { StatusCode = 201 };
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MenuResponse), 200)]
        public IActionResult DeleteMenu(Guid id)
        {
            var menuBorrado = _services.BorrarMenu(id);
            return new JsonResult(menuBorrado) { StatusCode = 200 };
        }
    }
}
