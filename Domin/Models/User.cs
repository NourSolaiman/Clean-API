namespace Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public virtual ICollection<UserAnimal> UserAnimals { get; set; }
    }
}
