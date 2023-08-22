using Application.Interfaces.IPagos;
using Application.Interfaces.IPersonal;
using Application.Request;
using Application.Response.PagoResponses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Pagos
{
    public class PagoService : IPagoService
    {   
        private readonly IPagoCommand _command;
        private readonly IPagoQuery _query;
        private readonly IPersonalQuery _personalQuery;

        public PagoService(IPagoCommand command, IPagoQuery query, IPersonalQuery personalQuery)
        {
            _command = command;
            _query = query;
            _personalQuery = personalQuery;
        }


        public PagoResponse GetPagoResponseById(long id)
        {
            var pagoRecuperado = _query.GetPagoById(id);

            if(pagoRecuperado == null) { return null; }

            Personal personalDelPago = _personalQuery.GetPersonalById(pagoRecuperado.idPersonal);
            string nombrePersonal = personalDelPago.Nombre +" "+personalDelPago.Apellido;
            string dniPersonal = personalDelPago.Dni;

            return new PagoResponse
            {
                NumeroPago = pagoRecuperado.NumeroPago,
                NombreRegistrador = nombrePersonal,
                DniRegistrador = dniPersonal,
                Fecha = pagoRecuperado.FechaPago,
                Pedidos = null
            };
        }

        public PagoResponse HacerUnPago(PagoRequest request)
        {
            Pago nuevo = new Pago();
            nuevo.idPersonal = request.idPersonal;
            nuevo.FechaPago = DateTime.Now;

            foreach (var recibo in request.Recibos)
            {
                var reciboAsignado = new Recibo();
                reciboAsignado.IdRecibo = recibo;
                nuevo.Recibos.Add(reciboAsignado);
            }

            _command.InsertPago(nuevo);

            return GetPagoResponseById(nuevo.NumeroPago);
        }

        public PagoResponse ModificarAnulacion(long NumeroPago, bool IsAnulado)
        {
            throw new NotImplementedException();
        }

        public List<PagoResponse> ObtenerPagosFiltrados(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Pago> pagosRecuperados = _query.GetPagoFiltrado(fechaDesde, fechaHasta);
            
            if(pagosRecuperados.Count == 0) { return null; }

            List<PagoResponse> pagosMapeados = new List<PagoResponse>();

            foreach (var pago in pagosRecuperados)
            {
                var response = GetPagoResponseById(pago.NumeroPago);
                pagosMapeados.Add(response);
            }

            return pagosMapeados;
        }
    }
}
