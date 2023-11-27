using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CategoriaRequest
    {
        public  string? Nombre { get; set; }
        public  string? Descripcion { get; set; }
        public  string? Color { get; set; }
    }

    public class CategoriaResponse
    {
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public string? color { get; set; }
    }
}
