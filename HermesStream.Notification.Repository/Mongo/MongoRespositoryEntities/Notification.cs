using MongoDB.Bson.Serialization.Attributes;

namespace HermesStream.Notification.Repository.Mongo
{
    public class Notification
    {
        public Notification() { }

        [BsonElement("_id")]
        public string Id => NotificationId;

        [BsonElement("notificationId")]
        public required string NotificationId { get; set; }

        [BsonElement("clientId")]
        public required string ClientId { get; set; }

        [BsonElement("message")]
        public required string Message { get; set; }
        public NotificationType NotificationType { get; set; }
    }

    public enum NotificationType
    {
        WARNING,
        INFORMATION
    }
}
