using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Users
{
    internal class UserRepository : IUserRepository
    {
        private readonly caDBContext _caDBContext;

        public UserRepository(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }

        public async Task<User> AddUserAsync(User UserToCreate)
        {
            await _caDBContext.Users.AddAsync(UserToCreate);
            await _caDBContext.SaveChangesAsync();
            return await Task.FromResult(UserToCreate);

        }

        public async Task DeleteUserAsync(Guid id)
        {
            var DeleteUserId = await _caDBContext.Users.FindAsync(id);
            if (DeleteUserId != null)
            {
                _caDBContext.Users.Remove(DeleteUserId);
                await _caDBContext.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _caDBContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _caDBContext.Users.FindAsync(id);


        }

        public async Task UpdateUserAsync(User user)
        {
            _caDBContext.Users.Update(user);
            await _caDBContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username can not be null or empty.", nameof(username));
            }
            return await _caDBContext.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }


    }
}
