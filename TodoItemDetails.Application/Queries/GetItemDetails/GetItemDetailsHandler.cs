using MediatR;
using TodoItemDetails.Application.Repositories;

namespace TodoItemDetails.Application.Queries.GetItemDetails;

public class GetItemDetailsHandler : IRequestHandler<GetItemDetailsQuery, GetItemDetailsResult>
{
    private readonly IItemDetailsRepository _itemDetailsRepository;

    public GetItemDetailsHandler(IItemDetailsRepository itemDetailsRepository)
    {
        _itemDetailsRepository = itemDetailsRepository;
    }

    public async Task<GetItemDetailsResult> Handle(GetItemDetailsQuery request, CancellationToken cancellationToken)
    {
        var itemDetails = await _itemDetailsRepository.GetItemDetailByTodoId(request.TodoItemId);
        return new GetItemDetailsResult(itemDetails);
    }
}
