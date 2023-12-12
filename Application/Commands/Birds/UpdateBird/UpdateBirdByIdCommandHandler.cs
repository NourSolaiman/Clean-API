using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Birds.UpdateBird
{
	public class UpdateBirdByIdCommandHandler : IRequestHandler<UpdateBirdByIdCommand, Bird>
	{
		private readonly MockDatabase _mockDatabase;
		public UpdateBirdByIdCommandHandler(MockDatabase mockDatabase)
		{
			_mockDatabase = mockDatabase;
		}
		public Task<Bird> Handle(UpdateBirdByIdCommand request, CancellationToken cancellationToken)
		{
			// Check if _mockDatabase.allBirds is null before accessing it
			if (_mockDatabase.allBirds == null)
			{
				// an exception or handle it appropriately based on my application logic
				throw new InvalidOperationException("The list of birds is not initialized.");
			}

			Bird birdToUpdate = _mockDatabase.allBirds.FirstOrDefault(bird => bird.Id == request.Id)!;

			if (birdToUpdate != null)
			{
				birdToUpdate.Name = request.UpdatedBird.Name;
				birdToUpdate.CanFly = request.UpdatedBird.CanFly;
			}

			return Task.FromResult(birdToUpdate)!;
		}
	}
}
