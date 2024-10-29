using TodoList.Application.Repositories;
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Providers;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly TodoListContext _context;

    public CategoryRepository(TodoListContext context)
    {
        _context = context;
    }

    public async Task<int> AddCategory(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category.Id;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<bool> UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
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

    public async Task<bool> DeleteCategory(int id)
    {
        if (id == 1)
        {
            return false;
        }

        var category = new Category() { Id = id, Name = String.Empty, Color = String.Empty, TodoItems = [] };
        _context.Categories.Remove(category);
        
        try
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
