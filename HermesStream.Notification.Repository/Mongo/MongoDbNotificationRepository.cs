using MongoDB.Driver;

namespace HermesStream.Notification.Repository.Mongo
{
    public class MongoDbNotificationRepository : INotificationRepository
    {
        private readonly IMongoCollection<Notification> _notificationCollection;

        public MongoDbNotificationRepository()
        {
            var mongoClient = new MongoClient("mongodb+srv://juliasoares:390853331@hermesstream0.q9y1fri.mongodb.net/?retryWrites=true&w=majority");
            var database = mongoClient.GetDatabase("HermesStreamHML");
            _notificationCollection = database.GetCollection<Notification>("Notification");
        }

        public void AddNotification(Notification notification)
        {
            _notificationCollection.InsertOne(notification);
        }

        public IList<Notification> CreateCollectionNotificationMockElement()
        {

            var notifications = new List<Notification>
                {
                    new()
                    {
                        NotificationId = Guid.NewGuid().ToString(),
                        ClientId = Guid.NewGuid().ToString(),
                        Message = "Atenção! Esse é um exemplo de notificação INFORMATION",
                        NotificationType = NotificationType.INFORMATION
                    },
                    new()
                    {
                        NotificationId = Guid.NewGuid().ToString(),
                        ClientId = Guid.NewGuid().ToString(),
                        Message = "Atenção! Esse é um exemplo de notificação WARNING",
                        NotificationType = NotificationType.WARNING
                    }
            };

            foreach (var notification in notifications)
            {
                AddNotification(notification);
            }


            return notifications;
        }

        public Notification GetNotificationInformation()
        {
            return _notificationCollection.Find(n => n.NotificationType == NotificationType.INFORMATION).FirstOrDefaultAsync().Result;
        }

        public Notification GetNotificationByNotificationId(string notificationId)
        {
            var filter = Builders<Notification>.Filter.Eq(x => x.NotificationId, notificationId);
            return _notificationCollection.Find(filter).FirstOrDefault();
        }

    }
}
