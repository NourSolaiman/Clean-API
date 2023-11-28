using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Dogs.GetAllDogs
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Bird>>
    {
        private readonly MockDatabase _mockDatabase;
        public GetAllDogsQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<List<Bird>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            List<Bird> allDogsFromMockDB = _mockDatabase.allDogs;
            return Task.FromResult(allDogsFromMockDB);
        }
    }
}
