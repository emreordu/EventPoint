using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.UserManager.Commands.AddUserRole
{
    public class AddUserRoleCommand:ICommand<bool>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}