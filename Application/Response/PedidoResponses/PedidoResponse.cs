using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Response.MenuPlatilloResponses;
using Application.Response.ReciboResponses;

namespace Application.Response.PedidoResponses
{
    public class PedidoResponse
    {
        public Guid idPedido { get; set; }
        public string Nombre { get; set; }
        public DateTime fecha { get; set; }
        public List<MenuPlatilloGetResponse> platillos { get; set; }
        public ReciboResponse recibo { get; set; }

    }
}
