using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IDescuento
{
    public interface IDescuentoQuery
    {
        Descuento GetById(Guid idDescuento);
        Descuento GetByFecha(DateTime fecha);
        List<Descuento> GetAll();
        Descuento GetVigente();

    }
}
