using EventPoint.Business.Helpers.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EventPoint.Business.Helpers
{
    public class GetCurrentUser : IGetCurrentUser
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public GetCurrentUser(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor= contextAccessor;
        }
        public string GetLoginUser()
        {
            return _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}