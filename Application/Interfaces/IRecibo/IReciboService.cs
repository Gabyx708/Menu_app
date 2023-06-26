using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRecibo
{
    public interface IReciboService
    {
        ReciboResponse GetReciboById(Guid id);
        List<ReciboResponse> GetRecibosPersonal(Guid idPersonal);
        List<ReciboResponse> GetRecibosByDescuento(Guid idDescuento);
    }
}
