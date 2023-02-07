using System.ComponentModel.DataAnnotations;

namespace EventPoint.Business.Dto
{
    public class EventCreateDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int ParticipantLimit { get; set; }
        public DateTime? EventDate { get; set; }
    }
}
