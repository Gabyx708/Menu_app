using Application.Request.UsuarioLoginRequests;
using Application.Response.PersonalResponses;

namespace Application.Interfaces.IAuthentication
{
    public interface IAuthenticationService
    {
        PersonalResponse autenticarUsuario(UsuarioLoginRequest usuario);
    }
}
