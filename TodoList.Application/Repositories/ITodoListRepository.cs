using TodoList.Domain.Entities;

namespace TodoList.Application.Repositories;

public interface ITodoListRepository
{
    Task<IEnumerable<TodoItem>> GetTodoItems();

    Task<int> AddTodoItem(TodoItem todoItem);
    
    Task<bool> UpdateTodoItem(TodoItem todoItem);
    
    Task<bool> DeleteTodoItem(int id);
}
