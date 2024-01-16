using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.MySQLDatabase
{
	public class caDBContext : DbContext
	{
		public caDBContext() { }
		public caDBContext(DbContextOptions<caDBContext> options) : base(options) { }

		public virtual DbSet<Dog> Dogs { get; set; }
		public virtual DbSet<Cat> Cats { get; set; }
		public virtual DbSet<Bird> Birds { get; set; }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<UserAnimal> UserAnimals { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//connectionString to Db
			string connectionString = "Server=localhost;Port=3306;Database=Clean-API;User=root;Password=Mns@19741111;";

			optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 34)));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//Configuring the many-to-many relationship
			modelBuilder.Entity<UserAnimal>()
				.HasKey(ua => new { ua.UserId, ua.AnimalId });

			modelBuilder.Entity<UserAnimal>()
				.HasOne(ua => ua.user)
				.WithMany(ua => ua.UserAnimals)
				.HasForeignKey(ua => ua.UserId);

			modelBuilder.Entity<UserAnimal>()
				.HasOne(ua => ua.Animal)
				.WithMany(a => a.UserAnimals)
				.HasForeignKey(ua => ua.AnimalId);
			AnimalSeed.SeedAnimals(modelBuilder);
		}
	}
}