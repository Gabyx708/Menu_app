using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class DescuentoResponse
    {   
        public Guid id { get; set; }
        public DateTime fecha_inicio { get; set; }
        public int porcentaje { get; set; }
    }
}
