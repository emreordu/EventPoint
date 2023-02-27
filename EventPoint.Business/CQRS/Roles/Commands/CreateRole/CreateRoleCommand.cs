using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : ICommand<bool>
    {
        public string Name { get; set; }
    }
}