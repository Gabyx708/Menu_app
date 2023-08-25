using Application.Interfaces.IAuthentication;
using Application.Interfaces.IPersonal;
using Application.Request.UsuarioLoginRequests;
using Application.Response.PersonalResponses;

namespace Application.UseCase.Personales
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticacionQuery _query;
        private readonly IPersonalService _personalService;
        public AuthenticationService(IAuthenticacionQuery query, IPersonalService personalService)
        {
            _query = query;
            _personalService = personalService;
        }

        public PersonalResponse autenticarUsuario(UsuarioLoginRequest request)
        {
            var persona = _query.Autenticarse(request.username, request.password);
            if (persona == null) { return null; };
            return _personalService.GetPersonalById(persona.IdPersonal);
        }
    }
}
