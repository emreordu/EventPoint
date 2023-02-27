using EventPoint.Business.Dto;
using EventPoint.Business.Helpers.Models;

namespace EventPoint.Business.Helpers
{
    public interface ITokenHelper
    {
        TokenDTO CreateToken(UserDTO appUser, List<RoleViewModel> roles);
    }
}