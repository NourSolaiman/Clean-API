using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Infrastructure.Repositories.UserAnimal;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Database.Repositories.UserAnimalRepo
{
    public class UserAnimalRepository : IUserAnimalRepository
    {
        private readonly caDBContext _caDBContext;

        public UserAnimalRepository(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }

        public async Task<IUserAnimalRepository> AddUserAnimalAsync(Guid userId, Guid animalId)
        {
            var user = await _caDBContext.Users.FindAsync(userId);
            var animal = await _caDBContext.Set<Animal>().FindAsync(animalId);

            if (user == null || animal == null)
            {
                throw new ArgumentException("User or AnimalModel not found");
            }

            var userAnimal = new UserAnimal { UserId = userId, AnimalId = animalId };
            _caDBContext.UserAnimals.Add(userAnimal);
            await _caDBContext.SaveChangesAsync();

            return (IUserAnimalRepository)userAnimal;
        }
        public async Task RemoveUserAnimalAsync(Guid userId, Guid animalId)
        {
            var userAnimal = await _caDBContext.UserAnimals
                                           .FirstOrDefaultAsync(ua => ua.UserId == userId && ua.AnimalId == animalId);
            if (userAnimal != null)
            {
                _caDBContext.UserAnimals.Remove(userAnimal);
                await _caDBContext.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<User>> GetAllUsersWithAnimalsAsync()
        {
            return await _caDBContext.Users
                                  .Include(u => u.UserAnimals)
                                  .ThenInclude(ua => ua.Animal)
                                  .ToListAsync();
        }
        public async Task UpdateUserAnimalAsync(Guid userId, Guid currentAnimalModelId, Guid newAnimalModelId)
        {
            // Ta bort den gamla relationen
            var existingRelation = await _caDBContext.UserAnimals
                .FirstOrDefaultAsync(ua => ua.UserId == userId && ua.AnimalId == currentAnimalModelId);

            if (existingRelation != null)
            {
                _caDBContext.UserAnimals.Remove(existingRelation);
            }

            // Lägg till den nya relationen
            var newRelation = new UserAnimal { UserId = userId, AnimalId = newAnimalModelId };
            _caDBContext.UserAnimals.Add(newRelation);

            await _caDBContext.SaveChangesAsync();
        }


    }
}
