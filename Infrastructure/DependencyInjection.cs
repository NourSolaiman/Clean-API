using Infrastructure.Authentication;
using Infrastructure.Database;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<MockDatabase>();
            services.AddSingleton<JWTTokenGenerator>();
            services.AddSingleton<caDBContext>();
            return services;
        }
    }
}
