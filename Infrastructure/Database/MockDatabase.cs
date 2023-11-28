using Domain.Models;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Bird> allDogs
        {
            get { return allDogsFromMockDatabase; }
            set { allDogsFromMockDatabase = value; }
        }

        public List<Bird> allBirds
        {
            get { return allBirdsFromMockDatabase; }
            set { allBirdsFromMockDatabase = value; }
        }

        private static List<Bird> allBirdsFromMockDatabase = new()
{
    new Bird { animalId = Guid.NewGuid(), Name = "Robin", CanFly = true },
    new Bird { animalId = Guid.NewGuid(), Name = "Sparrow", CanFly = true },
    new Bird { animalId = Guid.NewGuid(), Name = "Birdy", CanFly = true },
    new Bird { animalId = Guid.NewGuid(), Name = "Herdy", CanFly = false },
    new Bird { animalId = Guid.NewGuid(), Name = "Gerdy", CanFly = true },
    new Bird { animalId = new Guid("59d8fc74-3c94-4ed8-9a38-36b0b6b1074a"), Name = "TestBirdForUnitTests"}
};


        private static List<Bird> allDogsFromMockDatabase = new()
        {
            new Bird
            {
                animalId = Guid.NewGuid(), Name = "PeppeLeDog"
            },
            new Bird
            {
                animalId = Guid.NewGuid(), Name = "Fofi"
            },
            new Bird
            {
                animalId = Guid.NewGuid(), Name = "Simo"
            },
            new Bird
            {
                animalId = Guid.NewGuid(), Name = "Lano"
            },
            new Bird { animalId = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"}
        };
    }
}
