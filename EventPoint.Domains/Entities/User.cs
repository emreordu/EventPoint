using Microsoft.AspNetCore.Identity;

namespace EventPoint.Entity.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public IList<EventFavorite>? FavoritedEvents { get; set; }
        public IList<EventUser>? UserEvents { get; set; }
        public bool IsDeleted { get; set; }
    }
}