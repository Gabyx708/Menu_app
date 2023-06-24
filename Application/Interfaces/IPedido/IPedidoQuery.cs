using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IPedido
{
    public interface IPedidoQuery
    {
        Pedido GetPedidoById(Guid idPedido);
        List<Pedido> GetAll();
        List<Pedido> GetPedidosPersonal(Guid idPersonal);
        List<Pedido> GetPedidosMenu(Guid idMenu);
        List<Pedido> GetPedidosByFecha(DateTime fecha);
    }
}
