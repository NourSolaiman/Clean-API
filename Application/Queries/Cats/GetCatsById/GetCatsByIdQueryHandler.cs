using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Cats.GetAllCats.GetCatsById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly MockDatabase _mockDatabase;
        public GetCatByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            Cat wantedCat = _mockDatabase.allCats.Where(Cat => Cat.animalId == request.Id).FirstOrDefault()!;
            return Task.FromResult(wantedCat);
        }
    }
}