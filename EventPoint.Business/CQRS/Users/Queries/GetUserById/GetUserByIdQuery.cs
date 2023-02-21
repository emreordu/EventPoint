using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IQuery<UserDTO>
    {
        public int Id { get; set; }
    }
}