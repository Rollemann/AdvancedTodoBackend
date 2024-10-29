using Microsoft.EntityFrameworkCore;
using TodoList.Application.Repositories;
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Providers;

namespace TodoList.Infrastructure.Repositories;

public class TodoListRepository : ITodoListRepository
{

    private readonly TodoListContext _context;

    public TodoListRepository(TodoListContext context)
    {
        _context = context;
    }

    public async Task<int> AddTodoItem(TodoItem todoItem)
    {
        var categories = _context.Categories.Include(c => c.TodoItems);
        var category = categories.Where(c => c.Id == todoItem.CategoryId).FirstOrDefault() ?? categories.First();
        category.TodoItems ??= [];
        category.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();
        return todoItem.Id;
    }

    public async Task<IEnumerable<TodoItem>> GetTodoItems()
    {
        return await _context.TodoItems.ToListAsync();
    }

    public async Task<bool> UpdateTodoItem(TodoItem todoItem)
    {
        _context.TodoItems.Update(todoItem);
        try // TODO: Error Handling hier oder eher im Controller
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteTodoItem(int id)
    {
        var todoItem = new TodoItem() { Id = id, Title = String.Empty, Description = String.Empty, IsCompleted = true, CronSchedule = String.Empty, Repetitions = 0 };
        // TODO: Geht das hier drüber auch kürzer?
        _context.TodoItems.Remove(todoItem);
        try // TODO: Error Handling hier oder eher im Controller
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
