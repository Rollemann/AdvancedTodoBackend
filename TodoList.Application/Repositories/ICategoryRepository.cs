
using TodoList.Domain;

namespace TodoList.Application.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<bool> AddCategory(Category category);
        Task<bool> UpdateCategory(Category category);
        Task<Category> DeleteCategory(string id);
    }
}
