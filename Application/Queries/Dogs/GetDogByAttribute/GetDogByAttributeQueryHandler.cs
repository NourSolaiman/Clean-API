using Domain.Models;
using Infrastructure.Repositories.Dogs;
using MediatR;

namespace Application.Queries.Dogs.GetDogByAttribute
{
	public class GetDogByAttributeQueryHandler : IRequestHandler<GetDogByAttributeQuery, IEnumerable<Dog>>
	{
		private readonly IDogRepository _dogRepository;

		public GetDogByAttributeQueryHandler(IDogRepository dogRepository)
		{
			_dogRepository = dogRepository;
		}

		public async Task<IEnumerable<Dog>> Handle(GetDogByAttributeQuery request, CancellationToken cancellationToken)
		{
			return await _dogRepository.GetDogByBreedAndWeight(request.Breed, request.Weight);
		}
	}
}
