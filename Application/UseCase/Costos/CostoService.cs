using Application.Interfaces.ICostos;
using Application.Interfaces.IDescuento;
using Application.Interfaces.IPedido;
using Application.Interfaces.IRecibo;
using Application.Response.CostoResponses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Costos
{
    public class CostoService : ICostoService
    {
        private readonly IPedidoQuery _pedidoQuery;
        private readonly IReciboQuery _reciboQuery;
        private readonly IDescuentoQuery _descuentoQuery;

        public CostoService(IPedidoQuery pedidoQuery, IReciboQuery reciboQuery, IDescuentoQuery descuentoQuery)
        {
            _pedidoQuery = pedidoQuery;
            _reciboQuery = reciboQuery;
            _descuentoQuery = descuentoQuery;
        }

        public CostoDiaResponse GetCostosDia(DateTime fecha)
        {
            List<Pedido> pedidosDelDia = _pedidoQuery.GetPedidosFiltrado(null, fecha, fecha, null);

            if (pedidosDelDia.Count == 0)
            {
                return null;
            }

            decimal Costototal = 0;
            decimal CostototalDescuento = 0;

            foreach (var pedido in pedidosDelDia)
            {
                Recibo reciboDelPedido = _reciboQuery.GetById(pedido.IdRecibo);
                decimal descuentoDelPedido = _descuentoQuery.GetById(reciboDelPedido.IdDescuento).Porcentaje;
                CostototalDescuento = CalcularDescuento(reciboDelPedido.precioTotal,descuentoDelPedido) + CostototalDescuento;
                Costototal = reciboDelPedido.precioTotal + Costototal;
            }

            return new CostoDiaResponse
            {
                Fecha = fecha,
                CostoconDescuento = CostototalDescuento,
                CostosinDescuento = Costototal
            };
        }

        public CostoPeriodoResponse GetCostosPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
        }

        public CostoPersonalResponse GetCostosPersonal(DateTime fecha, Guid idPersonal)
        {
            throw new NotImplementedException();
        }

        private decimal CalcularDescuento(decimal total, decimal porcentaje)
        {
            if (porcentaje < 0 || porcentaje > 100)
            {
                throw new ArgumentException("El porcentaje debe estar entre 0 y 100.");
            }

            decimal descuento = total * (porcentaje / 100);
            decimal resultado = total - descuento;

            return resultado;
        }
    }   

}
