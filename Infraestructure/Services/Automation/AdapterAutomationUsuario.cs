using Application.Interfaces.IServices.IAutomationService;
using Application.Models;
using Application.Tools.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infraestructure.Services.Automation
{
    public class AdapterAutomationUsuario : IAdapterAutomationUsuario
    {
        private readonly HttpClient _httpClient;
        private string _serviceURL;

        public AdapterAutomationUsuario(string serviceURL)
        {
            _serviceURL = serviceURL;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(serviceURL);
        }

        public List<CategoriaPrioridad> obtenerPrefenciasUsuario(Guid idUsuario)
        {
            var urlPreferencias = $"api/v1/preferencia/{idUsuario}";

            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = urlPreferencias,
            };

            Logger.LogInformation("Sending request to external service. URL: [{@url}]", uriBuilder.Uri);
            HttpResponseMessage response = _httpClient.GetAsync(uriBuilder.Uri).Result;

            var statusCode = (int)response.StatusCode;
            Logger.LogInformation("status code from external service: [{@code}]", statusCode);

            if (statusCode == 200)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var prefrenciasResponse = JsonSerializer.Deserialize<PreferenciaResponse>(responseBody);

                if (prefrenciasResponse == null || prefrenciasResponse.categorias == null)
                {
                    throw new InvalidCastException();
                }

                return prefrenciasResponse.categorias;
            }

            throw new InvalidCastException();
        }

        public UsuarioResponse crearUsuario(UsuarioRequest request)
        {
            var urlUsuario = "api/v1/user";

            // Utiliza UriBuilder para construir la URL de forma segura
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = urlUsuario,
            };

            string json = JsonSerializer.Serialize(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            Logger.LogInformation("Sending request to external service. URL: [{@url}]", uriBuilder.Uri);
            HttpResponseMessage response = _httpClient.PostAsync(uriBuilder.Uri, data).Result;
            var statusCode = (int)response.StatusCode;

            if(statusCode == 201)
            {
                Logger.LogInformation("create new user in automation service...");
                string responseBody = response.Content.ReadAsStringAsync().Result;

                var userResponse = JsonSerializer.Deserialize<UsuarioResponse>(responseBody);

                if(userResponse != null)
                {
                    return userResponse;
                }

                throw new InvalidOperationException();
            }

            throw new SystemException("no se pudo crear el usuario");
        }

        public PreferenciaResponse setearPreferenciasUsuario(PreferenciaRequest request)
        {
            var urlPreferenciaPost = "api/v1/preferencia";

            // Utiliza UriBuilder para construir la URL de forma segura
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = urlPreferenciaPost,
            };

            string json = JsonSerializer.Serialize(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            Logger.LogInformation("Sending request to external service. URL: [{@url}]", uriBuilder.Uri);
            HttpResponseMessage response = _httpClient.PostAsync(uriBuilder.Uri, data).Result;
            var statusCode = (int)response.StatusCode;

            if (statusCode == 201)
            {
                Logger.LogInformation("create new user in automation service...");
                string responseBody = response.Content.ReadAsStringAsync().Result;

                var preferenciaResponse = JsonSerializer.Deserialize<PreferenciaResponse>(responseBody);

                if (preferenciaResponse != null)
                {
                    return preferenciaResponse;
                }

                Logger.LogInformation("the response was null");
                throw new InvalidOperationException();
            }

            Logger.LogInformation("no se pudieron configurar las preferencias: CRITICAL");
            throw new SystemException("no se pudieron configurar las preferencias");
        }
        public PreferenciaResponse eliminarPreferenciasUsuario(Guid idUsuario)
        {
            var urlPreferencias = $"api/v1/preferencia/{idUsuario}";

            // Utiliza UriBuilder para construir la URL de forma segura
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = urlPreferencias,
            };

            Logger.LogInformation("Sending request to external service. URL: [{@url}]", uriBuilder.Uri);
            HttpResponseMessage response = _httpClient.DeleteAsync(uriBuilder.Uri).Result;
            var statusCode = (int)response.StatusCode;

            if(statusCode == 200)
            {
                Logger.LogInformation("removed preferences for user. USER: [{user}]",idUsuario);
                string responseBody = response.Content.ReadAsStringAsync().Result;

                var preferenciaResponse = JsonSerializer.Deserialize<PreferenciaResponse>(responseBody);

                if (preferenciaResponse != null)
                {
                    return preferenciaResponse;
                }

                Logger.LogInformation("the response was null");
                throw new InvalidOperationException();
            }

            Logger.LogInformation("external service response code: [{@code}]",statusCode);
            throw new InvalidOperationException();
        }

        public UsuarioResponse desactivarAutomatizacion(Guid idUsuario)
        {
            var urlPreferenciaEstado = $"api/v1/preferencia/{idUsuario}";

            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = urlPreferenciaEstado,
            };

            HttpResponseMessage response = _httpClient.PatchAsync(uriBuilder.Uri,null).Result;

            var statusCode = (int)response.StatusCode;

            if (statusCode == 200)
            {
                Logger.LogInformation("the automation status of this user was changed: [{@user}]", idUsuario);
                string responseBody = response.Content.ReadAsStringAsync().Result;

                var usuarioResponse = JsonSerializer.Deserialize<UsuarioResponse>(responseBody);

                if (usuarioResponse != null)
                {
                    return usuarioResponse;
                }

                Logger.LogInformation("the response was null");
                throw new InvalidOperationException();
            }

            Logger.LogInformation("external service response code: [{@code}]", statusCode);
            throw new InvalidOperationException();

        }
    }
}
