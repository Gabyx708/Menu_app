using Application.Request;
using Application.Response;

namespace Application.Interfaces.IPedidoPorMenuPlatillo
{
    public interface IPedidoPorMenuPlatilloService
    {
        PedidoPorMenuPlatilloResponse GetPedidoPorMenuPlatillo(Guid idPedido, Guid idMenuPlatilo);
        PedidoPorMenuPlatilloResponse CreatePedidoPorMenuPlatillo(PedidoPorMenuPlatilloRequest request);

        List<PedidoPorMenuPlatilloResponse> GetPedidosMenuPlatilloDePedido(Guid idPedido);

        List<PedidoPorMenuPlatilloResponse> GetPedidoPorMenuPlatilloDeMenu(Guid idMenu);

        PedidoPorMenuPlatilloResponse DeletePedidoPorMenuPlatillo(Guid idPedido, Guid idMenuPlatilo);
    }
}
