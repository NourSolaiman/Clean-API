using Application.Dtos.UserAnimal;
using MediatR;

namespace Application.Commands.UserAnimal.AddUserAnimal
{
	public class AddUserAnimalCommand : IRequest<UserAnimalDto>
	{

		public Guid UserId { get; set; }
		public Guid AnimalId { get; set; }


	}
}
