using Domain.Models;
using Infrastructure.Repositories.Cats;
using MediatR;

namespace Application.Queries.Cats.GetCatByAttribute
{
	public class GetCatByAttributeQueryHandler : IRequestHandler<GetCatByAttributeQuery, IEnumerable<Cat>>
	{
		private readonly ICatRepository _catRepository;

		public GetCatByAttributeQueryHandler(ICatRepository catRepository)
		{
			_catRepository = catRepository;

		}

		public async Task<IEnumerable<Cat>> Handle(GetCatByAttributeQuery request, CancellationToken cancellationToken)
		{
			return await _catRepository.GetCatByBreedAndWeight(request.Breed, request.Weight);
		}
	}
}
