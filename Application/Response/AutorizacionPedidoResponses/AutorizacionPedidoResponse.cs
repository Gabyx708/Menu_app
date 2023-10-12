using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response.AutorizacionPedidoResponses
{
    public class AutorizacionPedidoResponse
    {
        public Guid Autorizador { get; set; }
        public string Nombre { get; set; }
        public Guid idPedido { get; set; }
    }
}
