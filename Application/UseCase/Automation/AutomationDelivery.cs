using Application.Interfaces.IAutomation;
using Application.Interfaces.IMenu;
using Application.Interfaces.IPedido;
using Application.Interfaces.IPersonal;
using Application.Request.AutomationRequest;
using Application.Request.PedidoRequests;
using Application.Response.MenuResponses;
using Application.Response.PersonalResponses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tools.Automation
{
    public class AutomationDelivery : IAutomation
    {
        private readonly IPedidoService _services;
        private readonly IMenuService _menuService;
        private readonly IPersonalQuery _personalQuery;
        private readonly List<Personal> _personasMenuAutomatico;
        private readonly IPersonalCommand _personalCommand;
        private readonly IPersonalService _personalService;
        private Guid _menuPlatilloId;
        private MenuResponse _ultimoMenu;

        public AutomationDelivery(IPedidoService services, IMenuService menuService, IPersonalQuery personalQuery, IPersonalCommand personalCommand, IPersonalService personalService)
        {
            _services = services;
            _menuService = menuService;
            _ultimoMenu = _menuService.GetUltimoMenu();
            _personalQuery = personalQuery;
            _personasMenuAutomatico = _personalQuery.GetAll().Where(p => p.isAutomatico == true).ToList();
            _personalCommand = personalCommand;
            _personalService = personalService;
        }

        public bool HacerPedidosAutomatico()
        {
            if (_personasMenuAutomatico.Count == 0)
            {
                return false;
            }
            //´primera opcion del menu mas reciente
            Random random = new Random();

            int cantidadOpciones = _ultimoMenu.platillos.Count;
            int opcionAleatoria = random.Next(0, cantidadOpciones);

            _menuPlatilloId = _ultimoMenu.platillos[opcionAleatoria].idMenuPlato;

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

                try
                {
                    _services.HacerUnpedido(request);
                    contadorPedidos++;
                }
                catch (Exception e)
                {
                    // Sin embargo, si no deseas hacer nada especial, puedes omitir este bloque catch.
                }
            }

            return cantPedidos == contadorPedidos ? true : false;
        }

        public PersonalResponse SetPedidoAutomatico(AutomationRequest request)
        {
            Personal personal = _personalQuery.GetPersonalById(request.personalId);

            if (personal == null) { return null; }

            personal.isAutomatico = request.isAutomatico;

            try
            {
                _personalCommand.updatePersonal(personal.IdPersonal, personal);
                return _personalService.GetPersonalById(personal.IdPersonal);
            }
            catch (Exception e)
            {
                return null;
            }
           
        }
    }
}
