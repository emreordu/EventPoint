using AutoMapper;
using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.UserManager.Commands.AddFavorite
{
    public class AddFavoriteCommandHandler : ICommandHandler<AddFavoriteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<EventFavorite> eventFavoriteRepository;
        private readonly Repository<User> userRepository;
        private readonly Repository<Event> eventRepository;
        public AddFavoriteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            eventFavoriteRepository = _unitOfWork.GetRepository<EventFavorite>();
            userRepository = _unitOfWork.GetRepository<User>();
            eventRepository = _unitOfWork.GetRepository<Event>();
        }

        public async Task<bool> Handle(AddFavoriteCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetFirstOrDefaultAsync(x => x.Id == request.UserId);
            if (user == null)
            {
                throw new Exception("No user found.");
            }
            var eventData = await eventRepository.GetFirstOrDefaultAsync(x => x.Id == request.EventId);
            if (eventData == null)
            {
                throw new Exception("No event found.");
            }
            var model = _mapper.Map<EventFavorite>(request);
            if (model == null)
            {
                throw new Exception("Invalid Request");
            }
            await eventFavoriteRepository.CreateAsync(model);
            return true;
        }
    }
}