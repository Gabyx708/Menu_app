using Application.Interfaces.IMenuPlatillo;
using Application.Interfaces.IPedido;
using Application.Interfaces.IPedidoPorMenuPlatillo;
using Application.Interfaces.IPersonal;
using Application.Interfaces.IPlatillo;
using Application.Interfaces.IRecibo;
using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public PedidoService(IPedidoCommand command, IPedidoQuery query, IPersonalService personalService, IPedidoPorMenuPlatilloService pedidoPorMenuPlatilloService, IMenuPlatilloService menuPlatilloService, IPlatilloService platilloService, IReciboService reciboService)
        {
            _command = command;
            _query = query;
            _personalService = personalService;
            _pedidoPorMenuPlatilloService = pedidoPorMenuPlatilloService;
            _menuPlatilloService = menuPlatilloService;
            _platilloService = platilloService;
            _reciboService = reciboService;
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

                return new PedidoResponse
                {
                    idPedido = idPedido,
                    Nombre = _personalService.GetPersonalById(pedido.IdPersonal).nombre,
                    fecha = pedido.FechaDePedido,
                    platillos = platillosDelMenu
                };
            }

            return null;
        }
        public PedidoResponse EliminarPedido(Guid idPedido)
        {
            throw new NotImplementedException();
        }



        public PedidoResponse HacerUnpedido(PedidoRequest request)
        {
            double precioTotal = 0;

            Pedido nuevoPedido = new Pedido
            {
                IdPersonal = request.idUsuario,
                FechaDePedido = DateTime.Now,
                IdRecibo = _reciboService.CrearRecibo().id
            };

            _command.createPedido(nuevoPedido);

            foreach (var menuPlatillos in request.MenuPlatillos)
            {
                double precioPlatillo = _menuPlatilloService.GetMenuPlatilloById(menuPlatillos).precio;
                precioTotal = precioTotal + precioPlatillo;
                
                PedidoPorMenuPlatilloRequest requestPedidoPorMenuPlatillo = new PedidoPorMenuPlatilloRequest
                {
                    idPedido = nuevoPedido.IdPedido,
                    idMenuPlatillo = menuPlatillos,
                };

                _pedidoPorMenuPlatilloService.CreatePedidoPorMenuPlatillo(requestPedidoPorMenuPlatillo);
            }

            _reciboService.CambiarPrecio(nuevoPedido.IdRecibo, precioTotal);

            return GetPedidoById(nuevoPedido.IdPedido);
        }




        public List<PedidoResponse> PedidosDelMenu(Guid idMenu)
        {
            throw new NotImplementedException();
        }

        public List<PedidoResponse> PedidosPersonal(Guid idPersonal)
        {
            throw new NotImplementedException();
        }

        public List<PedidoResponse> PedidosPorFecha(DateTime fecha)
        {
            throw new NotImplementedException();
        }
    }
}
