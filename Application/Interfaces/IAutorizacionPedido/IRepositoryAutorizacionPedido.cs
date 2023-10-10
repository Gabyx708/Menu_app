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
        Task<AutorizacionPedido> CreateAutorizacionPedido(AutorizacionPedido entity);
        Task<AutorizacionPedido> DeleteAutorizacionPedido(Guid idPedido, Guid idPersonal);
        Task<AutorizacionPedido> GetAutorizacionPedidoByidPedido(Guid idPedido);
        Task<List<AutorizacionPedido>> GetAutorizacionesPedidoByIdPersonal(Guid idPersonal);
    }
}
