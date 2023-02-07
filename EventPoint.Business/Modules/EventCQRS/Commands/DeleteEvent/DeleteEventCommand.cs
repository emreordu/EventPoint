using MediatR;

namespace EventPoint.Business.Modules.EventCQRS.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}