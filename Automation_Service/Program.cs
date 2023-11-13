using Automation_Service;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<DeliveryWorker>();
    })
    .Build();

await host.RunAsync();
