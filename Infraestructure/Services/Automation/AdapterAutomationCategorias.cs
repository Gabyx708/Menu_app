using Application.Interfaces.IServices.IAutomationService;
using Application.Models;
using Application.Tools.Log;
using System.Text;
using System.Text.Json;

namespace Infraestructure.Services.Automation
{
    public class AdapterAutomationCategorias : IAdapterAutomationCategoria
    {
        private readonly HttpClient _httpClient;
        private string _serviceURL;

        public AdapterAutomationCategorias(string serviceURL)
        {
            _serviceURL = serviceURL;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(serviceURL);
        }

        public CategoriaResponse insertNuevaCategoria(CategoriaRequest request)
        {
            var urlCategoria = "api/v1/categoria";

            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = urlCategoria,
            };

            string json = JsonSerializer.Serialize(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            Logger.LogInformation("Sending request to external service. URL: [{@url}]", uriBuilder.Uri);
            HttpResponseMessage response = _httpClient.PostAsync(uriBuilder.Uri, data).Result;

            var statusCode = (int)response.StatusCode;
            Logger.LogInformation("status code from external service: [{@code}]", statusCode);

            if (statusCode == 201)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var categoriResponse = JsonSerializer.Deserialize<CategoriaResponse>(responseBody);

                if (categoriResponse == null)
                {
                    throw new InvalidCastException();
                }

                return categoriResponse;
            }

            throw new SystemException();
        }

        public List<CategoriaResponse> listaCategorias()
        {

            var urlCategoria = "api/v1/categoria";

            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = urlCategoria,
            };

            Logger.LogInformation("Sending request to external service. URL: [{@url}]", uriBuilder.Uri);
            HttpResponseMessage response = _httpClient.GetAsync(uriBuilder.Uri).Result;

            var statusCode = (int)response.StatusCode;
            Logger.LogInformation("status code from external service: [{@code}]", statusCode);

            if (statusCode == 200)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var categoriasResponse = JsonSerializer.Deserialize<List<CategoriaResponse>>(responseBody);

                if (categoriasResponse == null)
                {
                    throw new InvalidCastException();
                }

                return categoriasResponse;
            }

            throw new InvalidCastException();
        }
    }
}
