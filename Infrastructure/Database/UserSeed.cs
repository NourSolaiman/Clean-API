using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class UserSeed
    {
        public static void SeedUsers(ModelBuilder moduleBuilder)
        {
            moduleBuilder.Entity<User>().HasData(
            new User { Id = Guid.NewGuid(), Username = "Nour", PasswordHash = "Nour123" },
            new User { Id = Guid.NewGuid(), Username = "Stefan", PasswordHash = "Stefan123" },
            new User { Id = Guid.NewGuid(), Username = "Zena", PasswordHash = "Zena123" },
            new User { Id = Guid.NewGuid(), Username = "Nemo", PasswordHash = "Nemo123" }
            );
        }
    }
}
