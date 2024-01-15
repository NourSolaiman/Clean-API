namespace Domain.Models
{
    public class Dog : Animal
    {
        public string Bark()
        {
            return "This animal barks";
        }

        public string DogBreed { get; set; }
        public int DogWeight { get; set; }
    }
}
