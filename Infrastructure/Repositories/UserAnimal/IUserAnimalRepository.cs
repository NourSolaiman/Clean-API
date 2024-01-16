using Domain.Models;

namespace Infrastructure.Repositories.UserAnimal
{
    public interface IUserAnimalRepository
    {
        Task<IEnumerable<User>> GetAllUsersWithAnimalsAsync();
        Task<IUserAnimalRepository> AddUserAnimalAsync(Guid userId, Guid animalId);
        Task RemoveUserAnimalAsync(Guid userId, Guid animalId);
        Task UpdateUserAnimalAsync(Guid userId, Guid currentAnimalModelId, Guid newAnimalId);
    }
}
