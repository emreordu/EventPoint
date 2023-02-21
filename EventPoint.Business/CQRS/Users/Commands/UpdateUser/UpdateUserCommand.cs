using EventPoint.Business.Dto;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Users.Commands.UpdateUser
{
    public class UpdateUserCommand:ICommand<UserDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}