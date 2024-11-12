using MediatR;

namespace TodoItemDetails.Application.Queries.GetItemDetails;

public record GetItemDetailsQuery(int TodoItemId) : IRequest<GetItemDetailsResult>;