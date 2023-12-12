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
            new Dog { Id = Guid.NewGuid(), Name = "Lano" },
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests" }

            );

            moduleBuilder.Entity<Bird>().HasData(
            new Bird { Id = Guid.NewGuid(), Name = "Robin", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Sparrow", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Birdy", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Herdy", CanFly = false },
            new Bird { Id = Guid.NewGuid(), Name = "Gerdy", CanFly = true },
            new Bird { Id = new Guid("59d8fc74-3c94-4ed8-9a38-36b0b6b1074a"), Name = "TestBirdForUnitTests" }

            );

            moduleBuilder.Entity<Cat>().HasData(
            new Cat { Id = Guid.NewGuid(), Name = "Fluffy", LikesToPlay = true },
            new Cat { Id = Guid.NewGuid(), Name = "Whiskers", LikesToPlay = false },
            new Cat { Id = Guid.NewGuid(), Name = "Lickers", LikesToPlay = false },
            new Cat { Id = Guid.NewGuid(), Name = "Sickers", LikesToPlay = true },
            new Cat { Id = Guid.NewGuid(), Name = "Fluffers", LikesToPlay = false },
            new Cat { Id = new Guid("7e910a6d-8621-4f4b-8a0c-5e199f42eaa5"), Name = "TestCatForUnitTests" }

            );
        }
    }
}
