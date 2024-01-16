using Domain.Models;
using Infrastructure.Repositories.Birds;

namespace Application.Queries.Birds.GetBirdByAttribute
{
    public class GetBirdByAttributeQueryHandler
    {
        private readonly IBirdRepository _birdRepository;

        public GetBirdByAttributeQueryHandler(IBirdRepository birdRepository)
        {
            _birdRepository = birdRepository;
        }

        public async Task<List<Bird>> Handle(GetBirdByAttributeQuery request, CancellationToken cancellationToken)
        {
            return await _birdRepository.GetBirdByColorAsync(request.Color);
        }
    }
}
