using Application.Interfaces.IMenu;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Querys
{
    public class MenuQuery : IMenuQuery
    {
        private readonly MenuAppContext _context;

        public MenuQuery(MenuAppContext context)
        {
            _context = context;
        }

        public Menu GetMenuById(Guid idMenu)
        {
            var menuEncontrado = _context.Menues.Single(m => m.IdMenu == idMenu);
            return menuEncontrado;
        }

        public List<MenuPlatillo> PlatillosDelMenu(Guid idMenu)
        {
           return _context.MenuPlatillos.Where(mp => mp.IdMenu == idMenu).ToList();
        }
    }
}
