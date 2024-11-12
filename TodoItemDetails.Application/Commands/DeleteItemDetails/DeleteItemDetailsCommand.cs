using MediatR;

namespace TodoItemDetails.Application.Commands.DeleteItemDetails;

public record DeleteItemDetailsCommand(string ItemDetailsId): IRequest<DeleteItemDetailsResult>;