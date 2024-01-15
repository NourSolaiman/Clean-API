using Domain.Models;
using Infrastructure.Repositories.Cats;
using MediatR;

namespace Application.Cats.GetAllCats.GetCatsById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly ICatRepository _catRepository;
        public GetCatByIdQueryHandler(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }
        public async Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            Cat wantedCat = await _catRepository.GetByIdAsync(request.Id);

            try
            {
                if (wantedCat == null)
                {
                    return null!;
                }
                return wantedCat;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}