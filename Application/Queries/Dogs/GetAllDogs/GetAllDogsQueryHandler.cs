using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.MySQLDatabase;
using MediatR;

namespace Application.Queries.Dogs.GetAllDogs
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly caDBContext _caDBContext;
        public GetAllDogsQueryHandler(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }
        public Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            List<Dog> allDogsFromMockDB = _caDBContext.Dogs.ToList();
            return Task.FromResult(allDogsFromMockDB);
        }
    }
}
