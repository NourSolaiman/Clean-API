﻿using Application.Dtos.Users;
using Application.Queries.Users.GetByUsername;
using Domain.Models;
using Infrastructure.Repositories.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    // Defines the route as "api/[controller]" and sets this class as an API controller.
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {



        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator, IUserRepository userRepository, IConfiguration configuration)
        {

            _userRepository = userRepository;
            _configuration = configuration;
            _mediator = mediator;
        }


        // A static user instance for demonstration. In a real application, you'd use a database.
        public static User user = new User();

        private readonly IConfiguration _configuration;




        // ------------------------------------------------------------------------------------------------------
        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult<User> RegisterAsync(UserDto request)
        {

            // Hash the password before creating the user
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // Create an AddUserCommand with the provided details

            user.Username = request.Username;
            user.PasswordHash = passwordHash;


            _userRepository.AddUserAsync(user);
            // Returns the registered user. (Note: In real apps, don't return sensitive data.)
            return Ok(user);

        }
        // ------------------------------------------------------------------------------------------------------
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto request)
        {
            var user = await _mediator.Send(new GetByUsernameQuery(request.Username));

            // Validate input
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return Unauthorized("Anv�ndarnamnet eller l�senordet �r felaktigt.");
            }

            var token = CreateToken(user);
            return Ok(new { Token = token });

        }


        //Helper method to create a JWT token.
        private string CreateToken(User user)
        {
            // Just the username is used as a claim.
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            // Fetches the secret key from configuration. Secret key can't be null.
            var secretKey = _configuration["JwtSettings:SecretKey"];
            if (secretKey == null)
            {
                throw new InvalidOperationException("Secret key must not be null.");
            }

            // Creates security key using the fetched secret key.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // Creates signing credentials using the security key.
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // Creates the JWT token with the specified issuer, audience, claims, expiration date, and credentials.
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            // Serializes the token to a JWT string and returns it.
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
