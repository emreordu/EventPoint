using AutoMapper;
using EventPoint.Business.Helpers;
using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.CQRS.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<User> userRepository;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper= mapper;
            userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return false;
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            if (await IsUniqueUser(request.Email))
            {
                User user = new()
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                await userRepository.CreateAsync(user);
                return true;
            }
            return false;
        }
        private async Task<bool> IsUniqueUser(string email)
        {
            var user = await userRepository.GetFirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return true;
            }
            return false;
        }
    }
}