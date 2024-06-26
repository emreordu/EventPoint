﻿namespace EventPoint.Entity.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public IList<EventFavorite>? FavoritedEvents { get; set; }
        public IList<EventUser>? UserEvents { get; set; }
        public IList<UserRole>? UserRoles { get; set; }
        public IList<Event> OwnedEvents { get; set; }
    }
}