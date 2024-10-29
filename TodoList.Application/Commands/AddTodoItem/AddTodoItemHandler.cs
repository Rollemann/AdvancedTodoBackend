using MediatR;
using TodoList.Application.Repositories;
using TodoList.Application.Validators;
using TodoList.Domain.Entities;

namespace TodoList.Application.Commands.AddTodoItem;

public class AddTodoItemHandler : IRequestHandler<AddTodoItemCommand, AddTodoItemResult>
{
    private readonly ITodoListRepository _todoListRepository;

    public AddTodoItemHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    public async Task<AddTodoItemResult> Handle(AddTodoItemCommand request, CancellationToken cancellationToken)
    {
        if (!CronScheduleValidator.IsCronString(request.CronSchedule))
        {
            return new AddTodoItemResult(-1);
        }
        var todoItem = new TodoItem()
        {
            Title = request.Title,
            Description = request.Description,
            IsCompleted = false,
            CronSchedule = request.CronSchedule,
            Repetitions = request.Repetitions,
            CategoryId = request.CategoryId
        };
        var todoItemId = await _todoListRepository.AddTodoItem(todoItem);
        return new AddTodoItemResult(todoItemId);
    }
}
