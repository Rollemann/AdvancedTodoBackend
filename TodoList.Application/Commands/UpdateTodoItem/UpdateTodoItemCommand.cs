using MediatR;
using TodoList.Domain.Entities;

namespace TodoList.Application.Commands.UpdateTodoItem;

public record UpdateTodoItemCommand(
    int Id,
    string Title,
    string Description,
    bool IsCompleted,
    string CronSchedule,
    int Repetitions,
    int CategoryId
    ) : IRequest<UpdateTodoItemResult>;