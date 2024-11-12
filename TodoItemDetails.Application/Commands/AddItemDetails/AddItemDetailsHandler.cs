using MediatR;
using TodoItemDetails.Application.Repositories;
using TodoItemDetails.Domain.Entities;

namespace TodoItemDetails.Application.Commands.AddItemDetails;

public class AddItemDetailsHandler : IRequestHandler<AddItemDetailsCommand, AddItemDetailsResult>
{
    private readonly IItemDetailsRepository _itemDetailsRepository;

    public AddItemDetailsHandler(IItemDetailsRepository itemDetailsRepository)
    {
        _itemDetailsRepository = itemDetailsRepository;
    }

    public async Task<AddItemDetailsResult> Handle(AddItemDetailsCommand request, CancellationToken cancellationToken)
    {
        var itemDetails = new ItemDetails() { 
            Description = request.Description,
            TodoItemId = request.TodoItemId,
        };
        var todoItemId = await _itemDetailsRepository.AddItemDetails(itemDetails);
        return new AddItemDetailsResult(todoItemId.ToString());
    }
}
