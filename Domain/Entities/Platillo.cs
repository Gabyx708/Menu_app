using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Platillo
    {
        public int IdPlatillo { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public bool Activado { get; set; }

        public IList<MenuPlatillo> MenuPlatillos { get; set; }

    }
}
