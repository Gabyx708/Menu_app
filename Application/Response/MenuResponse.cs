using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class MenuResponse
    {
        public Guid id { get; set; }
        public DateTime fecha_consumo { get; set; }
        public DateTime fecha_carga { get; set; }
        public DateTime fecha_cierre { get; set; }

        List<MenuPlatilloResponse> platillos { get; set; }
    }
}
