using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;
using MediatR;

namespace EventPoint.Business.Modules.EventUserCQRS.Commands.UpdateParticipant
{
    public class UpdateParticipantCommandHandler : IRequestHandler<UpdateParticipantCommand, ParticipateEventDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<EventUser> eventUserRepository;
        public UpdateParticipantCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            eventUserRepository = _unitOfWork.GetRepository<EventUser>();
        }
        public async Task<ParticipateEventDTO> Handle(UpdateParticipantCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var user = await eventUserRepository.GetFirstOrDefaultAsync(x => x.UserId == request.UserId);
            //if (user == null)
            //{
            //    return new ParticipateEventDTO();
            //}
            //user.UserId= request.UserId;
            //var participant = _mapper.Map<EventUser>(request);
            //var model = await eventUserRepository.UpdateAsync(participant);
            //await _unitOfWork.CommitAsync();
            //return _mapper.Map<ParticipateEventDTO>(model);
        }
    }
}