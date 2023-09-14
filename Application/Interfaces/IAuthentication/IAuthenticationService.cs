using Application.Request.PersonalRequests;
using Application.Request.UsuarioLoginRequests;
using Application.Response.PersonalResponses;

namespace Application.Interfaces.IAuthentication
{
    public interface IAuthenticationService
    {
        PersonalResponse autenticarUsuario(UsuarioLoginRequest usuario);
        PersonalResponse changeUserPassword(Guid idUser, PersonalPasswordRequest request);
        PersonalResponse resetPassword(Guid idUser);
    }
}
