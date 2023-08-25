﻿using Application.Interfaces.IPagos;
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

            List<Guid> idRecibos = new List<Guid>();

            foreach (var reciboId in pagoRecuperado.Recibos)
            {
                idRecibos.Add(reciboId.IdRecibo);
            }

            return new PagoResponse
            {
                NumeroPago = pagoRecuperado.NumeroPago,
                NombreRegistrador = nombrePersonal,
                DniRegistrador = dniPersonal,
                Fecha = pagoRecuperado.FechaPago,
                Recibos = idRecibos,
                Monto = pagoRecuperado.MontoPagado
            };
        }

        public PagoResponse HacerUnPago(PagoRequest request)
        {
            Pago nuevoPago = new Pago();
            nuevoPago.idPersonal = request.idPersonal;
            nuevoPago.FechaPago = DateTime.Now;


            _command.InsertPago(nuevoPago,request.Recibos);

            return GetPagoResponseById(nuevoPago.NumeroPago);
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
