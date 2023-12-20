using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication.Authorization
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly caDBContext _caDBContext;

        public AuthRepository(IConfiguration configuration, caDBContext caDBContext)
        {
            _configuration = configuration;
            _caDBContext = caDBContext;
        }

        public User AuthenticateUser(string username, string password)
        {
            var user = _caDBContext.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == password);

            if (user == null)
            {
                throw new Exception("User not found");
            }
            if (!VerifyPasswordHash(password, user.PasswordHash))
            {
                throw new Exception("Invalid password");
            }
            return user;
        }

        public string GenerateJwtToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(s: _configuration["JwtSettings:SecretKey"]!); //Implement null handling

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        private string GetUserRoles(User user)
        {
            // Check if the username is "admin" (case-insensitive) and assign the "Admin" role
            if (user.Username.ToUpperInvariant() == "ADMIN")
            {
                return "Admin";
            }
            else
            {
                return "User";
            }
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            // Use BCrypt to verify the password hash
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }
}