using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs.AddDog
{
    internal sealed class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public AddDogCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {
            Dog dogToCreate = new()
            {
                animalId = Guid.NewGuid(),
                Name = request.NewDog.Name
            };

            _mockDatabase.allDogs.Add(dogToCreate);

            return Task.FromResult(dogToCreate);
        }
    }
}
