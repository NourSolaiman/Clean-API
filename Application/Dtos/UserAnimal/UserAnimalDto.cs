using Application.Dtos.Animals;

namespace Application.Dtos.UserAnimal
{
	public class UserAnimalDto
	{
		public Guid UserId { get; set; }
		public string Username { get; set; }
		public Guid AnimalId { get; set; }
		public List<DogDto> Dogs { get; set; }
		public List<CatDto> Cats { get; set; }
		public List<BirdDto> Birds { get; set; }
	}
}
