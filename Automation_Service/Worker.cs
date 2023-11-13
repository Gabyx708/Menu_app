using Application.Interfaces.ICoordinationServices;

namespace Automation_Service
{
    public class DeliveryWorker : BackgroundService
    {
        private readonly ILogger<DeliveryWorker> _logger;
        private readonly ICoordinatingService _coordinatingService;

        public DeliveryWorker(ILogger<DeliveryWorker> logger, ICoordinatingService coordinatingService)
        {
            _logger = logger;
            _coordinatingService = coordinatingService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                Console.WriteLine("hi");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}