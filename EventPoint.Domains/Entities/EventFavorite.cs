namespace EventPoint.Entity.Entities
{
    public class EventFavorite
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}