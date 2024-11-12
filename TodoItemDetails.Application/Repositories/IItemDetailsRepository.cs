using MongoDB.Bson;
using TodoItemDetails.Domain.Entities;

namespace TodoItemDetails.Application.Repositories;

public interface IItemDetailsRepository
{
    Task<ItemDetails?> GetItemDetailByTodoId(int Id);

    Task<ObjectId> AddItemDetails(ItemDetails itemDetails);

    Task<bool> UpdateItemDetails(ItemDetails itemDetails);

    Task<bool> DeleteItemDetails(ObjectId Id);
}
