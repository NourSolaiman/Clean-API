using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Dog : Animal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public override string TypeOfAnimal => "Dog";
        public override string animalCanDo => "Bark";
        public bool LikesToPlay { get; set; }
        public override string Breed { get; set; } = string.Empty;
        public override int Weight { get; set; }
        [NotMapped]
        public string OwnerDogUserName { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual ICollection<UserDog> UserDog { get; set; } = new List<UserDog>();
    }
}
