using AutoMapper;
using EventPoint.Business.CQRS.Auth.Commands.CreateToken;
using EventPoint.Business.CQRS.EventManager.Commands.AddParticipant;
using EventPoint.Business.CQRS.Events.Commands.CreateEvent;
using EventPoint.Business.CQRS.Events.Commands.UpdateEvent;
using EventPoint.Business.CQRS.UserManager.Commands.AddFavorite;
using EventPoint.Business.Dto;
using EventPoint.Entity.Entities;

namespace EventPoint.Business.MappingProfile
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Event, EventDTO>();
            CreateMap<EventDTO, Event>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Event, EventCreateDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<EventUser, ParticipateEventDTO>().ReverseMap();

            //CQRS Mappings
            CreateMap<CreateEventCommand,Event>();
            CreateMap<UpdateEventCommand, Event>();
            CreateMap<AddParticipantCommand,EventUser>();
            CreateMap<AddFavoriteCommand,EventFavorite>();
            CreateMap<CreateTokenCommand,LoginDTO>();
        }
    }
}