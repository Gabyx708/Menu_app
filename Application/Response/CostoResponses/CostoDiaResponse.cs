using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response.CostoResponses
{
    public class CostoDiaResponse
    {
        public DateTime Fecha { get; set; }
        public decimal CostosinDescuento { get; set; }
        public decimal CostoconDescuento { get; set; }
    }
}
