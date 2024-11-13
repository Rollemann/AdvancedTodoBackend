namespace TodoList.Application.Repositories;

public interface INotificationRepository
{
    public void NotifyAddTodoItem(int id);

    public void NotifyDeleteTodoItem(int id);
}
