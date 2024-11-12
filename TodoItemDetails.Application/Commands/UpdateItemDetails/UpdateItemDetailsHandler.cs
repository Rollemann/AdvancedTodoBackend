using MediatR;
using MongoDB.Bson;
using TodoItemDetails.Application.Repositories;
using TodoItemDetails.Domain.Entities;

namespace TodoItemDetails.Application.Commands.UpdateItemDetails;

public class UpdateItemDetailsHandler : IRequestHandler<UpdateItemDetailsCommand, UpdateItemDetailsResult>
{
    private readonly IItemDetailsRepository _itemDetailsRepository;

    public UpdateItemDetailsHandler(IItemDetailsRepository itemDetailsRepository)
    {
        _itemDetailsRepository = itemDetailsRepository;
    }

    public async Task<UpdateItemDetailsResult> Handle(UpdateItemDetailsCommand request, CancellationToken cancellationToken)
    {
        var itemDetails = new ItemDetails()
        {
            Id = new ObjectId(request.ItemDetailsId),
            Description = request.Description,
            TodoItemId = request.TodoItemId
        };
        var updated = await _itemDetailsRepository.UpdateItemDetails(itemDetails);
        return new UpdateItemDetailsResult(updated);
    }
}
