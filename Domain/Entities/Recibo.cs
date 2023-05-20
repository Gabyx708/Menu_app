using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Recibo
    {
        public Guid IdRecibo { get; set; }  
        public Guid IdPedido { get; set; } 
        public Guid IdDescuento { get; set; }
        public double precioTotal { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
        public Descuento descuento { get; set; }

    }
}
