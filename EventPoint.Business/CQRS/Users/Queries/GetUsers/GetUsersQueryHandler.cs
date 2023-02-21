using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;
using EventPoint.DataAccess.Data;
using EventPoint.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventPoint.Business.CQRS.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, List<UserDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public GetUsersQueryHandler(ApplicationDbContext dbContext, UserManager<User> userManager, IMapper mapper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _dbContext.Users.ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}