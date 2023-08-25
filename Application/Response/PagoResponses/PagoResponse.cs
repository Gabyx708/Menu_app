using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response.PagoResponses
{
    public class PagoResponse
    {
        public long NumeroPago { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreRegistrador { get; set; }
        public string DniRegistrador { get; set; }
         public List<Guid>? Recibos { get; set; }
        public decimal Monto { get; set; }

    }
}
