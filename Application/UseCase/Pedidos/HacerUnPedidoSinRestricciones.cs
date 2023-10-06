﻿using Application.Interfaces.IPedido;
using Application.Request.PedidoRequests;
using Application.Response.PedidoResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Pedidos
{
    public class HacerUnPedidoSinRestricciones : IEstrategiaHacerPedido
    {
        public PedidoResponse RealizarPedido(PedidoRequest request)
        {
            return new PedidoResponse
            {
                Nombre = "Soy la estrategia sin restricciones"
            };
        }
    }
}
