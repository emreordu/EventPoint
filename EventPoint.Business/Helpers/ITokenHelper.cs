using EventPoint.Business.Dto;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.Helpers
{
    public interface ITokenHelper
    {
        TokenDTO CreateToken(User appUser);
    }
}