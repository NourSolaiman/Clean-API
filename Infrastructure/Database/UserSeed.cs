using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class UserSeed
    {
        public static void SeedUsers(ModelBuilder moduleBuilder)
        {
            moduleBuilder.Entity<User>().HasData(
             new User { Id = Guid.NewGuid(), Username = "NourSolaiman", PasswordHash = "HejHej" },
            new User { Id = Guid.NewGuid(), Username = "SolaimanNour", PasswordHash = "HejHej2" }
            );
        }
    }
}
