using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_mongodb_crud.Model;

public class Driver
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")] public string Name { get; set; } = null;

    public int Number { get; set; }
    public string Team { get; set; } = null;
}