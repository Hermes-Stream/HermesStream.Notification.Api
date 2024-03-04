namespace HermesStream.Notification.Acl.RabbitMq
{
    public interface ISendToQueue
    {
        public void SendMessage(string message);
    }
}