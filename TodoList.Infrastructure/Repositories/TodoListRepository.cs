using TodoList.Application.Repositories;
using TodoList.Domain.Entities;

namespace TodoList.Infrastructure.Repositories;

internal class TodoListRepository : ITodoListRepository
{
    public Task<bool> AddTodoItem(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }

    public Task<TodoItem> DeleteTodoItem(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TodoItem>> GetTodoItems()
    {
        throw new NotImplementedException();
    }
    
    public Task<bool> UpdateTodoItem(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }
}
