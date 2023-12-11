using Domain.Models;
using Infrastructure.Database.MySQLDatabase;

namespace Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly caDBContext _caDBContext;

        public UserRepository(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }

        public async Task<User> RegisterUser(User userToRegister)
        {
            try
            {
                _caDBContext.Users.Add(userToRegister);
                _caDBContext.SaveChanges();
                return await Task.FromResult(userToRegister);
            }
            catch (ArgumentException e)
            {
                //// Log the error and return an error response
                //_logger.LogError(e, "Error registering user");
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                List<User> allUsersFromDatabase = _caDBContext.Users.ToList();
                return await Task.FromResult(allUsersFromDatabase);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}