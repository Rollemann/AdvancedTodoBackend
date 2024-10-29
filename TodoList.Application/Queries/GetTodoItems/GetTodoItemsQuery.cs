using MediatR;

namespace TodoList.Application.Queries.GetTodoItems;

public record GetTodoItemsQuery() : IRequest<GetTodoItemsResult>;