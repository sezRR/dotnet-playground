using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Stock.API.Models;

public class Stock
{
    [BsonId]
    [BsonElement(Order = 0)]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [BsonElement(Order = 1)]
    [BsonRepresentation(BsonType.Int32)]
    public int ProductId { get; set; }

    [BsonElement(Order = 2)]
    [BsonRepresentation(BsonType.Int32)]
    public int Count { get; set; }
}
