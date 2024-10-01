using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Repositories;
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Repositories;


namespace TodoList.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoListController : ControllerBase
{
    private readonly ILogger<TodoListController> _logger;

    public TodoListController(ILogger<TodoListController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "AddCategories")]
    public async Task<IEnumerable<Category>> AddCategory()
    {
        ICategoryRepository repo = new CategoryRepository(); // TODO: MediatR und Ref auf Infrastructure raus
        return await repo.GetCategories();
    }

    [HttpGet(Name = "GetCategories")]
    public async Task<IEnumerable<Category>> GetCategories()
    {
        ICategoryRepository repo = new CategoryRepository(); // TODO: MediatR und Ref auf Infrastructure raus
        return await repo.GetCategories();
    }

    [HttpPut(Name = "UpdateCategory")]
    public async Task<IEnumerable<Category>> UpdateCategory()
    {
        ICategoryRepository repo = new CategoryRepository(); // TODO: MediatR und Ref auf Infrastructure raus
        return await repo.GetCategories();
    }

    [HttpDelete(Name = "DeleteCategory")]
    public async Task<IEnumerable<Category>> DeleteCategory()
    {
        ICategoryRepository repo = new CategoryRepository(); // TODO: MediatR und Ref auf Infrastructure raus
        return await repo.GetCategories();
    }
}
