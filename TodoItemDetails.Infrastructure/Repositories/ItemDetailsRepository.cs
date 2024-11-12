using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using TodoItemDetails.Application.Repositories;
using TodoItemDetails.Domain.Entities;
using TodoItemDetails.Infrastructure.Providers;

namespace TodoItemDetails.Infrastructure.Repositories;

public class ItemDetailsRepository : IItemDetailsRepository
{
    private readonly ItemDetailsContext _context;

    public ItemDetailsRepository(ItemDetailsContext context)
    {
        _context = context;
    }

    public async Task<ObjectId> AddItemDetails(ItemDetails itemDetails)
    {
        var currentDetails = await GetItemDetailByTodoId(itemDetails.TodoItemId);
        if (currentDetails != null)
        {
            return currentDetails.Id;
        }
        _context.ItemDetails.Add(itemDetails);
        await _context.SaveChangesAsync();
        return itemDetails.Id;
    }

    public async Task<ItemDetails?> GetItemDetailByTodoId(int Id)
    {
        return await _context.ItemDetails.FirstOrDefaultAsync(i => i.TodoItemId == Id);
    }

    public async Task<bool> UpdateItemDetails(ItemDetails itemDetails)
    {
        _context.ItemDetails.Update(itemDetails);
        try // TODO: Error Handling hier oder eher im Controller
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteItemDetails(ObjectId Id)
    {
        var itemDetails = new ItemDetails()
        {
            Id = Id,
            Description = "",
            TodoItemId = 0
        };
        _context.ItemDetails.Remove(itemDetails);
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }
}
