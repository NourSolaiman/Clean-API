namespace Domain.Models
{
	public class Cat : Animal
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public override string TypeOfAnimal => "Cat";
		public override string animalCanDo => "This animal can Meao";

		public bool LikesToPlay { get; set; }
	}
}
