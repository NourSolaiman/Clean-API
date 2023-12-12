using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using MediatR;

namespace Application.Commands.Cats.AddCats
{
    public class AddCatCommandHandler : IRequestHandler<AddCatCommand, Cat>
    {
        private readonly caDBContext _caDBContext;

        public AddCatCommandHandler(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }
        public Task<Cat> Handle(AddCatCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.NewCat.Name) || request.NewCat.Name == "string")
            {
                return Task.FromResult<Cat>(null!);
            }
            Cat CatToCreate = new()
            {
                Id = Guid.NewGuid(),
                Name = request.NewCat.Name,
                LikesToPlay = request.NewCat.LikesToPlay

            };

            _caDBContext.Cats.Add(CatToCreate);

            return Task.FromResult(CatToCreate);
        }
    }
}
