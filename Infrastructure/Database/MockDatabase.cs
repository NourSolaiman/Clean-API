using Domain.Models;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Dog> allDogs
        {
            get { return allDogsFromMockDatabase; }
            set { allDogsFromMockDatabase = value; }
        }

        private static List<Dog> allDogsFromMockDatabase = new()
        {
            new Dog
            {
                animalId = Guid.NewGuid(), Name = "PeppeLeDog"
            },
            new Dog
            {
                animalId = Guid.NewGuid(), Name = "Fofi"
            },
            new Dog
            {
                animalId = Guid.NewGuid(), Name = "Simo"
            },
            new Dog
            {
                animalId = Guid.NewGuid(), Name = "Lano"
            },
			new Dog { animalId = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"
            }
		};
    }
}
