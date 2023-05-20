using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Descuento
    {
        public Guid IdDescuento { get; set; }
        public DateTime FechaInicioVigencia { get; set; }
        public int Porcentaje { get; set; }

        public ICollection<Recibo> Recibos { get; set; }
    }
}
