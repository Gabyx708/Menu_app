using Application.Interfaces.IPedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muneBot.Application.UseCase.HacerPedido
{
    public class HacerPedido
    {
        private readonly IPedidoService _services;

        public HacerPedido(IPedidoService services)
        {
            _services = services;
        }
    }
}
