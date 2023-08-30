﻿using Application.Interfaces.IbotMenu;
using Application.Interfaces.IMenu;
using Application.Interfaces.IPedido;
using Application.Request;
using Application.Response.MenuResponses;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muneBot.Application.UseCase.HacerPedido
{
    public class HacerPedido : IbootMenu
    {
        private readonly IPedidoService _services;
        private readonly IMenuService _menuService;
        private readonly MenuAppContextForBoot _context;
        private readonly List<Personal> _personasMenuAutomatico;
        private  Guid _menuPlatilloId;
        private  MenuResponse _ultimoMenu;

        public HacerPedido(IPedidoService services, MenuAppContextForBoot context, IMenuService menuService)
        {
            _services = services;
            _context = context;
            _personasMenuAutomatico = _context.Personales.Where(p => p.isAutomatico == true).ToList();
            _menuService = menuService;
            _ultimoMenu = _menuService.GetUltimoMenu();
        }

        public bool HacerPedidosAutomaticos()
        {   
            //´primera opcion del menu mas reciente
            _menuPlatilloId = _ultimoMenu.platillos[0].idMenuPlato;

            //cantidad de pedidos automaticos
            int cantPedidos = _personasMenuAutomatico.Count;
            int contadorPedidos = 0;

            foreach (var persona in _personasMenuAutomatico)
            {
                var request = new PedidoRequest
                {
                    idUsuario = persona.IdPersonal,
                    MenuPlatillos = new List<Guid> { _menuPlatilloId }
                };

                _services.HacerUnpedido(request);
                contadorPedidos++;
            }

            return cantPedidos == contadorPedidos ? true : false;
        }
    }
}
