using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace HermesStream.Notification.Repository.Mongo
{
    public class User
    {
        [BsonElement("clientId")]
        public required string ClientId { get; set; }
        [BsonElement("name")]
        public string? Name { get; set; }
        [BsonElement("telephone")]
        public string? Telephone { get; set; }
        [BsonElement("email")]
        public string? Email { get; set; }
    }
}
