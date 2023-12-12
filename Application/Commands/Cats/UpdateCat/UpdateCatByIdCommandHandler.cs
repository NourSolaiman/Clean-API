using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Cats.UpdateCat
{
	public class UpdateCatByIdCommandHandler : IRequestHandler<UpdateCatByIdCommand, Cat>
	{
		private readonly MockDatabase _mockDatabase;
		public UpdateCatByIdCommandHandler(MockDatabase mockDatabase)
		{
			_mockDatabase = mockDatabase;
		}
		public Task<Cat> Handle(UpdateCatByIdCommand request, CancellationToken cancellationToken)
		{
			// Check if _mockDatabase.allCats is null before accessing it
			if (_mockDatabase.allCats == null)
			{
				// an exception or handle it appropriately based on my application logic
				throw new InvalidOperationException("The list of cats is not initialized.");
			}

			Cat catToUpdate = _mockDatabase.allCats.FirstOrDefault(cat => cat.Id == request.Id)!;

			if (catToUpdate != null)
			{
				catToUpdate.Name = request.UpdatedCat.Name;
				catToUpdate.LikesToPlay = request.UpdatedCat.LikesToPlay;
			}

			return Task.FromResult(catToUpdate)!;
		}
	}
}
