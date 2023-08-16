using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.Business.Helpers;
using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, UserDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Repository<User> userRepository;
        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            userRepository = _unitOfWork.GetRepository<User>();
        }
        public async Task<UserDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetFirstOrDefaultAsync(x => x.Id == request.Id);
            if (user == null)
            {
                throw new InvalidDataException("No user found. Please make a valid request.");
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            user.FirstName = request.FirstName;
            user.Email = request.Email;
            user.LastName = request.LastName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await userRepository.UpdateAsync(user);
            return _mapper.Map<UserDTO>(user);
        }
    }
}