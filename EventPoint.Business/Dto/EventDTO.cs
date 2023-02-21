namespace EventPoint.Business.Dto
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParticipantLimit { get; set; }
        public DateTime? EventDate { get; set; }
        public List<ParticipantDTO> Participants { get; set; } = new List<ParticipantDTO>();
    }
}