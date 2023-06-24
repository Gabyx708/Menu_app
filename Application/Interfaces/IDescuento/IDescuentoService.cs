using Application.Request;
using Application.Response;

namespace Application.Interfaces.IDescuento
{
    public interface IDescuentoService
    {
        DescuentoResponse crearDescuento(DescuentoRequest request);
        DescuentoResponse GetDescuentoById(Guid id);
        DescuentoResponse GetDescuentoVigente();
        DescuentoResponse GetByFecha(DateTime fecha);
        List<DescuentoResponse> GetAll();
    }
}
