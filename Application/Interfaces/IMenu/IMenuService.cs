using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IMenu
{
    public interface IMenuService
    {
        MenuResponse CreateMenu(MenuRequest request);
        MenuResponse GetMenuById(Guid id);

        MenuResponse GetNextMenu(DateTime date);
    }
}
