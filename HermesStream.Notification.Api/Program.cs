using Autofac.Extensions.DependencyInjection;

namespace HermesStream.Notification.Api
{
    internal partial class Program
    {
        public static void Main(string[] args)
        {
            //InfraModule.Configure();
            var host = Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webHostBuilder =>
                {
                    webHostBuilder
                  .UseContentRoot(Directory.GetCurrentDirectory())
                  .UseIISIntegration()
                  .UseStartup<Startup>();
                })
                .Build();

            host.Run();
        }
    }
}