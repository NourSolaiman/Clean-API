using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Cats
{
    public class CatRepository : ICatRepository
    {
        private readonly caDBContext _caDBContext;

        public CatRepository(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }
        public async Task<Cat> AddAsync(Cat catToCreate)
        {
            _caDBContext.Cats.Add(catToCreate);
            _caDBContext.SaveChanges();
            return await Task.FromResult(catToCreate);

        }

        public async Task DeleteAsync(Guid catId)
        {
            var DeleteCatId = await _caDBContext.Cats.FindAsync(catId);

            if (DeleteCatId != null)
            {
                _caDBContext.Cats.Remove(DeleteCatId);
                await _caDBContext.SaveChangesAsync();

            }
        }

        public async Task<List<Cat>> GetAllCatsAsync()
        {
            return await _caDBContext.Cats.ToListAsync();

        }

        public async Task<Cat> GetByIdAsync(Guid catId)
        {
            return await _caDBContext.Cats.FindAsync(catId);
        }

        public async Task<List<Cat>> GetCatByBreedAndWeight(string breed, int? weight)
        {
            var query = _caDBContext.Cats.AsQueryable();

            if (!string.IsNullOrEmpty(breed))
            {
                query = query.Where(c => c.CatBreed == breed);
            }

            if (weight.HasValue)
            {
                query = query.Where(c => c.CatWeight == weight);
            }

            return await query.ToListAsync();
        }


        public async Task UpdateAsync(Cat cat)
        {
            _caDBContext.Cats.Update(cat);
            await _caDBContext.SaveChangesAsync();
        }


    }
}
