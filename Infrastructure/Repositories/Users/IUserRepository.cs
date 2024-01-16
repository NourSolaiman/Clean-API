using Domain.Models;

namespace Infrastructure.Repositories.Users
{
	public interface IUserRepository
	{
		Task<User> GetUserByIdAsync(Guid id);
		Task<User> AddUserAsync(User user);
		Task<List<User>> GetAllUsersAsync();
		Task UpdateUserAsync(User user);
		Task DeleteUserAsync(Guid id);
		Task<User> GetUserByUsernameAsync(string username);
	}
}
