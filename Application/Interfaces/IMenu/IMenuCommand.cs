using Domain.Entities;

namespace Application.Interfaces.IMenu
{
    public interface IMenuCommand
    {
        Menu CreateMenu(Menu menu);

        Menu AsignarPlatillo(Guid idMenu, Platillo platillo);
    }
}
