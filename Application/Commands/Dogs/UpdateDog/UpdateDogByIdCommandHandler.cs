using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using MediatR;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly caDBContext _caDBContext;
        public UpdateDogByIdCommandHandler(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }
        public Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogToUpdate = _caDBContext.Dogs.FirstOrDefault(dog => dog.Id == request.Id)!;
            // Check if _caDBContext.Dogs is null before accessing it
            if (dogToUpdate != null)
            {
                if (string.IsNullOrWhiteSpace(request.UpdatedDog.Name) || request.UpdatedDog.Name == "string")
                {
                    return Task.FromResult<Dog>(null!);
                }
                else
                {
                    dogToUpdate.Name = request.UpdatedDog.Name;
                    _caDBContext.SaveChangesAsync();
                }
            }
            return Task.FromResult(dogToUpdate)!;
        }
    }
}
