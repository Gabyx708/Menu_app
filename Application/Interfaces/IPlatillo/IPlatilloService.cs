using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IPlatillo
{
    public interface IPlatilloService
    {
        PlatilloResponse GetPlatilloById(int idPlatillo);
        PlatilloResponse CreatePlatillo(PlatilloRequest request);
        PlatilloResponse UpdatePrecio(int idPlatillo,double nuevoPrecio);
        List<PlatilloResponse> GetAll();
    }
}
