using Application.Interfaces.IPedido;
using Application.Request;
using Application.Response;
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
        [ProducesResponseType(typeof(PedidoResponse),201)]
        public IActionResult HacerUnPedido(PedidoRequest request)
        {
            var nuevoPedido = _services.HacerUnpedido(request);

            return Ok(nuevoPedido);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PedidoResponse),200)]
        public IActionResult ConsularPedido(Guid id)
        {
            var pedidoConsultado = _services.GetPedidoById(id);
            return Ok(pedidoConsultado);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PedidoGetResponse>), 200)]
        public IActionResult ConsularPedidos(Guid? idPersonal, DateTime? fecha,int? cantidad)
        {

            var pedidosConsultados = _services.PedidoFiltrado(idPersonal, fecha, cantidad);
            return Ok(pedidosConsultados);
        }
    }
}
