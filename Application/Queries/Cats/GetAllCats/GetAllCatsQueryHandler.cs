using Domain.Models;
using Infrastructure.Repositories.Cats;
using MediatR;

namespace Application.Queries.Cats.GetAllCats
{
	public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
	{
		private readonly ICatRepository _catRepository;
		public GetAllCatsQueryHandler(ICatRepository catRepository)
		{
			_catRepository = catRepository;
		}
		public async Task<List<Cat>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
		{
			List<Cat> allCatsFromDatabase = await _catRepository.GetAllCatsAsync();
			if (allCatsFromDatabase == null)
			{
				throw new InvalidOperationException("No Cats Was Found");
			}

			return allCatsFromDatabase;

		}
	}
}
