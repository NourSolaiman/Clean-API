using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Cat : Animal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public override string TypeOfAnimal => "Cat";
        public override string animalCanDo => "Meows";
        public bool LikesToPlay { get; set; }
        public override string Breed { get; set; } = string.Empty;
        public override int Weight { get; set; }
        [NotMapped]
        public string OwnerCatUserName { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual ICollection<UserCat> UserCat { get; set; } = new List<UserCat>();

    }
}
