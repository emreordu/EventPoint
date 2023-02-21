using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Users.Queries.GetUsers
{
    public class GetUsersQuery : IQuery<List<UserDTO>>
    {
    }
}