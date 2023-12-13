using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using MediatR;

namespace Application.Queries.Dogs.GetDogById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
    {
        private readonly caDBContext _caDBContext;
        public GetDogByIdQueryHandler(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }
        public Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            Dog wantedDog = _caDBContext.Dogs.Where(Dog => Dog.Id == request.Id).FirstOrDefault()!;
            if (wantedDog == null)
            {
                return Task.FromResult<Dog>(null!);
            }
            return Task.FromResult(wantedDog);
        }
    }
}