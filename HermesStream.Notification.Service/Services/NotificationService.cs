using AutoMapper;
using HermesStream.Notification.Repository;
using HermesStream.Notification.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace HermesStream.Notification.Service.Services
{
    public class NotificationService : INotificationService
    {

        private readonly INotificationRepository _repo;
        private readonly ILogger<NotificationService> _logger;
        private readonly IMapper _mapper;
        public NotificationService(IMapper mapper, INotificationRepository repo, ILogger<NotificationService> logger)
        {
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
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
            return mapped;
        }
    }
}
