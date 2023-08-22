using Application.Interfaces.IPagos;
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

        public Pago InsertPago(Pago NuevoPago)
        {   
            _context.Add(NuevoPago);

            foreach (var recibo in NuevoPago.Recibos)
            {
               var reciboEncontrado = _context.Recibos.FirstOrDefault(r => r.IdRecibo == recibo.IdRecibo);

                if(reciboEncontrado == null) { return null; }

                reciboEncontrado.NumeroPago = NuevoPago.NumeroPago;
                _context.Update(reciboEncontrado);
            }

            _context.SaveChanges();
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
