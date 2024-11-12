using MediatR;

namespace TodoItemDetails.Application.Commands.AddItemDetails;

public record AddItemDetailsCommand(int TodoItemId, string Description) : IRequest<AddItemDetailsResult>;