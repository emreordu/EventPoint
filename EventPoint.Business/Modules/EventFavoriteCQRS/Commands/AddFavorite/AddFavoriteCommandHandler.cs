using AutoMapper;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;
using MediatR;

namespace EventPoint.Business.Modules.EventFavoriteCQRS.Commands.AddFavorite
{
    public class AddFavoriteCommandHandler : IRequestHandler<AddFavoriteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<EventFavorite> eventFavoriteRepository;
        public AddFavoriteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            eventFavoriteRepository = _unitOfWork.GetRepository<EventFavorite>();
        }

        public async Task<bool> Handle(AddFavoriteCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<EventFavorite>(request);
            if (model == null)
            {
                return false;
            }
            await eventFavoriteRepository.CreateAsync(model);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}