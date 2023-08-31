using Application.Request.AutomationRequest;
using Application.Response.PersonalResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IAutomation
{
    public interface IAutomation
    {
        bool HacerPedidosAutomatico();
        PersonalResponse SetPedidoAutomatico(AutomationRequest request);
    }
}
