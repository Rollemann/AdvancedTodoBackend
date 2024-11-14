namespace TodoItemDetails.Application.Repositories;

public interface INotificationRepository
{
    public Task ReceiveAddTodoItem(CancellationToken stoppingToken);
    public Task ReceiveDeleteTodoItem(CancellationToken stoppingToken);
}
