using Application.Interfaces.IMenu;
using Application.Interfaces.IMenuPlatillo;
using Application.Interfaces.IPedido;
using Application.Interfaces.IPedidoPorMenuPlatillo;
using Application.Interfaces.IPersonal;
using Application.Interfaces.IPlatillo;
using Application.Interfaces.IRecibo;
using Application.Request;
using Application.Response.MenuPlatilloResponses;
using Application.Response.PedidoResponses;
using Domain.Entities;
using System.Linq.Expressions;

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
        private readonly IMenuService _menuService;
        public PedidoService(IPedidoCommand command, IPedidoQuery query, IPersonalService personalService, IPedidoPorMenuPlatilloService pedidoPorMenuPlatilloService, IMenuPlatilloService menuPlatilloService, IPlatilloService platilloService, IReciboService reciboService, IMenuPlatilloQuery menuPlatilloQuery, IMenuService menuService)
        {
            _command = command;
            _query = query;
            _personalService = personalService;
            _pedidoPorMenuPlatilloService = pedidoPorMenuPlatilloService;
            _menuPlatilloService = menuPlatilloService;
            _platilloService = platilloService;
            _reciboService = reciboService;
            _menuPlatilloQuery = menuPlatilloQuery;
            _menuService = menuService;
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
                    Nombre = personal.nombre+" "+personal.apellido,
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
                _command.DeletePedido(idPedido);
                return auxResponse;
            }

            return auxResponse;
        }



        public PedidoResponse HacerUnpedido(PedidoRequest request)
        {
            List<PedidoGetResponse> existePedido = PedidoFiltrado(request.idUsuario, DateTime.Now.Date,DateTime.Now.Date, 1);
            var fechaActual = DateTime.Now;
            var fechaCierreMenu = _menuService.GetUltimoMenu().fecha_cierre;

            if (existePedido.Count > 0) {
                throw new InvalidOperationException();
            }

            if(fechaActual > fechaCierreMenu)
            {
                throw new InvalidOperationException();
            }


            decimal precioTotal = 0;

            Pedido nuevoPedido = new Pedido
            {
                IdPersonal = request.idUsuario,
                FechaDePedido = DateTime.Now,
                IdRecibo = _reciboService.CrearRecibo().id
            };

            _command.createPedido(nuevoPedido);

            foreach (var menuPlatilloId in request.MenuPlatillos)
            {
                var menuPlatilloEcontrado = _menuPlatilloService.GetMenuPlatilloById(menuPlatilloId);
                decimal precioPlatillo = menuPlatilloEcontrado.precio;
                precioTotal = precioTotal + precioPlatillo;

                PedidoPorMenuPlatilloRequest requestPedidoPorMenuPlatillo = new PedidoPorMenuPlatilloRequest
                {
                    idPedido = nuevoPedido.IdPedido,
                    idMenuPlatillo = menuPlatilloId,
                };

                if (menuPlatilloEcontrado.stock == _menuPlatilloQuery.GetById(menuPlatilloId).Solicitados)
                {
                    return EliminarPedido(nuevoPedido.IdPedido);
                }

                MenuPlatilloRequest modificacion = new MenuPlatilloRequest
                {
                    stock = menuPlatilloEcontrado.stock,
                    solicitados = _menuPlatilloQuery.GetById(menuPlatilloId).Solicitados + 1
                };

                _menuPlatilloService.ModificarMenuPlatillo(menuPlatilloId, modificacion);
                _pedidoPorMenuPlatilloService.CreatePedidoPorMenuPlatillo(requestPedidoPorMenuPlatillo);
            }

            _reciboService.CambiarPrecio(nuevoPedido.IdRecibo, precioTotal);

            return GetPedidoById(nuevoPedido.IdPedido);
        }




        public List<PedidoResponse> PedidosDelMenu(Guid idMenu)
        {
            throw new NotImplementedException();
        }

        public List<PedidoGetResponse> PedidoFiltrado(Guid? idPersonal, DateTime? Desde,DateTime? Hasta, int? cantidad)
        {   

            List<Pedido> pedidos = _query.GetPedidosFiltrado(idPersonal, Desde,Hasta,cantidad);
            List<PedidoGetResponse> pedidosResponse = new List<PedidoGetResponse>();

            foreach (var pedido in pedidos)
            {
                var nuevo = new PedidoGetResponse
                {
                    id = pedido.IdPedido,
                    Personal = pedido.IdPersonal,
                    Fecha = pedido.FechaDePedido,
                    Recibo = pedido.IdRecibo 
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
