using Domain.Models;
using Infrastructure.Database;
using Infrastructure.Database.MySQLDatabase;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Birds.GetAllBirds
{
    public class GetAllBirdsQueryHandler : IRequestHandler<GetAllBirdsQuery, List<Bird>>
    {
        private readonly caDBContext _caDBContext;
        public GetAllBirdsQueryHandler(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }
        public Task<List<Bird>> Handle(GetAllBirdsQuery request, CancellationToken cancellationToken)
        {
            List<Bird> allBirdsFromDB = _caDBContext.Birds.ToList();
            return Task.FromResult(allBirdsFromDB);
        }
    }
}
