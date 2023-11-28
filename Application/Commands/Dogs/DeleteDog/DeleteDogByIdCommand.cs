using Domain.Models;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommand : IRequest<Bird>
    {
        public DeleteDogByIdCommand(Guid deletedDogId)
        {
            DeletedDogId = deletedDogId;
        }

        public Guid DeletedDogId { get; }
    }
}
