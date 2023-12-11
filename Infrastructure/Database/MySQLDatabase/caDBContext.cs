using Domain.Models;
using Infrastructure.Database.DatabaseHelpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.MySQLDatabase
{
    public class caDBContext : DbContext
    {
        public caDBContext() { }
        public caDBContext(DbContextOptions<caDBContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }
        //public virtual DbSet<Bird> Birds { get; set; }
        //public virtual DbSet<Cat> Cats { get; set; }



        // Do not really know why I have to keep this safe guard here but hell... Let it be until we find out why...
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("connectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Call the SeedData method from the external class
            DatabaseSeedHelper.SeedData(modelBuilder);
        }
    }
}