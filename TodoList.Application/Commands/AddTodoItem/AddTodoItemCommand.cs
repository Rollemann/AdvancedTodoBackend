using MediatR;

namespace TodoList.Application.Commands.AddTodoItem;

public record AddTodoItemCommand(
    string Title,
    string Description,
    string CronSchedule,
    int Repetitions,
    int CategoryId
    ) : IRequest<AddTodoItemResult>;