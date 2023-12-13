using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        private readonly caDBContext _caDBContext;
        public DeleteDogByIdCommandHandler(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }

        public Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogToDelete = _caDBContext.Dogs.FirstOrDefault(dog => dog.Id == request.DeletedDogId)!;

            if (dogToDelete != null)
            {
                _caDBContext.Dogs.Remove(dogToDelete);
                return Task.FromResult(dogToDelete);

            }
            // Dog not found
            return Task.FromResult(dogToDelete)!;
        }
    }
}
