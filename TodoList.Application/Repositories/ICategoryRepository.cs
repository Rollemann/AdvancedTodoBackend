using TodoList.Domain.Entities;

namespace TodoList.Application.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategories();

    Task<int> AddCategory(Category category);

    Task<bool> UpdateCategory(Category category);

    Task<bool> DeleteCategory(int Id);
}
