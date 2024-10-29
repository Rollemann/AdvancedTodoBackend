using TodoList.Domain.Entities;

namespace TodoList.Application.Queries.GetCategories;

public record GetCategoriesResult(IEnumerable<Category> Categories);