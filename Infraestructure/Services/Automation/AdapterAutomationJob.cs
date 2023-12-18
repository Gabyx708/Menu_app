using Application.Interfaces.IServices.IAutomationService;
using Application.Tools.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services.Automation
{
    public class AdapterAutomationJob : IAdapterAutomationJob
    {
        private readonly HttpClient _httpClient;
        private string _serviceURL;

        public AdapterAutomationJob(string serviceURL)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(serviceURL);
            _serviceURL = serviceURL;
        }

        public async Task initJob()
        {
            var urlJob = "/api/v1/job";

            // Utiliza UriBuilder para construir la URL de forma segura
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = urlJob
            };

            try
            {
                Logger.LogInformation("Sending request to external service. URL: [{@url}]", uriBuilder.Uri);
                HttpResponseMessage response = await _httpClient.PostAsync(uriBuilder.Uri, null);

                Logger.LogInformation("sending: start of work...");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ALERT! FAIL!", ex.Message);
            }

            
        }
    }
}
