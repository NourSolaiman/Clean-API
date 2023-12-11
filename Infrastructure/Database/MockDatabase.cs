using Domain.Models;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<User> Users
        {
            get { return allUsers; }
            set { allUsers = value; }
        }
        public List<Dog> allDogs
        {
            get { return allDogsFromMockDatabase; }
            set { allDogsFromMockDatabase = value; }
        }
        public List<Bird> allBirds
        {
            get { return allBirdsFromMockDatabase; }
            set { allBirdsFromMockDatabase = value; }
        }
        public List<Cat> allCats
        {
            get { return allCatsFromMockDataBase; }
            set { allCatsFromMockDataBase = value; }
        }

        private static List<User> allUsers = new()
        {
            new User { Id = Guid.NewGuid(), Username = "JohnCorleone", PasswordHash = "killYou" },
            new User { Id = Guid.NewGuid(), Username = "JaneCorleone", PasswordHash = "killYou2" },
            //new UserModel { Id = new Guid("550e8400-e29b-41d4-a716-446655440000"), UserName = "TestUser", UserPassword = "TestPassword"}
        };

        private static List<Dog> allDogsFromMockDatabase = new()
        {
            new Dog { animalId = Guid.NewGuid(), Name = "PeppeLeDog" },
            new Dog { animalId = Guid.NewGuid(), Name = "Fofi" },
            new Dog { animalId = Guid.NewGuid(), Name = "Simo" },
            new Dog { animalId = Guid.NewGuid(), Name = "Lano" },
            new Dog { animalId = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests" }
        };

        private static List<Bird> allBirdsFromMockDatabase = new()
        {
            new Bird { animalId = Guid.NewGuid(), Name = "Robin", CanFly = true },
            new Bird { animalId = Guid.NewGuid(), Name = "Sparrow", CanFly = true },
            new Bird { animalId = Guid.NewGuid(), Name = "Birdy", CanFly = true },
            new Bird { animalId = Guid.NewGuid(), Name = "Herdy", CanFly = false },
            new Bird { animalId = Guid.NewGuid(), Name = "Gerdy", CanFly = true },
            new Bird { animalId = new Guid("59d8fc74-3c94-4ed8-9a38-36b0b6b1074a"), Name = "TestBirdForUnitTests"}
        };

        private static List<Cat> allCatsFromMockDataBase = new()

        {
            new Cat { animalId = Guid.NewGuid(), Name = "Fluffy", LikesToPlay = true },
            new Cat { animalId = Guid.NewGuid(), Name = "Whiskers", LikesToPlay = false },
            new Cat { animalId = Guid.NewGuid(), Name = "Lickers", LikesToPlay = false },
            new Cat { animalId = Guid.NewGuid(), Name = "Sickers", LikesToPlay = true },
            new Cat { animalId = Guid.NewGuid(), Name = "Fluffers", LikesToPlay = false },
            new Cat { animalId = new Guid("7e910a6d-8621-4f4b-8a0c-5e199f42eaa5"), Name = "TestCatForUnitTests"}
        };
    }
}