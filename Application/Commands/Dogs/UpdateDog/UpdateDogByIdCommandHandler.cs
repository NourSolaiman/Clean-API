using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;
        public UpdateDogByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            // Check if _mockDatabase.allDogs is null before accessing it
            if (_mockDatabase.allDogs == null)
            {
                // You might want to throw an exception or handle it appropriately based on your application logic
                throw new InvalidOperationException("The list of dogs is not initialized.");
            }

            Dog dogToUpdate = _mockDatabase.allDogs.FirstOrDefault(dog => dog.Id == request.Id)!;

            if (dogToUpdate != null)
            {
                dogToUpdate.Name = request.UpdatedDog.Name;
            }

            return Task.FromResult(dogToUpdate)!;
        }
    }
}
