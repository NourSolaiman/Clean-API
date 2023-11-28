using Domain.Models;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommand : IRequest<Dog>
    {
        public DeleteDogByIdCommand(Guid deletedDogId)
        {
            DeletedDogId = deletedDogId;
        }

        public Guid DeletedDogId { get; }
    }
}
