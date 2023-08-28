using Application.Interfaces.IPersonal;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Commands
{
    public class PersonalCommand : IPersonalCommand
    {
        private readonly MenuAppContext _context;

        public PersonalCommand(MenuAppContext context)
        {
            _context = context;
        }

        public Personal createPersonal(Personal personal)
        {
            _context.Add(personal);
            _context.SaveChanges();
            return personal;
        }

        public Personal updatePersonal(Guid idPersonal, Personal personal)
        {
            var personalOriginal = _context.Personales.Single(p => p.IdPersonal == idPersonal);

            personalOriginal.Nombre = personal.Nombre;
            personalOriginal.Apellido = personal.Apellido;
            personalOriginal.Mail = personal.Mail;
            personalOriginal.Telefono = personal.Telefono;
            personalOriginal.Privilegio = personal.Privilegio;
            personalOriginal.FechaIngreso = personal.FechaIngreso;
            personalOriginal.FechaNac = personal.FechaNac;

            _context.SaveChanges();
            return _context.Personales.Single(p => p.IdPersonal == personalOriginal.IdPersonal);
        }
    }
}
