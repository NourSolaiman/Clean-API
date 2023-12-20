using Domain.Models;

namespace Infrastructure.Repositories.Birds
{
    public interface IBirdRepository
    {
        Task<List<Bird>> GetAllBirds(CancellationToken cancellationToken);
        Task<Bird> GetBirdById(Guid id, CancellationToken cancellationToken);
        Task<List<Bird>> GetAllBirdsByColor(string color, CancellationToken cancellationToken);
        Task<Bird> AddBird(Bird newbird, CancellationToken cancellationToken);
        Task<Bird> UpdateBird(Guid id, string newName, string color, bool canFly, string OwnerBirdUserName, CancellationToken cancellationToken);
        Task<Bird> DeleteBird(Guid id, CancellationToken cancellationToken);
    }
}
