using Application.Interfaces.IMenuPlatillo;
using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.MenuPlatillos
{
    public class MenuPlatilloService : IMenuPlatilloService
    {
        private readonly IMenuPlatilloQuery _query;
        private readonly IMenuPlatilloCommand _command;

        public MenuPlatilloService(IMenuPlatilloQuery query, IMenuPlatilloCommand command)
        {
            _query = query;
            _command = command;
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
            var menuPlatillo =  _query.GetById(id);

            return new MenuPlatilloResponse
            {
                id = menuPlatillo.IdPlatillo,
                precio = menuPlatillo.PrecioActual,
                stock = menuPlatillo.Stock,
                pedido = menuPlatillo.Solicitados
            };
        }

        public List<MenuPlatilloResponse> GetMenuPlatilloDelMenu(Guid idMenu)
        {
            var platillosDelMenu = _query.GetMenuPlatilloByMenuId(idMenu);
            List<MenuPlatilloResponse> menuPlatillos = new List<MenuPlatilloResponse>();

            foreach (var plato in platillosDelMenu)
            {
                var response = new MenuPlatilloResponse
                {
                    id = plato.IdPlatillo,
                    precio = plato.PrecioActual,
                    stock = plato.Stock,
                    pedido = plato.Solicitados
                };

                menuPlatillos.Add(response);
            }

            return menuPlatillos;
        }
    }
}
