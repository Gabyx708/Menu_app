using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IMenuPlatillo
{
    public interface IMenuPlatilloCommand
    {
        MenuPlatillo CreateMenuPlatillo(MenuPlatillo menuPlatillo);

        MenuPlatillo AsignarPlatilloAMenu(Guid idMenu, int idPlatillo, int stock);
    }
}
