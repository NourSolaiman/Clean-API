﻿using Domain.Models;
using MediatR;

namespace Application.Commands.Users.DeleteUser
{
    public class DeleteUserByIdCommand : IRequest<User>
    {
        public DeleteUserByIdCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

    }
}
