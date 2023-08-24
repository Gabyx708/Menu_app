using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.IPagos
{
    public interface IPagoCommand
    {
        Pago InsertPago(Pago NuevoPago,List<Guid> idRecibos);
        Pago ModificarEstadoAnulado(long NPago, bool estadoAnulado);
    }
}
