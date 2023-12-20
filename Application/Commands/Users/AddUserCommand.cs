using Application.Dtos.Users;
using Domain.Models;
using MediatR;

namespace Application.Commands.Users
{
    public class AddUserCommand : IRequest<User>
    {
        public AddUserCommand(UserDto newUser)
        {
            NewUser = newUser;
        }

        public UserDto NewUser { get; }
    }
}
