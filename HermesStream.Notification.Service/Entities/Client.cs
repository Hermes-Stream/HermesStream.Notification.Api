using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace HermesStream.Notification.Service.Entities
{
    public class Client
    {
        [Key]
        public required string ClientId { get; set; }
        public required string Name { get; set; }
    }
}
