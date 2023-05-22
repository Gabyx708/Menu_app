﻿using Application.Interfaces.IPlatillo;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Commands
{
    public class PlatilloCommand : IPlatilloCommand
    {
        private readonly MenuAppContext _context;

        public PlatilloCommand(MenuAppContext context)
        {
            _context = context;
        }

        public Platillo CreatePlatillo(Platillo platillo)
        {
            _context.Add(platillo);
            _context.SaveChanges();
            return platillo;
        }

        public Platillo UpdatePrecio(int idPlatillo, double nuevoPrecio)
        {
            Platillo platilloOriginal = _context.Platillos.Single(p => p.IdPlatillo == idPlatillo);

            platilloOriginal.Precio = nuevoPrecio;
            _context.SaveChanges();
            return platilloOriginal;
        }
    }
}
