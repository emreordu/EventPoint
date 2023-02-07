using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.Entity.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EventPoint.Business.Modules.UserCQRS.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
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
            return _mapper.Map<UserDTO>(user);
        }
    }
}