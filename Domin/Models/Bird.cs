using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Bird : Animal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public override string TypeOfAnimal => "Bird";
        public override string animalCanDo => "Fly";
        public bool CanFly { get; set; }
        public override string Color { get; set; } = string.Empty;
        [NotMapped]
        public string OwnerBirdUserName { get; set; } = string.Empty;

        [NotMapped, JsonIgnore]
        public override string Breed { get; set; } = string.Empty;

        [NotMapped, JsonIgnore]
        public override int Weight { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserBird> UserBird { get; set; } = new List<UserBird>();
    }
}
