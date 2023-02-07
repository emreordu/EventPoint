using Azure;
using EventPoint.DataAccess.IdentityServer;
using EventPoint.DataAccess.IdentityServer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPoint.DataAccess.Helpers
{
    public interface IAuthenticationHelper
    {
        Task<ResponseDTO<TokenDTO>> CreateTokenAsync(LoginDTO loginDTO);
        Task<ResponseDTO<TokenDTO>> CreateTokenByRefreshToken(string refreshToken);
        Task<ResponseDTO<NoDataDTO>> RevokeRefreshToken(string refreshToken);
    }
}
