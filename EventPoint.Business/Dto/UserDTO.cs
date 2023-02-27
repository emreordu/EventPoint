namespace EventPoint.Business.Dto
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<EventCreateDTO> FavoriteEvents { get; set; } = new List<EventCreateDTO>();
    }
}