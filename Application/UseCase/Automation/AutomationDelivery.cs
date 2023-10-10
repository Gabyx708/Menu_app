using Application.Interfaces.IAutomation;
using Application.Interfaces.IMenu;
using Application.Interfaces.IPedido;
using Application.Interfaces.IPersonal;
using Application.Request.AutomationRequest;
using Application.Request.PedidoRequests;
using Application.Response.MenuPlatilloResponses;
using Application.Response.MenuResponses;
using Application.Response.PersonalResponses;
using Application.UseCase.Automation;
using Domain.Entities;
using Microsoft.Extensions.Options;

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
        private string idUsuarioBOT;
        private MenuResponse _ultimoMenu;

        public AutomationDelivery(IPedidoService services, IMenuService menuService, IPersonalQuery personalQuery, IPersonalCommand personalCommand, IPersonalService personalService, IOptions<OptionsDelivery> options)
        {
            _services = services;
            _menuService = menuService;
            _personalQuery = personalQuery;
            _personasMenuAutomatico = _personalQuery.GetAll().Where(p => p.isAutomatico == true).ToList();
            _personalCommand = personalCommand;
            _personalService = personalService;
            this.idUsuarioBOT = options.Value.IdUsuarioBOT;
        }

        public bool HacerPedidosAutomatico()
        {
            if (_personasMenuAutomatico.Count == 0)
            {
                return false;
            }

            //obtener ultimo menu cargado
            _ultimoMenu = _menuService.GetUltimoMenu();

            //cantidad de pedidos automaticos
            int cantPedidos = _personasMenuAutomatico.Count;
            int contadorPedidos = 0;

            foreach (var persona in _personasMenuAutomatico)
            {
                int opcion = randomMenuOpcion();

                MenuPlatilloGetResponse opcionElegida = _ultimoMenu.platillos[opcion];

              
                while(opcionElegida.stock <= opcionElegida.pedido)
                {
                    opcion = randomMenuOpcion();
                    opcionElegida = _ultimoMenu.platillos[opcion];
                }

                _menuPlatilloId = opcionElegida.idMenuPlato;

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

        private int randomMenuOpcion()
        {
            //´primera opcion del menu mas reciente
            Random random = new Random();

            int cantidadOpciones = _ultimoMenu.platillos.Count;
            int opcionAleatoria = random.Next(0, cantidadOpciones);
            return opcionAleatoria;
        }
    }
}
