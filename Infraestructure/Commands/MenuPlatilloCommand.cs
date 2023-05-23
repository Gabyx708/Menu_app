using Application.Interfaces.IMenuPlatillo;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Commands
{
    public class MenuPlatilloCommand : IMenuPlatilloCommand
    {
        private readonly MenuAppContext _context;

        public MenuPlatilloCommand(MenuAppContext context)
        {
            _context = context;
        }

        public MenuPlatillo AsignarPlatilloAMenu(Guid idMenu,int idPlatillo,int stock)
        {   
            var platillo = _context.Platillos.Single(p => p.IdPlatillo == idPlatillo);

            var NuevoMenuPlatillo = new MenuPlatillo
            {
                IdMenu = idMenu,
                IdPlatillo = platillo.IdPlatillo,
                PrecioActual = platillo.Precio,
                Stock = stock,
                Solicitados = 0
            };

            return CreateMenuPlatillo(NuevoMenuPlatillo);
        }

        public MenuPlatillo CreateMenuPlatillo(MenuPlatillo menuPlatillo)
        {
            _context.Add(menuPlatillo);
            _context.SaveChanges();
            return menuPlatillo;
        }
    }
}
