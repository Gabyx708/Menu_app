using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices.IAutomationService
{
    public interface IAdapterAutomationUsuario
    {
        UsuarioResponse crearUsuario(UsuarioRequest request);
        List<CategoriaPrioridad> obtenerPrefenciasUsuario(Guid idUsuario);
        PreferenciaResponse setearPreferenciasUsuario(PreferenciaRequest request);
        PreferenciaResponse eliminarPreferenciasUsuario(Guid idUsuario);
        UsuarioResponse desactivarAutomatizacion(Guid idUsuario);
    }
}
