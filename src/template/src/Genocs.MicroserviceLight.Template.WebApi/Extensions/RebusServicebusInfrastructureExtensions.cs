namespace Genocs.MicroserviceLight.Template.WebApi.Extensions
{
    using Application.Services;
    using Infrastructure.RebusServiceBus;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class RebusServicebusInfrastructureExtensions
    {
        public static IServiceCollection AddRebusServiceBus(this IServiceCollection services, IConfiguration config)
        {
            // Add Rebus Service Bus 
            services.AddSingleton<IServiceBus, RebusServiceBus>();

            // Setup registration
            services.Configure<RebusBusOptions>(config.GetSection("RebusBusSettings"));

            return services;
        }
    }
}