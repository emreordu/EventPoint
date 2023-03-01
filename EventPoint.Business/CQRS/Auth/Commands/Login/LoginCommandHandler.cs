using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.Business.Helpers;
using EventPoint.Business.Helpers.Models;
using EventPoint.Business.Mediator;
using EventPoint.Core;
using EventPoint.DataAccess.Data;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;
using StackExchange.Redis;
using System.Text.Json;

namespace EventPoint.Business.CQRS.Auth.Commands.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, TokenDTO>
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<User> userRepository;
        private readonly RedisService _redisService;
        private readonly IDatabase _cacheRepository;
        private string userKey = "userCache";
        private string tokenKey = "tokenCache";
        private readonly ApplicationDbContext _dbContext;
        public LoginCommandHandler(ITokenHelper tokenHelper, IMapper mapper, IUnitOfWork unitOfWork, RedisService redisService, ApplicationDbContext dbContext)
        {
            _tokenHelper = tokenHelper;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _redisService = redisService;
            _cacheRepository = _redisService.GetDb(0);
            userRepository = _unitOfWork.GetRepository<User>();
            _dbContext = dbContext;
        }
        public async Task<TokenDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetFirstOrDefaultAsync(x => x.Email == request.Email);
            if (user == null)
            {
                throw new Exception("User not found!");
            }
            if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("The password is wrong!");
            }
            var roles = from role in _dbContext.Roles
                        join userRole in _dbContext.UserRoles
                        on role.Id equals userRole.RoleId
                        where userRole.UserId == user.Id
                        select new Entity.Entities.Role { Id = role.Id, Name = role.Name };

            var userDTO = _mapper.Map<UserDTO>(user);
            var roleModel = _mapper.Map<List<RoleViewModel>>(roles.ToList());
            var token = _tokenHelper.CreateToken(userDTO, roleModel);
            userKey += user.Id.ToString();
            tokenKey += user.Id.ToString();
            TimeSpan timeSpan = token.RefreshTokenExpiration - DateTime.Now;
            await _cacheRepository.StringSetAsync(userKey, JsonSerializer.Serialize(user.Email), timeSpan);
            await _cacheRepository.StringSetAsync(tokenKey, JsonSerializer.Serialize(token.RefreshToken), timeSpan);
            return token;
        }
    }
}