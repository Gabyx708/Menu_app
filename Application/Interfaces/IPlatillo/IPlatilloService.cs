using Application.Request;
using Application.Response.PlatilloResponses;

namespace Application.Interfaces.IPlatillo
{
    public interface IPlatilloService
    {
        PlatilloResponse GetPlatilloById(int idPlatillo);
        PlatilloResponse CreatePlatillo(PlatilloRequest request);
        PlatilloResponse UpdatePrecio(int idPlatillo, double nuevoPrecio);
        List<PlatilloResponse> GetAll();
    }
}
