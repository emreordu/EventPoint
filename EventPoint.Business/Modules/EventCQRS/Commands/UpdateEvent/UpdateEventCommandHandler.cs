using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;
using MediatR;

namespace EventPoint.Business.Modules.EventCQRS.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, EventDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<Event> eventRepository;
        public UpdateEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            eventRepository = _unitOfWork.GetRepository<Event>();
        }

        public async Task<EventDTO> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var isUpdated = eventRepository.GetFirstOrDefaultAsync(x => x.Id == request.Id).Result;
            if(isUpdated == null)
            {
                throw new Exception("No event found. Please make a valid request.");
            }
            var result = _mapper.Map<Event>(request);
            var model = await eventRepository.UpdateAsync(result);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<EventDTO>(model);
        }
    }
}