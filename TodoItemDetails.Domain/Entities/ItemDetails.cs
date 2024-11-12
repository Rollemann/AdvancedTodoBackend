using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TodoItemDetails.Domain.Entities;

public class ItemDetails
{
    [BsonId]
    public ObjectId Id { get; set; }

    public required string Description { get; set; }

    public required int TodoItemId { get; set; }
}