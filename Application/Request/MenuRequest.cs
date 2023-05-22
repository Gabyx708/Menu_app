using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class MenuRequest
    {
        public DateTime fecha_consumo { get; set; }
        public DateTime fecha_cierre { get; set; }
        public List<PlatilloDelMenuRequest> platillosDelMenu { get; set; }
    }
}
