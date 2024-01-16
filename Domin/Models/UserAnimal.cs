using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
	public class UserAnimal
	{
		[Key]
		public Guid UserId { get; set; }
		public User user { get; set; }
		public Guid AnimalId { get; set; }
		public Animal Animal { get; set; }
	}

}
