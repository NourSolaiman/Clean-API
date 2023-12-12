using Application.Queries.Users.GetUserByUserName;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AuthController
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		public static User user = new User();
		private readonly IConfiguration _configuration;
		private readonly IMediator _mediator;

		public AuthController(IConfiguration configuration, IMediator mediator)
		{
			_configuration = configuration;
			_mediator = mediator;
		}

		/*
        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.Username = request.Username;
            user.PasswordHash = passwordHash;

            return Ok(user);
        }
        */
		[HttpPost("login")]
		public async Task<IActionResult> GetToken(string username, string password)
		{
			/*
            if (user.Username != request.Username)
            {
                return BadRequest("User not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Password is wrong!");
            }
            */
			var token = await _mediator.Send(new GetUserByUserNameQuery(username, password));

			return Ok(token);
		}
	}
}
