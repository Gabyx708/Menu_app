using Application.Exceptions;
using Application.Interfaces.IAutomation;
using Application.Interfaces.IAutorizacionPedido;
using Application.Interfaces.IMenu;
using Application.Interfaces.IPedido;
using Application.Interfaces.IPersonal;
using Application.Request.AutomationRequest;
using Application.Request.PedidoRequests;
using Application.Response.MenuPlatilloResponses;
using Application.Response.MenuResponses;
using Application.Response.PedidoResponses;
using Application.Response.PersonalResponses;
using Application.Tools.Log;
using Application.UseCase.Automation;
using Domain.Entities;
using Microsoft.Extensions.Options;

namespace Application.Tools.Automation
{
    public class AutomationDelivery : IAutomation
    {

        public bool HacerPedidosAutomatico()
        {
            return true;
        }

    }
}
