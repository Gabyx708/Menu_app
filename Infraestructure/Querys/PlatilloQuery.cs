﻿using Application.Interfaces.IPlatillo;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Querys
{
    public class PlatilloQuery : IPlatilloQuery
    {
        private readonly MenuAppContext _context;

        public PlatilloQuery(MenuAppContext context)
        {
            _context = context;
        }

        public Platillo GetPlatilloById(int id)
        {
            var platilloEncontrado = _context.Platillos.Single(p => p.IdPlatillo == id);

            if(platilloEncontrado != null) { return platilloEncontrado; }

            return null;
        }

        public List<Platillo> GetAll()
        {
            return _context.Platillos.ToList();
        }
    }
}
