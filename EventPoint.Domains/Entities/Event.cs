namespace EventPoint.Entity.Entities
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int ParticipantLimit { get; set; }
        public DateTime EventDate { get; set; }
        public IList<EventUser>? EventUsers { get; set; }
        public IList<EventFavorite>? EventFavorited { get; set; }
        public int OwnerId { get; set; }
        //public User Owner { get; set; }
    }
}