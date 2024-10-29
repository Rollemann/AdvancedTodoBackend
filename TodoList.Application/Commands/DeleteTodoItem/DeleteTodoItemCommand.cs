using MediatR;

namespace TodoList.Application.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(int Id) : IRequest<DeleteTodoItemResult>;
