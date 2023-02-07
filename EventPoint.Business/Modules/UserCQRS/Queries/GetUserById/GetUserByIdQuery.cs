using EventPoint.Business.Dto;
using MediatR;

namespace EventPoint.Business.Modules.UserCQRS.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public int Id { get; set; }
    }
}