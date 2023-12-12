using Application.Interfaces.IMenuPlatillo;
using Application.Interfaces.IPlatillo;
using Application.Interfaces.IServices.IAutomationService;
using Application.Request.MenuPlatilloRequests;
using Application.Response.MenuPlatilloResponses;
using Domain.Entities;

namespace Application.UseCase.MenuPlatillos
{
    public class MenuPlatilloService : IMenuPlatilloService
    {
        private readonly IMenuPlatilloQuery _query;
        private readonly IMenuPlatilloCommand _command;
        private readonly IPlatilloService _platilloService;
        private readonly IAdapterAutomationPlatillo _adapterAutomationPlatillo;

        public MenuPlatilloService(IMenuPlatilloQuery query, IMenuPlatilloCommand command, IPlatilloService platilloService, 
                                   IAdapterAutomationPlatillo adapterAutomationPlatillo)
        {
            _query = query;
            _command = command;
            _platilloService = platilloService;
            _adapterAutomationPlatillo = adapterAutomationPlatillo;
        }

        public List<MenuPlatilloResponse> AsignarPlatillosAMenu(Guid idMenu, List<MenuPlatilloRequest> platillos)
        {
            foreach (var platillo in platillos)
            {
                _command.AsignarPlatilloAMenu(idMenu, platillo.id, platillo.stock);
            }

            var platillosDelMenu = _query.GetMenuPlatilloByMenuId(idMenu);
            List<MenuPlatilloResponse> menuPlatillos = new List<MenuPlatilloResponse>();

            foreach (var platilloMapear in platillosDelMenu)
            {
                var platilloResponse = new MenuPlatilloResponse
                {
                    id = platilloMapear.IdPlatillo,
                    precio = platilloMapear.PrecioActual,
                    stock = platilloMapear.Stock,
                    pedido = platilloMapear.Solicitados
                };

                menuPlatillos.Add(platilloResponse);
            }

            return menuPlatillos;
        }

        public MenuPlatilloResponse GetMenuPlatilloById(Guid id)
        {
            var menuPlatillo = _query.GetById(id);

            return new MenuPlatilloResponse
            {
                id = menuPlatillo.IdPlatillo,
                precio = menuPlatillo.PrecioActual,
                stock = menuPlatillo.Stock,
                pedido = menuPlatillo.Solicitados
            };
        }

        public List<MenuPlatilloGetResponse> GetMenuPlatilloDelMenu(Guid idMenu)
        {
            var platillosDelMenu = _query.GetMenuPlatilloByMenuId(idMenu);
            List<MenuPlatilloGetResponse> menuPlatillos = new List<MenuPlatilloGetResponse>();

            foreach (var plato in platillosDelMenu)
            {
                CategoriaPlato categoria = new CategoriaPlato();

                try
                {
                    var data = _adapterAutomationPlatillo.GetPlatilloResponseAutomation(plato.IdPlatillo);

                    if (data != null)
                    {
                        categoria = new CategoriaPlato
                        {
                            descripcion = data.categoria,
                            color = data.color
                        };
                    }
                }
                catch (Exception)
                {
                    categoria = new CategoriaPlato();
                }
                

                var response = new MenuPlatilloGetResponse
                {
                    id = plato.IdPlatillo,
                    idMenuPlato = plato.IdMenuPlatillo,
                    descripcion = _platilloService.GetPlatilloById(plato.IdPlatillo).descripcion,
                    precio = plato.PrecioActual,
                    stock = plato.Stock,
                    pedido = plato.Solicitados,
                    categoria = categoria
                };

                menuPlatillos.Add(response);
            }

            return menuPlatillos;
        }

        public MenuPlatilloResponse ModificarMenuPlatillo(Guid idMenuPlatillo, MenuPlatilloRequest menuPlatillo)
        {
            var menuPlato = new MenuPlatillo
            {
                Stock = menuPlatillo.stock,
                Solicitados = menuPlatillo.solicitados
            };

            var found = _command.UpdateMenuPlatillo(idMenuPlatillo, menuPlato);
            return GetMenuPlatilloById(idMenuPlatillo);
        }
    }
}
