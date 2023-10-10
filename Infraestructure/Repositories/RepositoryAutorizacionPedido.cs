using Application.Interfaces.IAutorizacionPedido;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class RepositoryAutorizacionPedido : IRepositoryAutorizacionPedido
    {
        private readonly MenuAppContext _context;

        //TODO arreglar problemas de multiples instancias
        public RepositoryAutorizacionPedido(MenuAppContext context)
        {
            _context = context;
        }

        public async Task<AutorizacionPedido> CreateAutorizacionPedido(AutorizacionPedido entity)
        {
            _context.AutorizacionPedidos.Add(entity);
            await _context.SaveChangesAsync(); // Guardar los cambios de manera asincrónica en la base de datos

            return entity; // Devolver la entidad creada
        }

        public async Task<AutorizacionPedido> DeleteAutorizacionPedido(Guid idPedido, Guid idPersonal)
        {
            var found = await _context.AutorizacionPedidos.FirstOrDefaultAsync(ap => ap.IdPedido == idPedido  && ap.IdPersonal == idPersonal);

            if(found != null)
            {
                _context.AutorizacionPedidos.Remove(found);
                _context.SaveChanges();
                return found;
            }

            throw new Exception();
        }

        public async Task<AutorizacionPedido> GetAutorizacionPedidoByidPedido(Guid idPedido)
        {
            var found = await _context.AutorizacionPedidos.FirstOrDefaultAsync(ap => ap.IdPedido == idPedido);

            if(found != null)
            {
                return found;
            }

            throw new InvalidDataException();
        }

        public async Task<List<AutorizacionPedido>> GetAutorizacionesPedidoByIdPersonal(Guid idPersonal)
        {
            var autorizaciones = await _context.AutorizacionPedidos.Where(ap => ap.IdPersonal == idPersonal).ToListAsync();
            return autorizaciones;
        }

    }
}
