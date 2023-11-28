using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Birds.AddBirds
{
    public class AddBirdCommandHandler : IRequestHandler<AddBirdCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public AddBirdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Bird> Handle(AddBirdCommand request, CancellationToken cancellationToken)
        {
            Bird BirdToCreate = new()
            {
                animalId = Guid.NewGuid(),
                Name = request.NewBird.Name
            };

            _mockDatabase.allBirds.Add(BirdToCreate);

            return Task.FromResult(BirdToCreate);
        }
    }
}
