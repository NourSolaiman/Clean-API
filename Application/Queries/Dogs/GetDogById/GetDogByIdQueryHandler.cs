using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Dogs.GetDogById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Bird>
    {
        private readonly MockDatabase _mockDatabase;
        public GetDogByIdQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Bird> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            Bird wantedDog = _mockDatabase.allDogs.Where(Dog => Dog.animalId == request.Id).FirstOrDefault()!;
            return Task.FromResult(wantedDog);
        }
    }
}