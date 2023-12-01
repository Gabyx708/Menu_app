using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices.IAutomationService
{
    public interface IAdapterAutomationPlatillo
    {
        PlatilloResponseAutomation inserPlatoInAutomation(PlatilloRequestAutomation request);
        PlatilloResponseAutomation GetPlatilloResponseAutomation(int idPlato);
    }
}
