using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IDescuento
{
    public interface IDescuentoService
    {
        DescuentoResponse crearDescuento(DescuentoRequest request);
        DescuentoResponse GetDescuentoById(Guid id);
        DescuentoResponse GetDescuentoVigente();
        DescuentoResponse GetByFecha(DateTime fecha);
        List<DescuentoResponse> GetAll();
    }
}
