﻿using Application.Request;
using Application.Response.MenuPlatilloResponses;
using Domain.Entities;

namespace Application.Interfaces.IMenuPlatillo
{
    public interface IMenuPlatilloService
    {
        MenuPlatilloResponse GetMenuPlatilloById(Guid id);
        List<MenuPlatilloGetResponse> GetMenuPlatilloDelMenu(Guid idMenu);

        List<MenuPlatilloResponse> AsignarPlatillosAMenu(Guid idMenu, List<MenuPlatilloRequest> platillos);
        MenuPlatilloResponse ModificarMenuPlatillo(Guid idMenuPlatillo, MenuPlatilloRequest menuPlatillo);
    }
}
