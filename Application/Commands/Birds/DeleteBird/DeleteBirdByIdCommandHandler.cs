using Application.Commands.Birds.DeleteBird;
using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Birds.DeleteBird.DeleteBird
{
    public class DeleteBirdByIdCommandHandler : IRequestHandler<DeleteBirdByIdCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;
        public DeleteBirdByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Bird> Handle(DeleteBirdByIdCommand request, CancellationToken cancellationToken)
        {
            Bird birdToDelete = _mockDatabase.allBirds.FirstOrDefault(bird => bird.animalId == request.DeletedBirdId)!;

            if (birdToDelete != null)
            {
                _mockDatabase.allBirds.Remove(birdToDelete);
            }

            return Task.FromResult(birdToDelete)!;
        }
    }
}
