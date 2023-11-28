using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;
        public DeleteDogByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Bird> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            Bird dogToDelete = _mockDatabase.allDogs.FirstOrDefault(dog => dog.animalId == request.DeletedDogId)!;

            if (dogToDelete != null)
            {
                _mockDatabase.allDogs.Remove(dogToDelete);
            }

            return Task.FromResult(dogToDelete)!;
        }
    }
}
