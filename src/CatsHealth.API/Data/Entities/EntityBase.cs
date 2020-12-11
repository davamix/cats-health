using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CatsHealth.API.Data.Entities
{
    public abstract class EntityBase<T>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

    }
}