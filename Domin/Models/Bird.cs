namespace Domain.Models
{
    public class Bird : Animal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public override string TypeOfAnimal => "Bird";
        public override string animalCanDo => "This animal can sing";
        public bool CanFly { get; set; }
    }
}
