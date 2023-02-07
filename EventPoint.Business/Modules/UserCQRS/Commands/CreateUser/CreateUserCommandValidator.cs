using FluentValidation;

namespace EventPoint.Business.Modules.UserCQRS.Commands.CreateUser
{
    public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(x => x.LastName).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().NotNull().MinimumLength(8);
        }
    }
}