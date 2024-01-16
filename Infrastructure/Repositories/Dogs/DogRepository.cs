using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Dogs
{
	public class DogRepository : IDogRepository
	{
		private readonly caDBContext _caDBContext;

		public DogRepository(caDBContext caDBContext)
		{
			_caDBContext = caDBContext;
		}

		public async Task<Dog> AddAsync(Dog dogToCreate)
		{
			_caDBContext.Dogs.Add(dogToCreate);
			_caDBContext.SaveChanges();
			return await Task.FromResult(dogToCreate);
		}
		public async Task DeleteAsync(Guid dogId)
		{
			var DeleteDogId = await _caDBContext.Dogs.FindAsync(dogId);

			if (DeleteDogId != null)
			{
				_caDBContext.Dogs.Remove(DeleteDogId);
				await _caDBContext.SaveChangesAsync();
			}

		}
		public async Task<List<Dog>> GetAllDogsAsync()
		{
			return await _caDBContext.Dogs.ToListAsync();
		}
		public async Task<Dog> GetByIdAsync(Guid dogId)
		{
			return await _caDBContext.Dogs.FindAsync(dogId);
		}

		public async Task<List<Dog>> GetDogByBreedAndWeight(string breed, int? weight)
		{
			var query = _caDBContext.Dogs.AsQueryable();

			if (!string.IsNullOrEmpty(breed))
			{
				query = query.Where(d => d.DogBreed == breed);
			}

			if (weight.HasValue)
			{
				query = query.Where(d => d.DogWeight == weight);
			}

			return await query.ToListAsync();
		}

		public async Task UpdateAsync(Dog dog)
		{
			_caDBContext.Dogs.Update(dog);
			await _caDBContext.SaveChangesAsync();
		}
	}
}