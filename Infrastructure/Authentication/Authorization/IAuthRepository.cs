using Domain.Models;

namespace Infrastructure.Authentication.Authorization
{
    public interface IAuthRepository
    {
        User AuthenticateUser(string username, string password);
        string GenerateJwtToken(User user);
    }
}
