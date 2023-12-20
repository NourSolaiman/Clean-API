using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.Birds
{
    public class BirdRepository : IBirdRepository
    {
        private readonly caDBContext _caDBContext;
        private readonly ILogger<BirdRepository> _logger;

        public BirdRepository(caDBContext caDBContext, ILogger<BirdRepository> logger)
        {
            _caDBContext = caDBContext;
            _logger = logger;
        }

        public Task<List<Bird>> GetAllBirds(CancellationToken cancellationToken)
        {
            try
            {
                List<Bird> allBirdsFromDatabase = _caDBContext.Birds.ToList();

                foreach (var bird in allBirdsFromDatabase)
                {
                    var userBird = _caDBContext.UserBird.FirstOrDefault(ub => ub.BirdId == bird.Id);

                    if (userBird != null)
                    {
                        var user = _caDBContext.Users.FirstOrDefault(u => u.Id == userBird.UserId);
                        bird.OwnerBirdUserName = user!.Username;
                    }
                }

                return Task.FromResult(allBirdsFromDatabase);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all dogs from the database");
                throw new Exception("An error occurred while getting all dogs from the database", ex);
            }
        }
        public Task<Bird> GetBirdById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Bird wantedBird = _caDBContext.Birds.FirstOrDefault(bird => bird.Id == id)!;
                var userBird = _caDBContext.UserBird.FirstOrDefault(ud => ud.BirdId == wantedBird.Id);

                if (userBird != null)
                {
                    var user = _caDBContext.Users.FirstOrDefault(u => u.Id == userBird.UserId);
                    wantedBird.OwnerBirdUserName = user!.Username;
                }
                return Task.FromResult(wantedBird);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all birds from the database");
                throw new Exception("An error occurred while getting all birds from the database", ex);
            }
        }
        public Task<List<Bird>> GetAllBirdsByColor(string color, CancellationToken cancellationToken)
        {
            try
            {
                List<Bird> filteredCirds = _caDBContext.Birds
                    .Where(b => b.Color == color).ToList();

                foreach (var bird in filteredCirds)
                {
                    var userBird = _caDBContext.UserBird.FirstOrDefault(ub => ub.BirdId == bird.Id);

                    if (userBird != null)
                    {
                        var user = _caDBContext.Users.FirstOrDefault(u => u.Id == userBird.UserId);
                        bird.OwnerBirdUserName = user!.Username;
                    }
                }
                return Task.FromResult(filteredCirds);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all birds from the database");
                throw new Exception("An error occurred while getting all birds from the database", ex);
            }
        }

        public Task<Bird> AddBird(Bird newbird, CancellationToken cancellationToken)
        {
            try
            {
                var user = _caDBContext.Users
                    .FirstOrDefault(u => u.Username == newbird.OwnerBirdUserName);

                if (user == null)
                {
                    // Handle the case where the user is not found
                    _logger.LogError($"Username {newbird.OwnerBirdUserName} not found");
                    throw new Exception($"Username {newbird.OwnerBirdUserName} not found");
                }

                newbird.UserBird = new List<UserBird>
                {
                    new UserBird { UserId = user.Id , BirdId = newbird.Id},
                };

                _caDBContext.Birds.Add(newbird);
                _caDBContext.SaveChangesAsync(cancellationToken);

                return Task.FromResult(newbird);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while adding a bird to the database");
                throw new Exception("An error occurred while adding a bird to the database", ex);
            }
        }

        public Task<Bird> UpdateBird(Guid id, string newName, string color, bool canFly, string OwnerBirdUserName, CancellationToken cancellationToken)
        {
            try
            {
                Bird birdToUpdate = _caDBContext.Birds.FirstOrDefault(bird => bird.Id == id)!;

                birdToUpdate.Name = newName;
                birdToUpdate.Color = color;
                birdToUpdate.CanFly = canFly;
                birdToUpdate.OwnerBirdUserName = OwnerBirdUserName;

                var user = _caDBContext.Users
                    .FirstOrDefault(u => u.Username == birdToUpdate.OwnerBirdUserName);
                if (user != null)
                {
                    birdToUpdate.UserBird = new List<UserBird>
                    {
                        new UserBird { UserId = user.Id , BirdId = birdToUpdate.Id},
                    };
                }

                _caDBContext.SaveChangesAsync();

                return Task.FromResult(birdToUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting a bird with ID {id} from the database");
                throw new Exception($"An error occurred while deleting a bird with ID {id} from the database", ex);
            }
        }

        public Task<Bird> DeleteBird(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var birdToDelete = _caDBContext.Birds.FirstOrDefault(bird => bird.Id == id);

                _caDBContext.Birds.Remove(birdToDelete!);
                _caDBContext.SaveChangesAsync();
                return Task.FromResult(birdToDelete!);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting a bird with ID {id} from the database");
                throw new Exception($"An error occurred while deleting a bird with ID {id} from the database", ex);
            }

        }

    }
}
