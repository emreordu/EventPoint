using AutoMapper;
using EventPoint.Business.Dto;
using EventPoint.Business.Modules.EventCQRS.Commands.CreateEvent;
using EventPoint.Business.Modules.EventCQRS.Commands.UpdateEvent;
using EventPoint.Business.Modules.EventFavoriteCQRS.Commands.AddFavorite;
using EventPoint.Business.Modules.EventUserCQRS.Commands.AddParticipant;
using EventPoint.Business.Modules.EventUserCQRS.Commands.UpdateParticipant;
using EventPoint.Business.Modules.TokenCQRS.Commands.CreateToken;
using EventPoint.DataAccess.IdentityServer.Dto;
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
            CreateMap<UpdateParticipantCommand,EventUser>();
            CreateMap<AddFavoriteCommand,EventFavorite>();
            CreateMap<CreateTokenCommand,LoginDTO>();
        }
    }
}