using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IMenuPlatillo
{
    public interface IMenuPlatilloService
    {
        MenuPlatilloResponse GetMenuPlatilloById(Guid id);
        List<MenuPlatilloGetResponse> GetMenuPlatilloDelMenu(Guid idMenu);

        List<MenuPlatilloResponse> AsignarPlatillosAMenu(Guid idMenu, List<MenuPlatilloRequest> platillos);
    }
}
