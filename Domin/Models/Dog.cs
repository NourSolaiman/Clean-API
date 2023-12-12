namespace Domain.Models
{
	public class Dog : Animal
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public override string TypeOfAnimal => "Dog";
		public override string animalCanDo => "This animal can bark";
		public bool LikesToPlay { get; set; }
	}
}
