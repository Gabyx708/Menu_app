using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response.CostoResponses
{
    public class CostoPeriodoResponse
    {
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal TotalDescuentos { get; set; }
    }
}
