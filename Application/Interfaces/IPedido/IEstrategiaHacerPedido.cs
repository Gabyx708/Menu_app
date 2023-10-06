using Application.Request.PedidoRequests;
using Application.Response.PedidoResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IPedido
{
    public interface IEstrategiaHacerPedido
    {
        PedidoResponse RealizarPedido(PedidoRequest request);
    }
}
