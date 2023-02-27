using FluentValidation;

namespace EventPoint.Business.CQRS.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandValidator:AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}