using AutoMapper;
using HermesStream.Notification.Acl.RabbitMq;
using HermesStream.Notification.Repository;
using HermesStream.Notification.Service.Interfaces;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.IO;

namespace HermesStream.Notification.Service.Services
{
    public class NotificationService : INotificationService
    {

        private readonly INotificationRepository _repo;
        private readonly ILogger<NotificationService> _logger;
        private readonly ISendToQueue _sendToQueue;
        private readonly IMapper _mapper;
        public NotificationService(IMapper mapper, INotificationRepository repo, ILogger<NotificationService> logger, ISendToQueue sendToQueue)
        {
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
            _sendToQueue = sendToQueue;
        }

        public IList<Entities.Notification> PopulateNotifications()
        {
            var result = new List<Entities.Notification>();
            var dto = _repo.CreateCollectionNotificationMockElement();
            result.AddRange(from r in dto
                            let itemMapped = _mapper.Map<Entities.Notification>(r)
                            select itemMapped);
            return result;
        }

        public Entities.Notification GetOneTypeInformation()
        {
            var dto = _repo.GetNotificationInformation();
            var mapped = _mapper.Map<Entities.Notification>(dto);
            var notification = dto.ToJson();

            _sendToQueue.SendMessage(notification);
            _logger.LogInformation("Sended to queue");

            return mapped;
        }
    }
}
