using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response.UsuarioLoginResponse
{
    public class UsuarioLoginResponse
    {   
        public Guid id { get; set; }
        public string Nombre { get; set; }
        public string Apellido {  get; set; }
        public string Token { get; set; }
    }
}
