using MediatR;
using TodoList.Application.Repositories;

namespace TodoList.Application.Commands.DeleteTodoItem;

public class DeleteTodoItemHandler : IRequestHandler<DeleteTodoItemCommand, DeleteTodoItemResult>
{
    private readonly ITodoListRepository _todoListRepository;

    public DeleteTodoItemHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    public async Task<DeleteTodoItemResult> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _todoListRepository.DeleteTodoItem(request.Id);
        return new DeleteTodoItemResult(deleted);
    }
}
