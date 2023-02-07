using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.DataAccess.Data;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EventPoint.Business.Modules.EventFavoriteCQRS.Queries.GetFavoritesByUser
{
    public class GetFavoritesByUserQueryHandler : IRequestHandler<GetFavoritesByUserQuery, UserDTO>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Repository<User> userRepository;
        public GetFavoritesByUserQueryHandler(IMapper mapper, ApplicationDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
            userRepository = _unitOfWork.GetRepository<User>();
        }
        public async Task<UserDTO> Handle(GetFavoritesByUserQuery request, CancellationToken cancellationToken)
        {
            var model = await _dbContext.Users.Include(n => n.FavoritedEvents).ThenInclude(e => e.Event)
                .FirstOrDefaultAsync(u => u.Id == request.UserId);

            //ERROR
            //var model3 = await userRepository.QuerySingleAsync(include: x => x.Include(n => n.FavoritedEvents)
            //    .ThenInclude(x => x.Event).Where(x => x.Id == request.UserId));

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