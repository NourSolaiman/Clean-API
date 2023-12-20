namespace Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public virtual ICollection<UserBird> UserBird { get; set; }
        public virtual ICollection<UserCat> UserCat { get; set; }
        public virtual ICollection<UserDog> UserDog { get; set; }
    }
}