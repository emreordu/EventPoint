using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.Business.Helpers;
using EventPoint.Business.Helpers.Models;
using EventPoint.Business.Mediator;
using EventPoint.Core;
using EventPoint.DataAccess.Repository.Concrete;
using EventPoint.DataAccess.UnitOfWork;
using EventPoint.Entity.Entities;
using Microsoft.EntityFrameworkCore;
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
        public LoginCommandHandler(ITokenHelper tokenHelper, IMapper mapper, IUnitOfWork unitOfWork, RedisService redisService)
        {
            _tokenHelper = tokenHelper;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _redisService = redisService;
            _cacheRepository = _redisService.GetDb(0);
            userRepository = _unitOfWork.GetRepository<User>();
        }
        public async Task<TokenDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetFirstOrDefaultAsync(x => x.Email == request.Email,
                include: x => x.Include(y => y.UserRoles).ThenInclude(z => z.Role));
            if (user == null)
            {
                throw new InvalidDataException("User not found!");
            }
            if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new InvalidDataException("The password is wrong!");
            }
            var roles = user.UserRoles.Select(x => x.Role).ToList();
            var userDTO = _mapper.Map<UserDTO>(user);
            var roleModel = _mapper.Map<List<RoleViewModel>>(roles);
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