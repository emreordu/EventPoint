using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommand : ICommand<bool>
    {
        public string Name { get; set; }
    }
}