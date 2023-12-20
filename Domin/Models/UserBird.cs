namespace Domain.Models
{
    public class UserBird
    {
        public Guid BirdId { get; set; }
        public Bird Bird { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
