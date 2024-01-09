using Autofac;
using HermesStream.Notification.Repository;
using HermesStream.Notification.Repository.Mongo;
using HermesStream.Notification.Service.Interfaces;
using HermesStream.Notification.Service.Services;

namespace HermesStream.Notification.Infrastructure
{
    public class Ioc : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MongoDbNotificationRepository>().As<INotificationRepository>();
            builder.RegisterType<NotificationService>().As<INotificationService>();
        }
    }
}
