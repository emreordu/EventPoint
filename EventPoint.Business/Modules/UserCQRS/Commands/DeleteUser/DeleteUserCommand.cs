using MediatR;

namespace EventPoint.Business.Modules.UserCQRS.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}