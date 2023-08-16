using AutoMapper;
using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventPoint.Business.CQRS.UserManager.Commands.JoinEvent
{
    public class JoinEventCommandHandler : ICommandHandler<JoinEventCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<EventUser> eventUserRepository;
        private readonly Repository<Event> eventRepository;
        private readonly Repository<User> userRepository;
        public JoinEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            eventUserRepository = _unitOfWork.GetRepository<EventUser>();
            eventRepository = _unitOfWork.GetRepository<Event>();
            userRepository = _unitOfWork.GetRepository<User>();
        }
        public async Task<bool> Handle(JoinEventCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetFirstOrDefaultAsync(x => x.Id == request.UserId);
            if (user == null)
            {
                throw new InvalidDataException("No user found.");
            }
            var eventData = await eventRepository.GetFirstOrDefaultAsync(x => x.Id == request.EventId);
            if (eventData == null)
            {
                throw new InvalidDataException("No event found.");
            }
            var model = _mapper.Map<EventUser>(request);
            if (model == null)
            {
                throw new InvalidDataException("Request is null");
            }
            var isExceed = await IsLimitExceed(model.EventId);
            if (isExceed == false)
            {
                await eventUserRepository.CreateAsync(model);
                return true;
            }
            throw new Exception("Exceeded participant limit.");
        }
        private async Task<bool> IsLimitExceed(int eventId)
        {
            var model = await eventRepository.GetFirstOrDefaultAsync(e => e.Id == eventId, include: x => x.Include(y => y.EventUsers));

            if (model == null)
            {
                return false;
            }
            var userList = model.EventUsers;
            if (userList.Count >= model.ParticipantLimit)
            {
                return true;
            }
            return false;
        }
    }
}