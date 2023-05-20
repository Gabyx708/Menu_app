using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PedidoPorMenuPlatillo
    {
        public Guid IdPedido { get; set; }
        public Pedido Pedido { get; set; }
        public Guid IdMenuPlatillo { get; set; }
        public MenuPlatillo MenuPlatillo { get; set; }
    }
}
