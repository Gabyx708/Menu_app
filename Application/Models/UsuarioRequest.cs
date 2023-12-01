using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class UsuarioRequest
    {
        public Guid id { get; set; }
        public  string? nombre { get; set; }
        public  string? apellido { get; set; }
        public string? email { get; set; }
    }

    public class UsuarioResponse : UsuarioRequest
    {
        public bool activado { get; set; }
    }
}
