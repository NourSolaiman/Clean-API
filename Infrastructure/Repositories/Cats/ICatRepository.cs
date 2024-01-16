using Domain.Models;

namespace Infrastructure.Repositories.Cats
{
    public interface ICatRepository
    {
        Task<Cat> GetByIdAsync(Guid catId);
        Task<Cat> AddAsync(Cat catToCreate);
        Task UpdateAsync(Cat cat);
        Task DeleteAsync(Guid catId);
        Task<List<Cat>> GetCatByBreedAndWeight(string Breed, int? Weight);
        Task<List<Cat>> GetAllCatsAsync();
    }
}
