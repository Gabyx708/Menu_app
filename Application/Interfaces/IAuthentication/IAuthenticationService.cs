using Application.Request;
using Application.Response.PersonalResponses;

namespace Application.Interfaces.IAuthentication
{
    public interface IAuthenticationService
    {
        PersonalResponse autenticarUsuario(UsuarioLoginRequest usuario);
    }
}
