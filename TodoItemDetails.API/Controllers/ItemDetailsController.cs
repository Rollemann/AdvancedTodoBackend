using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoItemDetails.API.Models;
using TodoItemDetails.Application.Commands.AddItemDetails;
using TodoItemDetails.Application.Commands.DeleteItemDetails;
using TodoItemDetails.Application.Commands.UpdateItemDetails;
using TodoItemDetails.Application.Queries.GetItemDetails;

namespace TodoItemDetails.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemDetailsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ItemDetailsController> _logger;

    public ItemDetailsController(ILogger<ItemDetailsController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType<AddItemDetailsResult>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddItemDetails([FromBody] AddItemDetailsInput itemDetailsInput)
    {
        try // TODO: in middle ware auslagern; Lieber hier try catch oder im Repo wie bei Update und Delete?
        {
            var addResult = await _mediator.Send(new AddItemDetailsCommand(itemDetailsInput.TodoItemId, itemDetailsInput.Description));
            return Ok(addResult);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest();
        }
    }

    [HttpGet]
    [ProducesResponseType<GetItemDetailsResult>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetItemDetailsByTodoId(int todoId)
    {
        try // TODO: in middle ware auslagern
        {
            return Ok(await _mediator.Send(new GetItemDetailsQuery(todoId)));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateItemDetails([FromBody] UpdateItemDetailsInput itemDetailsInput)
    {
        var updateResult = await _mediator.Send(new UpdateItemDetailsCommand(
            itemDetailsInput.ItemDetailsId,
            itemDetailsInput.Description,
            itemDetailsInput.TodoItemId
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
    public async Task<IActionResult> DeleteItemDetails(string itemDetailsId)
    {
        var deletedResult = await _mediator.Send(new DeleteItemDetailsCommand(itemDetailsId));
        if (deletedResult.Deleted)
        {
            return Ok(); //TODO: Reicht hier nur ein OK ober braucht der Abfragende mehr Infos?
        }
        return BadRequest();
    }

}
