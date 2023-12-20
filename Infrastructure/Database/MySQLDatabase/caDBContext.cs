using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.MySQLDatabase
{
    public class caDBContext : DbContext
    {
        public caDBContext() { }
        public caDBContext(DbContextOptions<caDBContext> options) : base(options) { }

        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<Bird> Birds { get; set; }
        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public DbSet<UserDog> UserDog { get; set; }
        public DbSet<UserCat> UserCat { get; set; }
        public DbSet<UserBird> UserBird { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connectionString to Db
            string connectionString = "Server=localhost;Port=3306;Database=Clean-API;User=root;Password=Mns@19741111;";

            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 34)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Bird many-to-many User 
            modelBuilder.Entity<UserBird>()
                .HasKey(bu => new { bu.BirdId, bu.UserId });

            modelBuilder.Entity<UserBird>()
                .HasOne(bu => bu.Bird)
                .WithMany(b => b.UserBird)
                .HasForeignKey(bu => bu.BirdId);

            modelBuilder.Entity<UserBird>()
                .HasOne(bu => bu.User)
                .WithMany(u => u.UserBird)
                .HasForeignKey(bu => bu.UserId);

            //Cat many-to-many User 
            modelBuilder.Entity<UserCat>()
                .HasKey(uc => new { uc.CatId, uc.UserId });

            modelBuilder.Entity<UserCat>()
                .HasOne(uc => uc.Cat)
                .WithMany(uc => uc.UserCat)
                .HasForeignKey(uc => uc.CatId);

            modelBuilder.Entity<UserCat>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCat)
                .HasForeignKey(uc => uc.UserId);

            //Dog many-to-many User 
            modelBuilder.Entity<UserDog>()
                .HasKey(ud => new { ud.DogId, ud.UserId });

            modelBuilder.Entity<UserDog>()
                .HasOne(ud => ud.Dog)
                .WithMany(ud => ud.UserDog)
                .HasForeignKey(ud => ud.DogId);

            modelBuilder.Entity<UserDog>()
                .HasOne(ud => ud.User)
                .WithMany(u => u.UserDog)
                .HasForeignKey(ud => ud.UserId);

            AnimalSeed.SeedAnimals(modelBuilder);
        }
    }
}