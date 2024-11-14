using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using TodoItemDetails.Application.Repositories;
using Microsoft.Extensions.Logging;

namespace TodoItemDetails.Infrastructure.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly ILogger<ConsumerHostedService> _logger;

    public NotificationRepository(ILogger<ConsumerHostedService> logger)
    {
        _logger = logger;
    }

    public async Task ReceiveAddTodoItem(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory { HostName = "rabbitmq" };
        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(queue: "NewTodoItems", durable: false, exclusive: false, autoDelete: false,
            arguments: null);

        Console.WriteLine(" [*] Waiting for messages.");

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = BitConverter.ToInt32(body);
            Console.WriteLine($" [x] Received {message}");
            return Task.CompletedTask;
        };

        await channel.BasicConsumeAsync("NewTodoItems", autoAck: true, consumer: consumer);
    }

    public Task ReceiveDeleteTodoItem(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}
