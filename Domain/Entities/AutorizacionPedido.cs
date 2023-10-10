using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AutorizacionPedido
    {
        public Guid IdPedido { get; set; }
        public Guid IdPersonal { get; set; }
        public Pedido Pedido { get; set;}
        public Personal Personal { get; set; }
    }
}
