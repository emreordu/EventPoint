using AutoMapper;
using EventPoint.Business.CQRS.Events.Commands.CreateEvent;
using EventPoint.Business.CQRS.Roles.Commands.CreateRole;
using EventPoint.Business.CQRS.UserManager.Commands.AddFavorite;
using EventPoint.Business.CQRS.UserManager.Commands.AddUserRole;
using EventPoint.Business.CQRS.UserManager.Commands.JoinEvent;
using EventPoint.Business.Dto;
using EventPoint.Business.Helpers.Models;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.MappingProfile
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Event, EventDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Event, EventCreateDTO>().ReverseMap();
            CreateMap<Role, RoleViewModel>().ReverseMap();

            //CQRS Mappings
            CreateMap<CreateEventCommand, Event>();
            CreateMap<JoinEventCommand, EventUser>();
            CreateMap<AddFavoriteCommand, EventFavorite>();
            CreateMap<CreateRoleCommand, Role>();
            CreateMap<AddUserRoleCommand, UserRole>();
        }
    }
}