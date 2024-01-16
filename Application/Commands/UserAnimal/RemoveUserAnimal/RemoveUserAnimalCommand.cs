using MediatR;

namespace Application.Commands.UserAnimal.RemoveUserAnimal
{
	public class RemoveUserAnimalCommand : IRequest<bool>
	{
		public Guid UserId { get; set; }
		public Guid AnimalId { get; set; }

		public RemoveUserAnimalCommand(Guid userId, Guid animalId)
		{
			UserId = userId;
			AnimalId = animalId;
		}
	}
}
