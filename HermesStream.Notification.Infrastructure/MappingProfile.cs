using AutoMapper;

namespace HermesStream.Notification.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Repository.Mongo.Notification, Service.Entities.Notification>()
                        .ForMember(nDb => nDb.ClientId, nServ => nServ.MapFrom(n => n.ClientId))
                        .ForMember(nDb => nDb.NotificationId, nServ => nServ.MapFrom(n => n.NotificationId))
                        .ForMember(nDb => nDb.Message, nServ => nServ.MapFrom(n => n.Message))
                        .ForMember(nDb => nDb.NotificationType, opt => opt.MapFrom(n => n.NotificationType));
        }
    }
}
