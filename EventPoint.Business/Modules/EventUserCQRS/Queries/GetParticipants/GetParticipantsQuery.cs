using EventPoint.Business.Dto;
using MediatR;

namespace EventPoint.Business.Modules.EventUserCQRS.Queries.GetParticipants
{
    public class GetParticipantsQuery : IRequest<List<ParticipateEventDTO>>
    {
    }
}