namespace HermesStream.Notification.Service.Interfaces
{
    public interface INotificationService
    {
        public IList<Entities.Notification> PopulateNotifications();
        public Entities.Notification GetOneTypeInformation();
    }
}