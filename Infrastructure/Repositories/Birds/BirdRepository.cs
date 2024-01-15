using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Birds
{
    public class BirdRepository : IBirdRepository
    {
        private readonly caDBContext _caDBContext;
        public BirdRepository(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }

        public async Task<Bird> AddAsync(Bird birdToCreate)
        {
            _caDBContext.Birds.Add(birdToCreate);
            await _caDBContext.SaveChangesAsync();

            return birdToCreate;
        }

        public async Task DeleteAsync(Guid birdId)
        {
            var DeleteBirdId = await _caDBContext.Birds.FindAsync(birdId);
            if (DeleteBirdId != null)
            {
                _caDBContext.Birds.Remove(DeleteBirdId);
                await _caDBContext.SaveChangesAsync();

            }
        }

        public async Task<List<Bird>> GetAllBirdsAsync()
        {
            return await _caDBContext.Birds.ToListAsync();
        }

        public async Task<List<Bird>> GetBirdByColorAsync(string birdColor)
        {
            return await _caDBContext.Birds
                        .OfType<Bird>()
                        .Where(b => b.BirdColor == birdColor)
                        .OrderByDescending(b => b.BirdColor)
                        .ToListAsync();
        }

        public async Task<Bird> GetByIdAsync(Guid birdId)
        {
            return await _caDBContext.Birds.FindAsync(birdId);
        }

        public async Task UpdateAsync(Bird bird)
        {
            _caDBContext.Birds.Update(bird);
            await _caDBContext.SaveChangesAsync();
        }

    }
}
