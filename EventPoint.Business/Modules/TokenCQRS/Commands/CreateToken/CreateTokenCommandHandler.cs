using AutoMapper;
using EventPoint.DataAccess.Helpers;
using EventPoint.DataAccess.IdentityServer;
using EventPoint.DataAccess.IdentityServer.Dto;
using MediatR;

namespace EventPoint.Business.Modules.TokenCQRS.Commands.CreateToken
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, ResponseDTO<TokenDTO>>
    {
        private readonly IAuthenticationHelper _authenticationHelper;
        private readonly IMapper _mapper;
        public CreateTokenCommandHandler(IAuthenticationHelper authenticationHelper, IMapper mapper)
        {
            _authenticationHelper = authenticationHelper;
            _mapper = mapper;
        }
        public async Task<ResponseDTO<TokenDTO>> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            var loginDTO = _mapper.Map<LoginDTO>(request);
            var result = await _authenticationHelper.CreateTokenAsync(loginDTO);
            return result;
        }
    }
}