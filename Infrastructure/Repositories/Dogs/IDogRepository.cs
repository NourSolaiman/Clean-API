using Domain.Models;

namespace Infrastructure.Repositories.Dogs
{
    public interface IDogRepository
    {
        Task<List<Dog>> GetAllDogs();
        Task<Dog> GetDogById(Guid id);
    }
}