using Application.Interfaces.IPedido;
using Infraestructure.Persistence;
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
        private readonly MenuAppContext _context;

        public HacerPedido(IPedidoService services, MenuAppContext context)
        {
            _services = services;
            _context = context;
        }
    }
}
