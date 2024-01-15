using Domain.Models;
using Infrastructure.Repositories.Dogs;
using MediatR;

namespace Application.Queries.Dogs.GetDogById
{
    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
    {
        private readonly IDogRepository _dogRepository;
        public GetDogByIdQueryHandler(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public async Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            Dog wantedDog = await _dogRepository.GetByIdAsync(request.Id);

            try
            {
                if (wantedDog == null)
                {
                    return null!;
                }
                return wantedDog;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}