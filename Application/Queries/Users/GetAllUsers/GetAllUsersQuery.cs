using Domain.Models;
using MediatR;

namespace Application.Queries.Users.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
