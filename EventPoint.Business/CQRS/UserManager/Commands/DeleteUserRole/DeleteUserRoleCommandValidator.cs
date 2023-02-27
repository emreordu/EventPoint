using FluentValidation;

namespace EventPoint.Business.CQRS.UserManager.Commands.DeleteUserRole
{
    public class DeleteUserRoleCommandValidator : AbstractValidator<DeleteUserRoleCommand>
    {
        public DeleteUserRoleCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.RoleId).NotEmpty().GreaterThan(0);
        }
    }
}