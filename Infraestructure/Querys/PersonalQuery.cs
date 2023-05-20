﻿using Application.Interfaces.IPersonal;
using Infraestructure.Persistence;
using Domain.Entities;

namespace Infraestructure.Querys
{
    public class PersonalQuery : IPersonalQuery
    {
        private readonly MenuAppContext _context;

        public PersonalQuery(MenuAppContext context)
        {
            _context = context;
        }

        public List<Personal> GetAll()
        {
            return _context.Personales.ToList();
        }

        public Personal GetPersonalById(Guid idPersonal)
        {
            var PersonalEncontrado = _context.Personales.Single(p => p.IdPersonal == idPersonal);

            if (PersonalEncontrado != null)
            {
                return PersonalEncontrado;
            }

            return null;
        }
    }
}
