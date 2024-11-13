using RabbitMQ.Client;
using TodoList.Application.Repositories;

namespace TodoList.Infrastructure.Repositories;

public class NotificationRepository : INotificationRepository
{
    public async void NotifyAddTodoItem(int id)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();
        await channel.QueueDeclareAsync(queue: "NewTodoItems", durable: false, exclusive: false, autoDelete: false, arguments: null);
        var body = BitConverter.GetBytes(id);
        await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "hello", body: body);
        Console.WriteLine("Ging raus: " + id);
    }

    public async void NotifyDeleteTodoItem(int id)
    {
        Console.WriteLine("Noch machen");
    }
}
