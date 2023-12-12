using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Dogs.GetDogById
{
	public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
	{
		private readonly MockDatabase _mockDatabase;
		public GetDogByIdQueryHandler(MockDatabase mockDatabase)
		{
			_mockDatabase = mockDatabase;
		}
		public Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
		{
			Dog wantedDog = _mockDatabase.allDogs.Where(Dog => Dog.Id == request.Id).FirstOrDefault()!;
			return Task.FromResult(wantedDog);
		}
	}
}