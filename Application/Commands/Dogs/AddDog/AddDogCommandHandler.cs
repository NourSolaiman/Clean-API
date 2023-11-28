using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs.AddDog
{
    public class AddDogCommandHandler : IRequestHandler<AddDogCommand, Bird>
    {
        private readonly MockDatabase _mockDatabase;

        public AddDogCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Bird> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {
            Bird dogToCreate = new()
            {
                animalId = Guid.NewGuid(),
                Name = request.NewDog.Name
            };

            _mockDatabase.allDogs.Add(dogToCreate);

            return Task.FromResult(dogToCreate);
        }
    }
}
