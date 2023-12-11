using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DatabaseHelpers
{
    public static class DatabaseSeedHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedDogs(modelBuilder);
            // Add more methods for other entities as needed
        }

        private static void SeedDogs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
                new Dog { animalId = Guid.NewGuid(), Name = "OldG" },
                new Dog { animalId = Guid.NewGuid(), Name = "NewG" },
                new Dog { animalId = Guid.NewGuid(), Name = "Björn" },
                new Dog { animalId = Guid.NewGuid(), Name = "Patrik" },
                new Dog { animalId = Guid.NewGuid(), Name = "Alfred" },
                new Dog { animalId = new Guid("12345678-1234-5678-1234-567812345671"), Name = "TestDogForUnitTests1" },
                new Dog { animalId = new Guid("12345678-1234-5678-1234-567812345672"), Name = "TestDogForUnitTests2" },
                new Dog { animalId = new Guid("12345678-1234-5678-1234-567812345673"), Name = "TestDogForUnitTests3" },
                new Dog { animalId = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestDogForUnitTests4" }
            );
        }
    }
}