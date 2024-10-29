using MediatR;
using TodoList.Application.Repositories;
using TodoList.Application.Validators;
using TodoList.Domain.Entities;

namespace TodoList.Application.Commands.UpdateTodoItem;

public class UpdateTodoItemHandler : IRequestHandler<UpdateTodoItemCommand, UpdateTodoItemResult>
{
    private readonly ITodoListRepository _todoListRepository;

    public UpdateTodoItemHandler(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    public async Task<UpdateTodoItemResult> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        if (!CronScheduleValidator.IsCronString(request.CronSchedule))
        {
            return new UpdateTodoItemResult(false);
        }
        var todoItem = new TodoItem()
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
            IsCompleted = request.IsCompleted,
            CronSchedule = request.CronSchedule,
            Repetitions = request.Repetitions,
            CategoryId = request.CategoryId,
        };
        var updated = await _todoListRepository.UpdateTodoItem(todoItem);
        return new UpdateTodoItemResult(updated);
    }
}
