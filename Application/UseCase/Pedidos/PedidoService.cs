using Application.Interfaces.IMenuPlatillo;
using Application.Interfaces.IPedido;
using Application.Interfaces.IPedidoPorMenuPlatillo;
using Application.Interfaces.IPersonal;
using Application.Interfaces.IPlatillo;
using Application.Interfaces.IRecibo;
using Application.Request.PedidoRequests;
using Application.Response.MenuPlatilloResponses;
using Application.Response.PedidoResponses;
using Application.Response.PersonalResponses;
using Domain.Entities;

namespace Application.UseCase.Pedidos
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoCommand _command;
        private readonly IPedidoQuery _query;
        private readonly IPersonalService _personalService;
        private readonly IPedidoPorMenuPlatilloService _pedidoPorMenuPlatilloService;
        private readonly IMenuPlatilloService _menuPlatilloService;
        private readonly IPlatilloService _platilloService;
        private readonly IReciboService _reciboService;
        private readonly IMenuPlatilloQuery _menuPlatilloQuery;
        private IEstrategiaHacerPedido _estrategiaHacerPedido;
        public PedidoService(IPedidoCommand command, IPedidoQuery query, IPersonalService personalService, IPedidoPorMenuPlatilloService pedidoPorMenuPlatilloService, IMenuPlatilloService menuPlatilloService, IPlatilloService platilloService, IReciboService reciboService, IMenuPlatilloQuery menuPlatilloQuery, IEstrategiaHacerPedido estrategiaHacerPedido)
        {
            _command = command;
            _query = query;
            _personalService = personalService;
            _pedidoPorMenuPlatilloService = pedidoPorMenuPlatilloService;
            _menuPlatilloService = menuPlatilloService;
            _platilloService = platilloService;
            _reciboService = reciboService;
            _menuPlatilloQuery = menuPlatilloQuery;
            _estrategiaHacerPedido = estrategiaHacerPedido;
        }

        public void CambiarEstrategiaPedido(IEstrategiaHacerPedido estrategia)
        {
            _estrategiaHacerPedido = estrategia;
        }
        public PedidoResponse GetPedidoById(Guid idPedido)
        {
            var pedido = _query.GetPedidoById(idPedido);
            List<MenuPlatilloGetResponse> platillosDelMenu = new List<MenuPlatilloGetResponse>();

            if (pedido != null)
            {
                var pedidosPorMenuPlatillo = _pedidoPorMenuPlatilloService.GetPedidosMenuPlatilloDePedido(idPedido);

                foreach (var pedidoPorMenuPlatillo in pedidosPorMenuPlatillo)
                {
                    var recuperado = _menuPlatilloService.GetMenuPlatilloById(pedidoPorMenuPlatillo.IdMenuPlatillo);

                    MenuPlatilloGetResponse menuPlatilloResponse = new MenuPlatilloGetResponse
                    {
                        id = recuperado.id,
                        descripcion = _platilloService.GetPlatilloById(recuperado.id).descripcion,
                        precio = recuperado.precio,
                        stock = recuperado.stock,
                        pedido = recuperado.pedido,
                    };

                    platillosDelMenu.Add(menuPlatilloResponse);
                }

                var personal = _personalService.GetPersonalById(pedido.IdPersonal);

                return new PedidoResponse
                {
                    idPedido = idPedido,
                    Nombre = personal.nombre + " " + personal.apellido,
                    fecha = pedido.FechaDePedido,
                    platillos = platillosDelMenu,
                    recibo = _reciboService.GetReciboById(pedido.IdRecibo)
                };
            }

            return null;
        }
        public PedidoResponse EliminarPedido(Guid idPedido)
        {
            var found = _query.GetPedidoById(idPedido);
            var auxResponse = GetPedidoById(idPedido);

            if (found != null)
            {
                Guid idMenuPlatilloPrimero = found.PedidosPorMenuPlatillo[0].IdMenuPlatillo;
                DateTime fechaCierreMenu = _menuPlatilloQuery.GetById(idMenuPlatilloPrimero).Menu.FechaCierre;
                DateTime fechaActual = DateTime.Now;

                if (fechaActual > fechaCierreMenu)
                {
                    throw new InvalidOperationException();
                }

                _command.DeletePedido(idPedido);
                return auxResponse;
            }

            return auxResponse;
        }

        public PedidoResponse HacerUnpedido(PedidoRequest request)
        {

            return _estrategiaHacerPedido.RealizarPedido(request);
        }

        public List<PedidoResponse> PedidosDelMenu(Guid idMenu)
        {
            throw new NotImplementedException();
        }

        public List<PedidoGetResponse> PedidoFiltrado(Guid? idPersonal, DateTime? Desde, DateTime? Hasta, int? cantidad)
        {

            List<Pedido> pedidos = _query.GetPedidosFiltrado(idPersonal, Desde, Hasta, cantidad);
            List<PedidoGetResponse> pedidosResponse = new List<PedidoGetResponse>();


            foreach (var pedido in pedidos)
            {
                PersonalResponse persona = _personalService.GetPersonalById(pedido.IdPersonal);


                var nuevo = new PedidoGetResponse
                {
                    id = pedido.IdPedido,
                    Personal = pedido.IdPersonal,
                    Fecha = pedido.FechaDePedido,
                    Recibo = pedido.IdRecibo,
                    Nombre = persona.nombre + " " + persona.apellido
                };

                pedidosResponse.Add(nuevo);
            }

            return pedidosResponse;
        }

        public List<PedidoResponse> PedidosPorFecha(DateTime fecha)
        {
            throw new NotImplementedException();
        }
    }
}
