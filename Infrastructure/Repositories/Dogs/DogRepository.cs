using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.Dogs
{
    public class DogRepository : IDogRepository
    {
        private readonly caDBContext _caDBContext;
        private readonly ILogger<DogRepository> _logger;

        public DogRepository(caDBContext caDBContext, ILogger<DogRepository> logger)
        {
            _caDBContext = caDBContext;
            _logger = logger;
        }

        public Task<List<Dog>> GetAllDogs(CancellationToken cancellationToken)
        {
            try
            {
                List<Dog> allDogsFromDatabase = _caDBContext.Dogs.ToList();

                foreach (var dog in allDogsFromDatabase)
                {
                    var userDog = _caDBContext.UserDog.FirstOrDefault(ud => ud.DogId == dog.Id);

                    if (userDog != null)
                    {
                        var user = _caDBContext.Users.FirstOrDefault(u => u.Id == userDog.UserId);
                        dog.OwnerDogUserName = user!.Username;
                    }
                }

                return Task.FromResult(allDogsFromDatabase);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all dogs from the database");
                throw new Exception("An error occurred while getting all dogs from the database", ex);
            }
        }

        public Task<Dog> GetDogById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Dog wantedDog = _caDBContext.Dogs.FirstOrDefault(dog => dog.Id == id)!;
                var userDog = _caDBContext.UserDog.FirstOrDefault(ud => ud.DogId == wantedDog.Id);

                if (userDog != null)
                {
                    var user = _caDBContext.Users.FirstOrDefault(u => u.Id == userDog.UserId);
                    wantedDog.OwnerDogUserName = user!.Username;
                }
                return Task.FromResult(wantedDog);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all dogs from the database");
                throw new Exception("An error occurred while getting all dogs from the database", ex);
            }
        }

        public Task<List<Dog>> GetAllDogsByCriteria(string? breed, int? weight, CancellationToken cancellationToken)
        {
            try
            {
                List<Dog> filteredDogs = _caDBContext.Dogs
                                        .Where(d => (string.IsNullOrEmpty(breed) || d.Breed == breed) &&
                                        (weight == null || d.Weight >= weight))
                                        .ToList();

                foreach (var dog in filteredDogs)
                {
                    var userDog = _caDBContext.UserDog.FirstOrDefault(ud => ud.DogId == dog.Id);

                    if (userDog == null)
                    {
                        var user = _caDBContext.Users.FirstOrDefault(u => u.Id == userDog.UserId);
                        dog.OwnerDogUserName = user!.Username;
                    }
                }

                return Task.FromResult(filteredDogs);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all dogs from the database");
                throw new Exception("An error occurred while getting all dogs from the database", ex);
            }
        }

        public Task<Dog> AddDog(Dog newdog, CancellationToken cancellationToken)
        {
            try
            {
                var user = _caDBContext.Users
                    .FirstOrDefault(u => u.Username == newdog.OwnerDogUserName);

                if (user == null)
                {
                    // Handle the case where the user is not found
                    _logger.LogError($"Username {newdog.OwnerDogUserName} not found");
                    throw new Exception($"Username {newdog.OwnerDogUserName} not found");
                }

                newdog.UserDog = new List<UserDog>
                {
                    new UserDog { UserId = user.Id , DogId = newdog.Id},
                };

                _caDBContext.Dogs.Add(newdog);
                _caDBContext.SaveChangesAsync(cancellationToken);

                return Task.FromResult(newdog);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while adding a dog to the database");
                throw new Exception("An error occurred while adding a dog to the database", ex);
            }
        }

        public Task<Dog> UpdateDog(Guid id, string newName, bool likesToPlay, string breed, int weight, string OwnerDogUserName, CancellationToken cancellationToken)
        {
            try
            {
                Dog dogToUpdate = _caDBContext.Dogs.FirstOrDefault(dog => dog.Id == id)!;

                dogToUpdate.Name = newName;
                dogToUpdate.LikesToPlay = likesToPlay;
                dogToUpdate.Breed = breed;
                dogToUpdate.Weight = weight;
                dogToUpdate.OwnerDogUserName = OwnerDogUserName;

                var user = _caDBContext.Users
                    .FirstOrDefault(u => u.Username == dogToUpdate.OwnerDogUserName);
                if (user != null)
                {
                    dogToUpdate.UserDog = new List<UserDog>
                    {
                        new UserDog { UserId = user.Id , DogId = dogToUpdate.Id},
                    };
                }

                _caDBContext.SaveChangesAsync();

                return Task.FromResult(dogToUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting a dog with ID {id} from the database");
                throw new Exception($"An error occurred while deleting a dog with ID {id} from the database", ex);
            }
        }

        public Task<Dog> DeleteDog(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var dogToDelete = _caDBContext.Dogs.FirstOrDefault(d => d.Id == id);

                _caDBContext.Dogs.Remove(dogToDelete!);
                _caDBContext.SaveChangesAsync();
                return Task.FromResult(dogToDelete!);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting a dog with ID {id} from the database");
                throw new Exception($"An error occurred while deleting a dog with ID {id} from the database", ex);
            }

        }

    }
}