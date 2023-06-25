using Application.Interfaces.IPedido;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Commands
{
    public class PedidoCommand : IPedidoCommand
    {
        private readonly MenuAppContext _context;

        public PedidoCommand(MenuAppContext context)
        {
            _context = context;
        }

        public Pedido createPedido(Pedido pedido)
        {
            _context.Add(pedido);
            _context.SaveChanges();
            return pedido;
        }

        public Pedido DeletePedido(Guid idPedido)
        {
            var found = _context.Pedidos.FirstOrDefault(p => p.IdPedido == idPedido);

            if (found != null)
            {
                _context.Remove(found);
            }

            return null;
        }
    }
}
