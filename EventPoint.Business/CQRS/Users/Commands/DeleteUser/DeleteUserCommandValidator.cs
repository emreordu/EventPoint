using FluentValidation;

namespace EventPoint.Business.CQRS.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator:AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().GreaterThan(0);
        }
    }
}