using Application.Queries.Birds.GetBirdsById;
using Domain.Models;
using Infrastructure.Database.MySQLDatabase;
using MediatR;

namespace Application.Queries.Birds.GetBirdById
{
    public class GetBirdByIdQueryHandler : IRequestHandler<GetBirdByIdQuery, Bird>
    {
        private readonly caDBContext _caDBContext;
        public GetBirdByIdQueryHandler(caDBContext caDBContext)
        {
            _caDBContext = caDBContext;
        }
        public Task<Bird> Handle(GetBirdByIdQuery request, CancellationToken cancellationToken)
        {
            Bird wantedBird = _caDBContext.Birds.Where(Bird => Bird.Id == request.Id).FirstOrDefault()!;
            if (wantedBird == null)
            {
                return Task.FromResult<Bird>(null!);
            }
            return Task.FromResult(wantedBird);
        }
    }
}