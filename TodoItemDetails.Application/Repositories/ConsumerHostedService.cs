using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TodoItemDetails.Application.Repositories;

public class ConsumerHostedService : BackgroundService
{
    private readonly ILogger<ConsumerHostedService> _logger;
    
    public IServiceProvider ServiceProvider { get; }

    public ConsumerHostedService(ILogger<ConsumerHostedService> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        ServiceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Starting background consumer.");

        using (var scope = ServiceProvider.CreateScope())
        {
            var scopedProcessingService =
                scope.ServiceProvider.GetRequiredService<INotificationRepository>();

            await scopedProcessingService.ReceiveAddTodoItem(stoppingToken);
            //await scopedProcessingService.ReceiveDeleteTodoItem(stoppingToken);
        }
    }
}
