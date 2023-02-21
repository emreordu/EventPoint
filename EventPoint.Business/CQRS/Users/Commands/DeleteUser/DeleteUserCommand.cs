using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : ICommand<bool>
    {
        public int Id { get; set; }
    }
}