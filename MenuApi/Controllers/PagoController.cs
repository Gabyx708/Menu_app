using Application.Interfaces.IPagos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IPagoService _services;

        public PagoController(IPagoService services)
        {
            _services = services;
        }
    }
}
