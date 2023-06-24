using Application.Request;
using Application.Response;

namespace Application.Interfaces.IAuthentication
{
    public interface IAuthenticationService
    {
        PersonalResponse autenticarUsuario(UsuarioLoginRequest usuario);
    }
}
