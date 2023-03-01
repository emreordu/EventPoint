using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventPoint.Business.CQRS.UserManager.Queries.GetFavoritesByUser
{
    public class GetFavoritesByUserQueryHandler : IQueryHandler<GetFavoritesByUserQuery, UserDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Repository<User> userRepository;
        public GetFavoritesByUserQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            userRepository = _unitOfWork.GetRepository<User>();
        }
        public async Task<UserDTO> Handle(GetFavoritesByUserQuery request, CancellationToken cancellationToken)
        {
            var model = await userRepository.GetFirstOrDefaultAsync(e => e.Id == request.UserId,
                include: x => x.Include(y => y.FavoritedEvents).ThenInclude(z => z.Event));
            if (model == null)
            {
                return new UserDTO();
            }
            var eventList = model.FavoritedEvents;
            var userDTO = _mapper.Map<UserDTO>(model);
            foreach (var userEvent in eventList)
            {
                if (userEvent != null)
                {
                    userDTO.FavoriteEvents.Add(new EventCreateDTO
                    {
                        Name = userEvent.Event.Name,
                        Description = userEvent.Event.Description,
                        ParticipantLimit = userEvent.Event.ParticipantLimit,
                        EventDate = userEvent.Event.EventDate
                    });
                }
            }
            return userDTO;
        }
    }
}