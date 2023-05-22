using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IMenu
{
    public interface IMenuQuery
    {
        Menu GetMenuById(Guid idMenu);

        List<MenuPlatillo> PlatillosDelMenu(Guid idMenu);
    }
}
