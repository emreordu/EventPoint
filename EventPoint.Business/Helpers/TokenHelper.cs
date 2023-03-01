using EventPoint.Business.Dto;
using EventPoint.Business.Helpers.Models;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace EventPoint.Business.Helpers
{
    public class TokenHelper : ITokenHelper
    {
        private readonly CustomTokenOptions _tokenOption;
        public TokenHelper(IOptions<CustomTokenOptions> options)
        {
            _tokenOption = options.Value;
        }
        private string CreateRefreshToken()
        {
            var numberByte = new byte[32];
            using var rnd = RandomNumberGenerator.Create();

            rnd.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }
        private IEnumerable<Claim> SetClaims(UserDTO user, List<RoleViewModel> roles)
        {
            var claims = new List<Claim>();
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddRoles(roles.Select(r => r.Name).ToArray());
            return claims;
        }
        public TokenDTO CreateToken(UserDTO appUser, List<RoleViewModel> roles)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.RefreshTokenExpiration);
            var securityKey = SignService.GetSymmetricSecurityKey(_tokenOption.SecurityKey);
            var signingCredentials = SignService.CreateSigningCredentials(securityKey);

            var jwtSecurityToken = new JwtSecurityToken(
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(appUser, roles),
                signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurityToken);
            var tokenDTO = new TokenDTO
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpiration = accessTokenExpiration,
                RefreshTokenExpiration = refreshTokenExpiration
            };
            return tokenDTO;
        }
    }
}