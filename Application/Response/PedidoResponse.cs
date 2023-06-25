using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class PedidoResponse
    {
        public Guid idPedido { get; set; }
        public string Nombre { get; set; }
        public DateTime fecha { get; set; }
        public List<MenuPlatilloGetResponse> platillos { get; set; }

    }
}
