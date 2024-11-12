using MediatR;

namespace TodoItemDetails.Application.Commands.UpdateItemDetails;

public record UpdateItemDetailsCommand(string ItemDetailsId, string Description, int TodoItemId) : IRequest<UpdateItemDetailsResult>;