using Application.Interfaces.IMenu;
using Application.Interfaces.IMenuPlatillo;
using Application.Interfaces.IPlatillo;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCase.Menues
{
    public class MenuService : IMenuService
    {
        private readonly IMenuCommand _command;
        private readonly IMenuQuery _query;
        private readonly IMenuPlatilloService _serviceMenuPlatillo;

        public MenuService(IMenuCommand command, IMenuQuery query, IMenuPlatilloService serviceMenuPlatillo)
        {
            _command = command;
            _query = query;
            _serviceMenuPlatillo = serviceMenuPlatillo;
        }

        public MenuResponse CreateMenu(MenuRequest request)
        {
            var nuevoMenu = new Menu
            {
                FechaConsumo = request.fecha_consumo,
                FechaCierre = request.fecha_cierre,
                FechaCarga = DateTime.Now
            };

            _command.CreateMenu(nuevoMenu);

            _serviceMenuPlatillo.AsignarPlatillosAMenu(nuevoMenu.IdMenu,request.platillosDelMenu);

            return new MenuResponse
            {
                id = nuevoMenu.IdMenu,
                fecha_consumo = nuevoMenu.FechaConsumo,
                fecha_carga = nuevoMenu.FechaCarga,
                fecha_cierre = nuevoMenu.FechaCierre,
                platillos = _serviceMenuPlatillo.GetMenuPlatilloDelMenu(nuevoMenu.IdMenu)
            };
        }

        public MenuResponse GetMenuById(Guid id)
        {
            var menuRecuperado = _query.GetMenuById(id);

            return new MenuResponse
            {
                id = menuRecuperado.IdMenu,
                fecha_consumo = menuRecuperado.FechaConsumo,
                fecha_carga = menuRecuperado.FechaCarga,
                fecha_cierre = menuRecuperado.FechaCierre,
                platillos = _serviceMenuPlatillo.GetMenuPlatilloDelMenu(menuRecuperado.IdMenu)
            };
        }

        public MenuResponse GetNextMenu(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
