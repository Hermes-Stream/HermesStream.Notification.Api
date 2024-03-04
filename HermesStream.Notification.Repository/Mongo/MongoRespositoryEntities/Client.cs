using MongoDB.Bson.Serialization.Attributes;

namespace HermesStream.Notification.Repository.Mongo
{
    public class Client
    {
        [BsonElement("clientId")]
        public required string ClientId { get; set; }
        [BsonElement("name")]
        public required string Name { get; set; }
    }
}
