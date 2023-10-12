using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IAutorizacionPedido
{
    public interface IRepositoryAutorizacionPedido
    {
        AutorizacionPedido CreateAutorizacionPedido(AutorizacionPedido entity);
        AutorizacionPedido DeleteAutorizacionPedido(Guid idPedido, Guid idPersonal);
        AutorizacionPedido GetAutorizacionPedidoByidPedido(Guid idPedido);
        List<AutorizacionPedido> GetAutorizacionesPedidoByIdPersonal(Guid idPersonal);
    }
}
