namespace Domain.Models
{
	public class Animal
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public virtual ICollection<UserAnimal> UserAnimals { get; set; }
	}
}