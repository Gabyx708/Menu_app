using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IPedido
{
    internal interface IPedidoCommand
    {
        Pedido createPedido(Pedido pedido);
        Pedido DeletePedido(Guid idPedido);

    }
}
