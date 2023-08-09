using Application.Response.CostoResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICostos
{
    public interface ICostoService
    {
        CostoDiaResponse GetCostosDia(DateTime fecha);
        CostoPersonalResponse GetCostosPersonal(DateTime fecha,Guid idPersonal);
        CostoPeriodoResponse GetCostosPeriodo(DateTime fechaInicio, DateTime fechaFin);
    }
}
