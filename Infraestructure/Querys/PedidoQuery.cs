using Application.Interfaces.IPedido;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Querys
{
    public class PedidoQuery : IPedidoQuery
    {
        private readonly MenuAppContext _context;

        public PedidoQuery(MenuAppContext context)
        {
            _context = context;
        }

        public List<Pedido> GetAll()
        {
            return _context.Pedidos.ToList();
        }

        public Pedido GetPedidoById(Guid idPedido)
        {
            var found = _context.Pedidos.FirstOrDefault(p => p.IdPedido == idPedido);

            if (found != null)
            {
                return found;
            }

            return null;
        }

        public List<Pedido> GetPedidosMenu(Guid idMenu)
        {
            List<Guid> menuPlatillo = _context.MenuPlatillos.Where(mp => mp.IdMenu == idMenu).
                                       Select(mp => mp.IdMenuPlatillo).ToList();

            List<Guid> idPedidosDelMenu = new List<Guid>();
            List<Pedido> pedidosDelMenuEncontrados = new List<Pedido>();

            for (int i = 0; i < menuPlatillo.Count; i++)
            {
                List<Guid> encontrados = _context.PedidosPorMenuPlatillo.Where(pmp => pmp.IdMenuPlatillo == menuPlatillo[i]).
                      Select(pmp => pmp.IdPedido).ToList();


                foreach (var id in encontrados)
                {
                    idPedidosDelMenu.Add(id);
                }
            }

            foreach (var idPedido in idPedidosDelMenu)
            {
                pedidosDelMenuEncontrados.Add(GetPedidoById(idPedido));
            }

            return pedidosDelMenuEncontrados;
        }

        public List<Pedido> GetPedidosFiltrado(Guid? idPersonal, DateTime? fechaDesde, DateTime? fechaHasta, int? ultimos)
        {
            IQueryable<Pedido> query = _context.Pedidos.AsQueryable();

            if (idPersonal != null)
            {
                query = query.Where(p => p.IdPersonal == idPersonal);
            }


            if (fechaDesde != null && fechaHasta != null)
            {
                query = query.Where(p => p.FechaDePedido >= fechaDesde && p.FechaDePedido <= fechaHasta);
            }
            else
            {
                if (fechaDesde != null)
                {
                    query = query.Where(p => p.FechaDePedido >= fechaDesde);
                }

                if (fechaHasta != null)
                {
                    query = query.Where(p => p.FechaDePedido <= fechaHasta);
                }
            }
        

            if (ultimos != null)
            {
                query = query.OrderByDescending(p => p.FechaDePedido).Take((int)ultimos);
            }

            List<Pedido> pedidos = query.ToList();
            return pedidos;
        }

    }
}
