using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Menu
    {
        public Guid IdMenu { get; set; }
        public DateTime FechaConsumo { get; set; }
        public DateTime FechaCarga { get; set; }
        public DateTime FechaCierre { get; set; }

        public IList<MenuPlatillo> MenuPlatillos { get; set;}
    }
}
