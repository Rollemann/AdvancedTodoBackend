using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoList.API.Models;
using TodoList.Application.Commands.AddTodoItem;
using TodoList.Application.Commands.DeleteTodoItem;
using TodoList.Application.Commands.UpdateTodoItem;
using TodoList.Application.Queries.GetTodoItems;

namespace TodoList.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoItemController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly IMediator _mediator;


    public TodoItemController(ILogger<CategoryController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType<AddTodoItemResult>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddTodoItem([FromBody] AddTodoItemInput todoItemInput)
    {
        try // TODO: in middle ware auslagern; Lieber hier try catch oder im Repo wie bei Update und Delete?
        {
            var addResult = await _mediator.Send(new AddTodoItemCommand(
                todoItemInput.Title,
                todoItemInput.Description,
                todoItemInput.CronSchedule,
                todoItemInput.Repetitions,
                todoItemInput.CategoryId
                ));
            if (addResult.Id < 0)
            {
                return BadRequest("Wrong cron format");
            }
            return Ok(addResult);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet]
    [ProducesResponseType<GetTodoItemsResult>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetTodoItems()
    {
        try // TODO: in middle ware auslagern
        {
            return Ok(await _mediator.Send(new GetTodoItemsQuery()));
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest();
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateTodoItem([FromBody] UpdateTodoItemInput todoItemInput)
    {
        var updateResult = await _mediator.Send(new UpdateTodoItemCommand(
            todoItemInput.Id,
            todoItemInput.Title,
            todoItemInput.Description,
            todoItemInput.IsCompleted,
            todoItemInput.CronSchedule,
            todoItemInput.Repetitions,
            todoItemInput.CategoryId
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
    public async Task<IActionResult> DeleteCategory(int todoId)
    {
        var deletedResult = await _mediator.Send(new DeleteTodoItemCommand(todoId));
        if (deletedResult.Deleted)
        {
            return Ok(); //TODO: Reicht hier nur ein OK ober braucht der Abfragende mehr Infos?
        }
        return BadRequest();
    }
}
