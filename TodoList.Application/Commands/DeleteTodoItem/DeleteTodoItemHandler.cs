using MediatR;
using TodoList.Application.Repositories;

namespace TodoList.Application.Commands.DeleteTodoItem;

public class DeleteTodoItemHandler : IRequestHandler<DeleteTodoItemCommand, DeleteTodoItemResult>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly ITodoListRepository _todoListRepository;

    public DeleteTodoItemHandler(ITodoListRepository todoListRepository, INotificationRepository notificationRepository)
    {
        _todoListRepository = todoListRepository;
        _notificationRepository = notificationRepository;
    }

    public async Task<DeleteTodoItemResult> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _todoListRepository.DeleteTodoItem(request.Id);
        _notificationRepository.NotifyDeleteTodoItem(request.Id);
        return new DeleteTodoItemResult(deleted);
    }
}
