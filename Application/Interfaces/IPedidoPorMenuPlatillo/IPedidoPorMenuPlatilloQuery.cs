using Domain.Entities;

namespace Application.Interfaces.IPedidoPorMenuPlatillo
{
    public interface IPedidoPorMenuPlatilloQuery
    {
        PedidoPorMenuPlatillo GetPedidoPorMenuPlatilloB(Guid idPedido, Guid idMenuPlatillo);

        List<PedidoPorMenuPlatillo> GetPedidoMenuPlatilloByMenu(Guid idMenu);

        List<PedidoPorMenuPlatillo> GetPedidoMenuPlatilloByPedido(Guid idPedido);
    }
}
