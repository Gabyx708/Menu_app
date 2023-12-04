using Application.Interfaces.IServices.IAutomationService;
using Application.Models;
using Application.Response.GenericResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferenciaController : ControllerBase
    {
        private readonly IAdapterAutomationUsuario _adapterAutomationUsuario;

        public PreferenciaController(IAdapterAutomationUsuario adapterAutomationUsuario)
        {
            _adapterAutomationUsuario = adapterAutomationUsuario;
        }

        [HttpPost]
        public IActionResult crearPreferencias(PreferenciaRequest request)
        {
            var result = _adapterAutomationUsuario.setearPreferenciasUsuario(request);
            return Ok(result);
        }

        [HttpGet("{idUsuario}")]
        public IActionResult obtenerPreferencias(Guid idUsuario)
        {
            try
            {
                var result = _adapterAutomationUsuario.obtenerPrefenciasUsuario(idUsuario);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return new JsonResult(new SystemResponse
                { StatusCode = 500, Message = "ocurrio un problema con el servicio" })
                { StatusCode = 500 };
            }
        }

        [HttpDelete("{idUsuario}")]
        public IActionResult eliminarPreferencias(Guid idUsuario)
        {
            var result = _adapterAutomationUsuario.eliminarPreferenciasUsuario(idUsuario);
            return Ok(result);
        }

        [HttpPost("usuario")]
        public IActionResult crearUsuarioEnServicio(UsuarioRequest request)
        {   
            var result = _adapterAutomationUsuario.crearUsuario(request);
            return Ok(result);
        }
    }
}
