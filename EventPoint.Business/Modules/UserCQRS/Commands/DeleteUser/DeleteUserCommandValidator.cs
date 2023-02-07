using FluentValidation;

namespace EventPoint.Business.Modules.UserCQRS.Commands.DeleteUser
{
    public class DeleteUserCommandValidator:AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().GreaterThan(0);
        }
    }
}