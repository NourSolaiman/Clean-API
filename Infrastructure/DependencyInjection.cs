using Infrastructure.Authentication;
using Infrastructure.Database;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<MockDatabase>();
            services.AddSingleton<JWTTokenGenerator>();
            services.AddDbContext<caDBContext>(options =>
            {
                //connectionString to Db
                string connectionString = "Server=localhost;Port=3306;Database=Clean-API;User=root;Password=Mns@19741111;";

                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 34)));
            });
            return services;
        }
    }
}
