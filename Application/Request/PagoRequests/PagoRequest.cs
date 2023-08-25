using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request.PagoRequests
{
    public class PagoRequest
    {
        public Guid idPersonal { get; set; }
        public List<Guid> Recibos { get; set; }
    }
}
