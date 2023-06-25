using Application.Interfaces.IPedido;
using Application.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private IPedidoService _services;

        public PedidoController(IPedidoService services)
        {
            _services = services;
        }

        [HttpPost]
        public IActionResult HacerUnPedido(PedidoRequest request)
        {
            var nuevoPedido = _services.HacerUnpedido(request);

            return new JsonResult(nuevoPedido);
        }
    }
}
