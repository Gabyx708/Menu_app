using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services.Automation
{
    internal class AdapterAutomationJob
    {
        private readonly HttpClient _httpClient;
        private string _serviceURL;

        public AdapterAutomationJob(HttpClient httpClient, string serviceURL)
        {
            _httpClient = httpClient;
            _serviceURL = serviceURL;
        }

        public async Task initJob()
        {
            return;
        }
    }
}
