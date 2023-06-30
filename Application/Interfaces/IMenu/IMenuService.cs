using Application.Request;
using Application.Response;

namespace Application.Interfaces.IMenu
{
    public interface IMenuService
    {
        MenuResponse CreateMenu(MenuRequest request);
        MenuResponse GetMenuById(Guid id);

        MenuResponse GetUltimoMenu();
        MenuResponse BorrarMenu(Guid idMenu);
    }
}
