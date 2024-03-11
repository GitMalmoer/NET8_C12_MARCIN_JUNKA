var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<ExampleLoopedBGService>();
builder.Services.AddHostedService<ExampleBGService>();
builder.Services.AddHostedService<ExampleHostedService>();
builder.Services.AddHostedService<MyService>();

builder.Services.Configure<HostOptions>(x =>
{
    x.ServicesStartConcurrently = true;
    x.ServicesStopConcurrently = false;
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();


public class ExampleLoopedBGService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("Working Working");
            await Task.Delay(1000);
        }
    }
}





public class ExampleBGService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (!stoppingToken.IsCancellationRequested)
            Console.WriteLine("Just Once");
    }
}


public class ExampleHostedService : IHostedService
{
    private readonly ILogger<ExampleHostedService> _logger;

    public ExampleHostedService(ILogger<ExampleHostedService> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("ExampleHostedService StartAsync");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("ExampleHostedService StopAsync");
        return Task.CompletedTask;
    }
}

/*
 * INTRODUCING IHOSTEDLIFECYCLESERVICE
The main change is the inclusion of a new interface in the Microsoft.Extensions.Hosting namespace named IHostedLifecycleService. 
This interface inherits from the existing IHostedService interface, extending it to add methods for new lifecycle events which occur before or after the existing StartAsync and StopAsync methods.
These provide a way to hook into more specific application lifetime events for some advanced scenarios.

The interface is defined as follows:
 * */



public class MyService : IHostedLifecycleService
{
    private readonly ILogger<MyService> _logger;

    public MyService(ILogger<MyService> logger)
    {
        _logger = logger;
    }

    public Task StartingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StartingAsync");
        _logger.LogInformation("IHostedLifecycleService STARTING[1]");
        return Task.CompletedTask;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StartAsync");
        _logger.LogInformation("IHostedLifecycleService START[2]");

        return Task.CompletedTask;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StartedAsync");
        _logger.LogInformation("IHostedLifecycleService STARTED[3]");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StopAsync");
        return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StoppedAsync");
        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("StoppingAsync");
        return Task.CompletedTask;
    }
}
