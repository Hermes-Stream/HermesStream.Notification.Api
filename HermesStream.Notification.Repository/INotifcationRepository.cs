namespace HermesStream.Notification.Repository
{
    public interface INotificationRepository
    {
        public IList<Mongo.Notification> CreateCollectionNotificationMockElement();
        public Mongo.Notification GetNotificationInformation();
    }
}
