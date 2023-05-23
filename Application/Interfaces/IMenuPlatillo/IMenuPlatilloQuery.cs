using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IMenuPlatillo
{
    public interface IMenuPlatilloQuery
    {
        List<MenuPlatillo> GetMenuPlatilloByMenuId(Guid idMenu);
        MenuPlatillo GetById(Guid idMenuPlatillo);
    }
}
