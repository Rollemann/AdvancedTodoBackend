using TodoList.Domain.Entities;

namespace TodoList.Application.Queries.GetTodoItems;

public record GetTodoItemsResult(IEnumerable<TodoItem> TodoItems);
