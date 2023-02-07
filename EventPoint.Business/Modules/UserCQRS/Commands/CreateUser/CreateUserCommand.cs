﻿using MediatR;

namespace EventPoint.Business.Modules.UserCQRS.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}