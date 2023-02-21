using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.UserManager.Queries.GetFavoritesByUser
{
    public class GetFavoritesByUserQuery : IQuery<UserDTO>
    {
        public int UserId { get; set; }
    }
}