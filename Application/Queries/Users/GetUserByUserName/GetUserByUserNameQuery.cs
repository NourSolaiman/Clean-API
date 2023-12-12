using MediatR;

namespace Application.Queries.Users.GetUserByUserName
{
	public class GetUserByUserNameQuery : IRequest<string>
	{
		public GetUserByUserNameQuery(string username, string password)
		{
			UserName = username;
			Password = password;
		}

		public string UserName { get; }
		public string Password { get; }
	}
}
