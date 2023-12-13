using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using MediatR;

namespace Application.Commands.Dogs.AddDog
{
    public class AddDogCommandHandler : IRequestHandler<AddDogCommand, Dog>
    {
        private readonly caDBContext _caDBContext;

        public AddDogCommandHandler(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }
        public Task<Dog> Handle(AddDogCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.NewDog.Name) || request.NewDog.Name == "string")
            {
                return Task.FromResult<Dog>(null!);
            }
            else
            {
                Dog dogToCreate = new()
                {
                    Id = Guid.NewGuid(),
                    Name = request.NewDog.Name
                };
                _caDBContext.Dogs.Add(dogToCreate);
                _caDBContext.SaveChangesAsync();
                return Task.FromResult(dogToCreate);
            }
        }
    }
}
