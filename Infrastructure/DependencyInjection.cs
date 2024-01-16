using Infrastructure.Database;
using Infrastructure.Database.MySQLDatabase;
using Infrastructure.Database.Repositories.UserAnimalRepo;
using Infrastructure.Repositories.Birds;
using Infrastructure.Repositories.Cats;
using Infrastructure.Repositories.Dogs;
using Infrastructure.Repositories.UserAnimal;
using Infrastructure.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddSingleton<MockDatabase>();
			services.AddScoped<IUserRepository, UserRepository>();
			//services.AddScoped<IAnimalRepository, AnimalRepository>();
			services.AddScoped<IDogRepository, DogRepository>();
			services.AddScoped<IBirdRepository, BirdRepository>();
			services.AddScoped<ICatRepository, CatRepository>();
			services.AddScoped<IUserAnimalRepository, UserAnimalRepository>();
			//services.AddSingleton<JwtTokenGenerator>();
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
