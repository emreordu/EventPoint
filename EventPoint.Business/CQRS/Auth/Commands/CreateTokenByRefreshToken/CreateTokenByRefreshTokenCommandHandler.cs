﻿using AutoMapper;
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

namespace EventPoint.Business.CQRS.Auth.Commands.CreateTokenByRefreshToken
{
    public class CreateTokenByRefreshTokenCommandHandler : ICommandHandler<CreateTokenByRefreshTokenCommand, TokenDTO>
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Repository<User> userRepository;
        private readonly Repository<Entity.Entities.Role> roleRepository;
        private readonly RedisService _redisService;
        private readonly IDatabase _cacheRepository;
        private string userKey = "userCache";
        private string tokenKey = "tokenCache";
        private readonly ApplicationDbContext _dbContext;
        public CreateTokenByRefreshTokenCommandHandler(ITokenHelper tokenHelper, IMapper mapper, IUnitOfWork unitOfWork,
            RedisService redisService, ApplicationDbContext dbContext)
        {
            _tokenHelper = tokenHelper;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _redisService = redisService;
            _cacheRepository = _redisService.GetDb(0);
            userRepository = _unitOfWork.GetRepository<User>();
            roleRepository = _unitOfWork.GetRepository<Entity.Entities.Role>();
            _dbContext = dbContext;
        }
        public async Task<TokenDTO> Handle(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            tokenKey += request.UserId.ToString();
            userKey += request.UserId.ToString();
            var token = await _cacheRepository.StringGetAsync(tokenKey);
            if (token.IsNullOrEmpty)
            {
                throw new Exception("Refresh Token not found.");
            }
            var user = await userRepository.GetFirstOrDefaultAsync(x => x.Id == request.UserId);
            if (user == null)
            {
                throw new Exception("UserId not found.");
            }
            var roles = from role in _dbContext.Roles
                        join userRole in _dbContext.UserRoles
                        on role.Id equals userRole.RoleId
                        where userRole.UserId == user.Id
                        select new Entity.Entities.Role { Id = role.Id, Name = role.Name };
            var userDTO = _mapper.Map<UserDTO>(user);
            var roleModel = _mapper.Map<List<RoleViewModel>>(roles.ToList());
            var accessToken = _tokenHelper.CreateToken(userDTO, roleModel);
            TimeSpan timeSpan = accessToken.RefreshTokenExpiration - DateTime.Now;
            await _cacheRepository.StringSetAsync(userKey, JsonSerializer.Serialize(user.Email), timeSpan);
            await _cacheRepository.StringSetAsync(tokenKey, JsonSerializer.Serialize(accessToken.RefreshToken), timeSpan);
            return accessToken;
        }
    }
}