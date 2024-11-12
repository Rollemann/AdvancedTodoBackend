namespace TodoItemDetails.API.Models;

public record UpdateItemDetailsInput(string ItemDetailsId, string Description, int TodoItemId);