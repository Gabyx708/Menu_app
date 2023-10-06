using Application.Interfaces.IMenu;
using Application.Interfaces.IMenuPlatillo;
using Application.Interfaces.IPedido;
using Application.Interfaces.IPedidoPorMenuPlatillo;
using Application.Interfaces.IPersonal;
using Application.Interfaces.IPlatillo;
using Application.Interfaces.IRecibo;
using Application.Request.MenuPlatilloRequests;
using Application.Request.PedidoRequests;
using Application.Response.MenuPlatilloResponses;
using Application.Response.MenuResponses;
using Application.Response.PedidoResponses;
using Domain.Entities;

namespace Application.UseCase.Pedidos
{
    public class HacerUnPedidoConRestricciones : IEstrategiaHacerPedido
    {
        private readonly IPedidoQuery _pedidoQuery;
        private readonly IMenuService _menuService;
        private readonly IReciboService _reciboService;
        private readonly IMenuPlatilloService _menuPlatilloService;
        private readonly IMenuPlatilloQuery _menuPlatilloQuery;
        private readonly IPedidoPorMenuPlatilloService _pedidoPorMenuPlatilloService;
        private readonly IPedidoCommand _pedidoCommand;
        private readonly IPlatilloService _platilloService;
        private readonly IPersonalQuery _personalQuery;

        public HacerUnPedidoConRestricciones(IPedidoQuery pedidoQuery, IMenuService menuService, IReciboService reciboService, IMenuPlatilloService menuPlatilloService, IMenuPlatilloQuery menuPlatilloQuery, IPedidoPorMenuPlatilloService pedidoPorMenuPlatilloService, IPedidoCommand pedidoCommand, IPlatilloService platilloService, IPersonalQuery personalQuery)
        {
            _pedidoQuery = pedidoQuery;
            _menuService = menuService;
            _reciboService = reciboService;
            _menuPlatilloService = menuPlatilloService;
            _menuPlatilloQuery = menuPlatilloQuery;
            _pedidoPorMenuPlatilloService = pedidoPorMenuPlatilloService;
            _pedidoCommand = pedidoCommand;
            _platilloService = platilloService;
            _personalQuery = personalQuery;
        }

        public PedidoResponse RealizarPedido(PedidoRequest request)
        {
            List<Pedido> existePedido = _pedidoQuery.GetPedidosFiltrado(request.idUsuario, DateTime.Now.Date, DateTime.Now.Date, 1);
            var fechaActual = DateTime.Now;

            MenuResponse ultimoMenu = _menuService.GetUltimoMenu();

            var fechaCierreMenu = ultimoMenu.fecha_cierre;
            var fechaCargaMenu = ultimoMenu.fecha_carga;

            if (existePedido.Count > 0)
            {
                throw new InvalidOperationException();
            }

            if (fechaActual < fechaCargaMenu)
            {
                throw new InvalidOperationException();
            }

            if (fechaActual > fechaCierreMenu)
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

            _pedidoCommand.createPedido(nuevoPedido);

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
                    _pedidoCommand.DeletePedido(nuevoPedido.IdPedido);
                    return null;
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

            return recuperarPedido(nuevoPedido.IdPedido);
        }

        private PedidoResponse? recuperarPedido(Guid idPedido)
        {
            var pedido = _pedidoQuery.GetPedidoById(idPedido);

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

                var personal = _personalQuery.GetPersonalById(pedido.IdPersonal);

                return new PedidoResponse
                {
                    idPedido = idPedido,
                    Nombre = personal.Nombre + " " + personal.Apellido,
                    fecha = pedido.FechaDePedido,
                    platillos = platillosDelMenu,
                    recibo = _reciboService.GetReciboById(pedido.IdRecibo)
                };
            }

            return null;
        }

    }
}
