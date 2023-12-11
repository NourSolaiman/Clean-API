namespace Domain.Models
{
    public class Animal
    {
        public Guid animalId { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual string TypeOfAnimal { get; } = string.Empty;
        public virtual string animalCanDo { get; } = string.Empty;
    }
}