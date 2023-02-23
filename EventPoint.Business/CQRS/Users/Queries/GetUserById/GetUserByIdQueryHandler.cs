using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;
using EventPoint.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace EventPoint.Business.CQRS.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                throw new Exception("No user found!");
            }
            return _mapper.Map<UserDTO>(user);
        }
    }
}