namespace Domain.Models
{
    public class UserCat
    {
        public Guid CatId { get; set; }
        public Cat Cat { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}