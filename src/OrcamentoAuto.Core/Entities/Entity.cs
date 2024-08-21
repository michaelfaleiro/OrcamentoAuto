using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrcamentoAuto.Core.Entities;
public class Entity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
}
