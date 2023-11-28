using Domain.Models;
using MediatR;

namespace Application.Commands.Birds.DeleteBird
{
    public class DeleteBirdByIdCommand : IRequest<Bird>
    {
        public DeleteBirdByIdCommand(Guid deletedBirdId)
        {
            DeletedBirdId = deletedBirdId;
        }

        public Guid DeletedBirdId { get; }
    }
}
