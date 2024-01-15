using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class AnimalSeed
    {
        public static void SeedAnimals(ModelBuilder moduleBuilder)
        {
            moduleBuilder.Entity<Dog>().HasData(
            new Dog { Id = Guid.NewGuid(), Name = "PeppeLeDog", DogBreed = "Golden", DogWeight = 5 },
            new Dog { Id = Guid.NewGuid(), Name = "Fofi", DogBreed = "Poodle", DogWeight = 9 },
            new Dog { Id = Guid.NewGuid(), Name = "Simo", DogBreed = "Chihuahua", DogWeight = 4 },
            new Dog { Id = Guid.NewGuid(), Name = "Lano", DogBreed = "Beagle", DogWeight = 7 }

            );

            moduleBuilder.Entity<Bird>().HasData(
            new Bird { Id = Guid.NewGuid(), Name = "Robin", CanFly = true, BirdColor = "Green" },
            new Bird { Id = Guid.NewGuid(), Name = "Sparrow", CanFly = true, BirdColor = "Red" },
            new Bird { Id = Guid.NewGuid(), Name = "Birdy", CanFly = true, BirdColor = "Blue" },
            new Bird { Id = Guid.NewGuid(), Name = "Herdy", CanFly = true, BirdColor = "Gray" }

            );

            moduleBuilder.Entity<Cat>().HasData(
            new Cat { Id = Guid.NewGuid(), Name = "Nugget", LikesToPlay = true, CatBreed = "Fluffy", CatWeight = 2 },
            new Cat { Id = Guid.NewGuid(), Name = "Whiskers", LikesToPlay = true, CatBreed = "NakedCat", CatWeight = 6 },
            new Cat { Id = Guid.NewGuid(), Name = "Lickers", LikesToPlay = true, CatBreed = "Lion", CatWeight = 8 },
            new Cat { Id = Guid.NewGuid(), Name = "Sickers", LikesToPlay = true, CatBreed = "Shirazi", CatWeight = 7 }

            );
        }
    }
}
