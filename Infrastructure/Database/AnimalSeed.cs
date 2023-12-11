using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class AnimalSeed
    {
        public static void SeedAnimals(ModelBuilder moduleBuilder)
        {
            moduleBuilder.Entity<Dog>().HasData(
            new Dog { Id = Guid.NewGuid(), Name = "PeppeLeDog" },
            new Dog { Id = Guid.NewGuid(), Name = "Fofi" },
            new Dog { Id = Guid.NewGuid(), Name = "Simo" },
            new Dog { Id = Guid.NewGuid(), Name = "Lano" }
            );

            moduleBuilder.Entity<Bird>().HasData(
            new Bird { Id = Guid.NewGuid(), Name = "Robin", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Sparrow", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Birdy", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Herdy", CanFly = false },
            new Bird { Id = Guid.NewGuid(), Name = "Gerdy", CanFly = true }
            );

            moduleBuilder.Entity<Cat>().HasData(
            new Cat { Id = Guid.NewGuid(), Name = "Fluffy", LikesToPlay = true },
            new Cat { Id = Guid.NewGuid(), Name = "Whiskers", LikesToPlay = false },
            new Cat { Id = Guid.NewGuid(), Name = "Lickers", LikesToPlay = false },
            new Cat { Id = Guid.NewGuid(), Name = "Sickers", LikesToPlay = true },
            new Cat { Id = Guid.NewGuid(), Name = "Fluffers", LikesToPlay = false }
            );
        }
    }
}
