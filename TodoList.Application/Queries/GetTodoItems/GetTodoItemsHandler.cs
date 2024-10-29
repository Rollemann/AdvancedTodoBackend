using MediatR;
using TodoList.Application.Repositories;

namespace TodoList.Application.Queries.GetTodoItems;

public class GetTodoItemsHandler : IRequestHandler<GetTodoItemsQuery, GetTodoItemsResult>
{
    private readonly ITodoListRepository _todoListRepository;

    public GetTodoItemsHandler(ITodoListRepository todoListRepository)
    {
        this._todoListRepository = todoListRepository;
    }

    public async Task<GetTodoItemsResult> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
    {
        //TODO: Hier kann noch logger rein
        var todoItems = await _todoListRepository.GetTodoItems();
        return new GetTodoItemsResult(todoItems);
    }
}
