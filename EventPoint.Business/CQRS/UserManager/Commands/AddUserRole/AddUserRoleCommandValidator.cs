using FluentValidation;

namespace EventPoint.Business.CQRS.UserManager.Commands.AddUserRole
{
    public class AddUserRoleCommandValidator : AbstractValidator<AddUserRoleCommand>
    {
        public AddUserRoleCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.RoleId).NotEmpty().GreaterThan(0);
        }
    }
}