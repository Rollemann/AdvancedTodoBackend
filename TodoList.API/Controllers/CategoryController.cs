using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TodoList.API.Models;
using TodoList.Application.Commands.AddCategory;
using TodoList.Application.Commands.DeleteCategory;
using TodoList.Application.Commands.UpdateCategory;
using TodoList.Application.Queries.GetCategories;


namespace TodoList.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly IMediator _mediator;


    public CategoryController(ILogger<CategoryController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType<AddCategoryResult>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryInput categoryInput)
    {
        try // TODO: in middle ware auslagern; Lieber hier try catch oder im Repo wie bei Update und Delete?
        {
            var addResult = await _mediator.Send(new AddCategoryCommand(categoryInput.Name, categoryInput.Color));
            if (addResult.Id < 0)
            {
                return BadRequest("Wrong color format.");
            }
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet]
    [ProducesResponseType<GetCategoriesResult>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCategories()
    {
        try // TODO: in middle ware auslagern
        {
            return Ok(await _mediator.Send(new GetCategoriesQuery()));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryInput categoryInput)
    {
        var updateResult = await _mediator.Send(new UpdateCategoryCommand(
            categoryInput.Id,
            categoryInput.Name,
            categoryInput.Color
            ));
        if (updateResult.Updated)
        {
            return Ok(); //TODO: Reicht hier nur ein OK ober braucht der Abfragende mehr Infos?
        }
        return BadRequest();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
        var deletedResult = await _mediator.Send(new DeleteCategoryCommand(categoryId));
        if (deletedResult.Deleted)
        {
            return Ok(); //TODO: Reicht hier nur ein OK ober braucht der Abfragende mehr Infos?
        }
        return BadRequest();
    }
}
