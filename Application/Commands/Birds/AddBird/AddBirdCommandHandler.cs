using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using MediatR;

namespace Application.Commands.Birds.AddBirds
{
    public class AddBirdCommandHandler : IRequestHandler<AddBirdCommand, Bird>
    {
        private readonly caDBContext _caDBContext;

        public AddBirdCommandHandler(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }
        public Task<Bird> Handle(AddBirdCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.NewBird.Name) || request.NewBird.Name == "string")
            {
                return Task.FromResult<Bird>(null!);
            }
            else
            {
                Bird BirdToCreate = new()
                {
                    Id = Guid.NewGuid(),
                    Name = request.NewBird.Name,
                    CanFly = request.NewBird.CanFly,
                };
                _caDBContext.Birds.Add(BirdToCreate);
                _caDBContext.SaveChangesAsync();
                return Task.FromResult(BirdToCreate);

            }
        }
    }
}
