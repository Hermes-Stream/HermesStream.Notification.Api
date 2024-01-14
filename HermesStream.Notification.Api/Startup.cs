using Serilog;
using Microsoft.OpenApi.Models;
using Autofac;
using HermesStream.Notification.Infrastructure;
using Autofac.Extensions.DependencyInjection;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
        services.AddEndpointsApiExplorer();
        services.AddMvc();
        services.AddOptions();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "HermesStream.Notification",
                Version = "v1",
            });
        });

        services.AddLogging(loggingBuilder =>
            loggingBuilder.AddSerilog(dispose: true));


        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(Configuration)
            .CreateLogger();

        services.AddAutofac();
        ConfigureAutoMapper(services);

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HermesStream.Notification"));
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthorization();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); 
        });
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterModule<Ioc>();
    }

    private void ConfigureAutoMapper(IServiceCollection services)
    {
        var config = new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });
        var mapper = config.CreateMapper();
        services.AddSingleton(mapper);
    }

}