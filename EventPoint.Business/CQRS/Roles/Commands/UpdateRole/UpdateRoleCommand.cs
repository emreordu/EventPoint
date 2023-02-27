using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommand:ICommand<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}