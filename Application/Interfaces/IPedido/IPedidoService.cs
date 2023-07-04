﻿using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IPedido
{
    public interface IPedidoService
    {
        PedidoResponse HacerUnpedido(PedidoRequest request);
        PedidoResponse EliminarPedido(Guid idPedido);
        PedidoResponse GetPedidoById(Guid idPedido);
        List<PedidoGetResponse> PedidoFiltrado(Guid? idPersonal, DateTime? fecha, int? cantidad);
        List<PedidoResponse> PedidosDelMenu(Guid idMenu);
        List<PedidoResponse> PedidosPorFecha(DateTime fecha);


    }
}
