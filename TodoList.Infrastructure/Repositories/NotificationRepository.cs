using RabbitMQ.Client;
using System.Text;
using TodoList.Application.Repositories;

namespace TodoList.Infrastructure.Repositories;

public class NotificationRepository : INotificationRepository
{
    public async void NotifyAddTodoItem(int id)
    {
        var factory = new ConnectionFactory { HostName = "rabbitmq" };
        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();
        await channel.QueueDeclareAsync(queue: "NewTodoItems", durable: false, exclusive: false, autoDelete: false, arguments: null);
        var body = BitConverter.GetBytes(id);
        await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "NewTodoItems", body: body);
        Console.WriteLine("Ging raus: " + id + " mit Body: " + BitConverter.ToInt32(body)); // TODO das hier raus
    }

    public async void NotifyDeleteTodoItem(int id)
    {
        Console.WriteLine("Noch machen");
    }
}
