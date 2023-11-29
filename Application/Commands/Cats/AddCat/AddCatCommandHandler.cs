using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Cats.AddCats
{
    public class AddCatCommandHandler : IRequestHandler<AddCatCommand, Cat>
    {
        private readonly MockDatabase _mockDatabase;

        public AddCatCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Cat> Handle(AddCatCommand request, CancellationToken cancellationToken)
        {
            Cat CatToCreate = new()
            {
                animalId = Guid.NewGuid(),
                Name = request.NewCat.Name
            };

            _mockDatabase.allCats.Add(CatToCreate);

            return Task.FromResult(CatToCreate);
        }
    }
}
