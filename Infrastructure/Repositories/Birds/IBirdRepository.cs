using Domain.Models;

namespace Infrastructure.Repositories.Birds
{
	public interface IBirdRepository
	{
		Task<Bird> GetByIdAsync(Guid birdId);
		Task<Bird> AddAsync(Bird birdToCreate);
		Task UpdateAsync(Bird bird);
		Task DeleteAsync(Guid birdId);
		Task<List<Bird>> GetBirdByColorAsync(string BirdColor);
		Task<List<Bird>> GetAllBirdsAsync();
	}
}
