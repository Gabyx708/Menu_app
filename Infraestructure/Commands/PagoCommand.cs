﻿using Application.Interfaces.IPagos;
using Domain.Entities;
using Infraestructure.Persistence;

namespace Infraestructure.Commands
{
    public class PagoCommand : IPagoCommand
    {
        private readonly MenuAppContext _context;

        public PagoCommand(MenuAppContext context)
        {
            _context = context;
        }

        public Pago InsertPago(Pago NuevoPago, List<Guid> idRecibos)
        {
            _context.Add(NuevoPago);
            _context.SaveChanges(); // Guardar el pago en la base de datos

            foreach (var recibo in idRecibos)
            {
                var reciboEncontrado = _context.Recibos.FirstOrDefault(r => r.IdRecibo == recibo);

                if (reciboEncontrado == null) { return null; }

                reciboEncontrado.NumeroPago = NuevoPago.NumeroPago;
                _context.Update(reciboEncontrado);
            }

            _context.SaveChanges(); // Actualizar los recibos con el número de pago
            return NuevoPago;
        }


        public Pago ModificarEstadoAnulado(long NPago, bool estadoAnulado)
        {
            var pagoOriginal = _context.Pagos.FirstOrDefault(p => p.NumeroPago == NPago);

            if (pagoOriginal == null) { return null; }

            pagoOriginal.IsAnulado = estadoAnulado;
            _context.Update(pagoOriginal);
            _context.SaveChanges();
            return pagoOriginal;
        }
    }
}