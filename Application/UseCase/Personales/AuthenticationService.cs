using Application.Interfaces.IAuthentication;
using Application.Interfaces.IPersonal;
using Application.Request.PersonalRequests;
using Application.Request.UsuarioLoginRequests;
using Application.Response.PersonalResponses;
using Application.Tools.Encrypt;

namespace Application.UseCase.Personales
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticacionQuery _query;
        private readonly IPersonalService _personalService;
        private readonly IPersonalCommand _personalCommand;
        private readonly IPersonalQuery _personalQuery;
        public AuthenticationService(IAuthenticacionQuery query, IPersonalService personalService, IPersonalQuery personalQuery, IPersonalCommand personalCommand)
        {
            _query = query;
            _personalService = personalService;
            _personalQuery = personalQuery;
            _personalCommand = personalCommand;
        }

        public PersonalResponse autenticarUsuario(UsuarioLoginRequest request)
        {
            var persona = _query.Autenticarse(request.username, request.password);
            if (persona == null) { return null; };
            return _personalService.GetPersonalById(persona.IdPersonal);
        }

        public PersonalResponse changeUserPassword(Guid idUser, PersonalPasswordRequest request)
        {
            string requestOriginalPassword = Encrypt256.GetSHA256(request.originalPassword);
            string nuevaPassword = Encrypt256.GetSHA256(request.newPassword);

            var personal = _personalQuery.GetPersonalById(idUser);
            string originalPassword = personal.Password;

            if (personal != null && originalPassword == requestOriginalPassword)
            {
                personal.Password = nuevaPassword;
                _personalCommand.updatePersonal(idUser, personal);
                return _personalService.GetPersonalById(idUser);
            }

            return null;
        }

        public PersonalResponse resetPassword(Guid idUser)
        {
            var personal = _personalQuery.GetPersonalById(idUser);

            if (personal !=null) {
                var passwordRest = Encrypt256.GetSHA256(personal.Dni);
                personal.Password = passwordRest;
                _personalCommand.updatePersonal(idUser, personal);
                return _personalService.GetPersonalById(idUser);
            }

            return null;
        }
    }
}
