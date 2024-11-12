using MediatR;
using MongoDB.Bson;
using TodoItemDetails.Application.Repositories;

namespace TodoItemDetails.Application.Commands.DeleteItemDetails;

public class DeleteItemDetailsHandler : IRequestHandler<DeleteItemDetailsCommand, DeleteItemDetailsResult>
{
    private readonly IItemDetailsRepository _itemDetailsRepository;

    public DeleteItemDetailsHandler(IItemDetailsRepository itemDetailsRepository)
    {
        _itemDetailsRepository = itemDetailsRepository;
    }

    public async Task<DeleteItemDetailsResult> Handle(DeleteItemDetailsCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _itemDetailsRepository.DeleteItemDetails(new ObjectId(request.ItemDetailsId));
        return new DeleteItemDetailsResult(deleted);
    }
}