using FluentValidation;

namespace EventPoint.Business.CQRS.Roles.Commands.CreateRole
{
    public class CreateRoleCommandValidator:AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3);
        }
    }
}