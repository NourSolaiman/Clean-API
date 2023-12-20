using Domain.Models;

namespace Infrastructure.Repositories.Dogs
{
    public interface IDogRepository
    {
        Task<List<Dog>> GetAllDogs(CancellationToken cancellationToken);
        Task<Dog> GetDogById(Guid id, CancellationToken cancellationToken);
        Task<List<Dog>> GetAllDogsByCriteria(string breed, int? weight, CancellationToken cancellationToken);
        Task<Dog> AddDog(Dog newdog, CancellationToken cancellationToken);
        Task<Dog> UpdateDog(Guid id, string newName, bool likesToPlay, string breed, int weight, string OwnerDogUserName, CancellationToken cancellationToken);
        Task<Dog> DeleteDog(Guid id, CancellationToken cancellationToken);
    }
}