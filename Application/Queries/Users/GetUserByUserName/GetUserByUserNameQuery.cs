using Domain.Models;
using MediatR;

namespace Application.Queries.Users.GetByUsername
{
    public class GetByUsernameQuery : IRequest<User>
    {
        public string Username { get; set; }
        public GetByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
