using Application.Interfaces.IAuthentication;
using Application.Interfaces.IPersonal;
using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(persona == null) { return null; };
            return _personalService.GetPersonalById(persona.IdPersonal);
        }
    }
}
