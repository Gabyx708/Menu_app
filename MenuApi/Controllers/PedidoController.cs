using Application.Interfaces.IPedido;
using Application.Request.PedidoRequests;
using Application.Response.GenericResponses;
using Application.Response.PedidoResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/v1.2/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private IPedidoService _services;

        public PedidoController(IPedidoService services)
        {
            _services = services;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PedidoResponse), 201)]
        public IActionResult HacerUnPedido(PedidoRequest request)
        {
            PedidoResponse result = new PedidoResponse();

            try {
                result = _services.HacerUnpedido(request);
                return new JsonResult(result) { StatusCode = 201};
            }
            catch(InvalidOperationException e)
            {
                return new JsonResult(new { message = "error"} ) { StatusCode = 409 };
            }


        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PedidoResponse),200)]
        public IActionResult ConsularPedido(Guid id)
        {
            var pedidoConsultado = _services.GetPedidoById(id);
            return Ok(pedidoConsultado);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePedido(Guid id)
        {
            PedidoResponse pedidoEliminado = new PedidoResponse();
            try
            {
                pedidoEliminado = _services.EliminarPedido(id);
            }
            catch (InvalidOperationException)
            {
                return new JsonResult(new SystemResponse { Message = "fecha excedida", StatusCode = 409 }) { StatusCode = 409 };
            }
             
            return new JsonResult(pedidoEliminado);
        }

    }
}
