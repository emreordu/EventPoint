using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.UserManager.Commands.DeleteUserRole
{
    public class DeleteUserRoleCommand:ICommand<bool>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}