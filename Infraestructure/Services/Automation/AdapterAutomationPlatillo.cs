using Application.Interfaces.IServices.IAutomationService;
using Application.Models;
using Application.Tools.Log;
using System.Data;
using System.Text;
using System.Text.Json;

namespace Infraestructure.Services.Automation
{
    public class AdapterAutomationPlatillo : IAdapterAutomationPlatillo
    {
        private readonly HttpClient _httpClient;
        private string _serviceURL;

        public AdapterAutomationPlatillo(string serviceURL)
        {
            _serviceURL = serviceURL;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(serviceURL);
        }

        public PlatilloResponseAutomation inserPlatoInAutomation(PlatilloRequestAutomation request)
        {
            var urlPlato = "api/v1/platillo";

            // Utiliza UriBuilder para construir la URL de forma segura
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = urlPlato,
            };

            string json = JsonSerializer.Serialize(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            Logger.LogInformation("Sending request to external service. URL: [{@url}]", uriBuilder.Uri);
            HttpResponseMessage response = _httpClient.PostAsync(uriBuilder.Uri, data).Result;
            var statusCode = (int)response.StatusCode;

            if (statusCode == 201)
            {
                Logger.LogInformation("create new plato in automation service...");
                string responseBody = response.Content.ReadAsStringAsync().Result;

                var platoResponse = JsonSerializer.Deserialize<PlatilloResponseAutomation>(responseBody);

                if (platoResponse != null)
                {
                    return platoResponse;
                }

                Logger.LogWarning("data failed...");
                throw new DataException();
            }
            else
            {
                Logger.LogWarning("could not create new item in external service");
                throw new IOException();
            }
        }


        public PlatilloResponseAutomation GetPlatilloResponseAutomation(int idPlato)
        {
            var urlPlato = "/api/v1/platillo";

            // Utiliza UriBuilder para construir la URL de forma segura
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = urlPlato,
                Query = $"id={idPlato}"
            };

            _httpClient.Timeout = TimeSpan.FromMilliseconds(300);

            Logger.LogInformation("Sending request to external service. URL: [{@url}]", uriBuilder.Uri);
            HttpResponseMessage response = _httpClient.GetAsync(uriBuilder.Uri).Result;

            var statusCode = (int)response.StatusCode;
            Logger.LogInformation("status code from external service: >>>>[{@code}]", statusCode);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var platilloResponse = JsonSerializer.Deserialize<PlatilloResponseAutomation>(responseBody);

                if (platilloResponse != null)
                {
                    return platilloResponse;
                }

                throw new InvalidDataException();
            }

            throw new SystemException();

        }

      
    }
}
