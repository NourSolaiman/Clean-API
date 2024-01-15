using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Bird : Animal
    {
        public bool CanFly { get; set; }
        public string BirdColor { get; set; }
    }
}
