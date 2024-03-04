using RabbitMQ.Client;
using System.Text;

namespace HermesStream.Notification.Acl.RabbitMq
{
    public class SendToQueue : ISendToQueue
    {
        private readonly string _host = "localhost";
        private readonly int _port = 56195;
        private readonly string _username = "admin";
        private readonly string _password = "123456";
        private readonly string _queueName = "send-notification";

        public void SendMessage(string message)
        {
            // Use a reliable connection library like RabbitMQ.Client
            var connectionFactory = new ConnectionFactory()
            {
                HostName = _host,
                Port = _port,
                UserName = _username,
                Password = _password
            };

            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(_queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var messageBytes = Encoding.UTF8.GetBytes(message);
            var basicProperties = channel.CreateBasicProperties();
            basicProperties.Persistent = true; // Set message to be persistent

            channel.BasicPublish("", _queueName, basicProperties, messageBytes);
        }
    }
}
