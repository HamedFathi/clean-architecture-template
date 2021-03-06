namespace Genocs.MicroserviceLight.Template.WebApi.Extensions
{
    using Application.Repositories;
    using Application.Services;
    using Domain;
    using Infrastructure.MongoDbDataAccess;
    using Infrastructure.MongoDbDataAccess.Repositories;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class MongoDBInfrastructureExtensions
    {
        public static IServiceCollection AddMongoDBPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEntityFactory, EntityFactory>();
            services.AddScoped<IMongoContext, GenocsContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}