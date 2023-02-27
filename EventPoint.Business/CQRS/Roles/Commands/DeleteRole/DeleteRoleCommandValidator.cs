using FluentValidation;

namespace EventPoint.Business.CQRS.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandValidator:AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3);
        }
    }
}