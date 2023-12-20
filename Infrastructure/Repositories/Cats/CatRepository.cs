using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories.Cats
{
    public class CatRepository : ICatRepository
    {
        private readonly caDBContext _caDBContext;
        private readonly ILogger<CatRepository> _logger;

        public CatRepository(caDBContext caDBContext, ILogger<CatRepository> logger)
        {
            _caDBContext = caDBContext;
            _logger = logger;
        }

        public Task<List<Cat>> GetAllCats(CancellationToken cancellationToken)
        {
            try
            {
                List<Cat> allCatsFromDatabase = _caDBContext.Cats.ToList();

                foreach (var cat in allCatsFromDatabase)
                {
                    var useCat = _caDBContext.UserCat.FirstOrDefault(ub => ub.CatId == cat.Id);

                    if (useCat != null)
                    {
                        var user = _caDBContext.Users.FirstOrDefault(u => u.Id == useCat.UserId);
                        cat.OwnerCatUserName = user!.Username;
                    }
                }

                return Task.FromResult(allCatsFromDatabase);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all dogs from the database");
                throw new Exception("An error occurred while getting all dogs from the database", ex);
            }
        }
        public Task<Cat> GetCatById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Cat wantedCat = _caDBContext.Cats.FirstOrDefault(cat => cat.Id == id)!;
                var userCat = _caDBContext.UserCat.FirstOrDefault(ud => ud.CatId == wantedCat.Id);

                if (userCat != null)
                {
                    var user = _caDBContext.Users.FirstOrDefault(u => u.Id == userCat.UserId);
                    wantedCat.OwnerCatUserName = user!.Username;
                }
                return Task.FromResult(wantedCat);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all cats from the database");
                throw new Exception("An error occurred while getting all cats from the database", ex);
            }
        }
        public Task<List<Cat>> GetAllCatsByCriteria(string? breed, int? weight, CancellationToken cancellationToken)
        {
            try
            {
                List<Cat> filteredCats = _caDBContext.Cats
                                        .Where(c => (string.IsNullOrEmpty(breed) || c.Breed == breed) &&
                                        (weight == null || c.Weight >= weight))
                                        .ToList();

                foreach (var cat in filteredCats)
                {
                    var userCat = _caDBContext.UserCat.FirstOrDefault(uc => uc.CatId == cat.Id);

                    if (userCat == null)
                    {
                        var user = _caDBContext.Users.FirstOrDefault(u => u.Id == userCat.UserId);
                        cat.OwnerCatUserName = user!.Username;
                    }
                }

                return Task.FromResult(filteredCats);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all cats from the database");
                throw new Exception("An error occurred while getting all cats from the database", ex);
            }
        }
        public Task<Cat> AddCat(Cat newcat, CancellationToken cancellationToken)
        {
            try
            {
                var user = _caDBContext.Users
                    .FirstOrDefault(u => u.Username == newcat.OwnerCatUserName);

                if (user == null)
                {
                    // Handle the case where the user is not found
                    _logger.LogError($"Username {newcat.OwnerCatUserName} not found");
                    throw new Exception($"Username {newcat.OwnerCatUserName} not found");
                }

                newcat.UserCat = new List<UserCat>
                {
                    new UserCat { UserId = user.Id , CatId = newcat.Id},
                };

                _caDBContext.Cats.Add(newcat);
                _caDBContext.SaveChangesAsync(cancellationToken);

                return Task.FromResult(newcat);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while adding a cat to the database");
                throw new Exception("An error occurred while adding a cat to the database", ex);
            }
        }

        public Task<Cat> UpdateCat(Guid id, string newName, bool likesToPlay, string breed, int weight, string OwnerCatUserName, CancellationToken cancellationToken)
        {
            try
            {
                Cat catToUpdate = _caDBContext.Cats.FirstOrDefault(cat => cat.Id == id)!;

                catToUpdate.Name = newName;
                catToUpdate.LikesToPlay = likesToPlay;
                catToUpdate.Breed = breed;
                catToUpdate.Weight = weight;
                catToUpdate.OwnerCatUserName = OwnerCatUserName;

                var user = _caDBContext.Users
                    .FirstOrDefault(u => u.Username == catToUpdate.OwnerCatUserName);
                if (user != null)
                {
                    catToUpdate.UserCat = new List<UserCat>
                    {
                        new UserCat { UserId = user.Id , CatId = catToUpdate.Id},
                    };
                }

                _caDBContext.SaveChangesAsync();

                return Task.FromResult(catToUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting a cat with ID {id} from the database");
                throw new Exception($"An error occurred while deleting a cat with ID {id} from the database", ex);
            }
        }

        public Task<Cat> DeleteCat(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var catToDelete = _caDBContext.Cats.FirstOrDefault(cat => cat.Id == id);

                _caDBContext.Cats.Remove(catToDelete!);
                _caDBContext.SaveChangesAsync();
                return Task.FromResult(catToDelete!);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting a cat with ID {id} from the database");
                throw new Exception($"An error occurred while deleting a cat with ID {id} from the database", ex);
            }

        }
    }
}
