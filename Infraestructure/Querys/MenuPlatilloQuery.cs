﻿using Application.Interfaces.IMenuPlatillo;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Querys
{
    public class MenuPlatilloQuery : IMenuPlatilloQuery
    {
        private readonly MenuAppContext _context;

        public MenuPlatilloQuery(MenuAppContext context)
        {
            _context = context;
        }

        public MenuPlatillo GetById(Guid idMenuPlatillo)
        {
            var menuPlatilloRecuperado = _context.MenuPlatillos.Single(mp => mp.IdMenuPlatillo ==  idMenuPlatillo);
            return menuPlatilloRecuperado;
        }

        public List<MenuPlatillo> GetMenuPlatilloByMenuId(Guid idMenu)
        {
            return _context.MenuPlatillos.Where(mp => mp.IdMenu == idMenu).ToList();
        }
    }
}