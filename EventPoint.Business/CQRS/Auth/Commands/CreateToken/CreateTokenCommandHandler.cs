using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.Business.Helpers;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Auth.Commands.CreateToken
{
    public class CreateTokenCommandHandler : ICommandHandler<CreateTokenCommand, TokenDTO>
    {
        private readonly IAuthenticationHelper _authenticationHelper;
        private readonly IMapper _mapper;
        public CreateTokenCommandHandler(IAuthenticationHelper authenticationHelper, IMapper mapper)
        {
            _authenticationHelper = authenticationHelper;
            _mapper = mapper;
        }
        public async Task<TokenDTO> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            var loginDTO = _mapper.Map<LoginDTO>(request);
            var result = await _authenticationHelper.CreateTokenAsync(loginDTO,cancellationToken);
            return result;
        }
    }
}