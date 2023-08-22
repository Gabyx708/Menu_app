using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IPagos
{
    public interface IPagoQuery
    {
        List<Pago> GetAllPagos();
        Pago GetPagoById(long NPago);
        List<Pago> GetPagoFiltrado(DateTime fechaDesde, DateTime fechaHasta);
    }
}
