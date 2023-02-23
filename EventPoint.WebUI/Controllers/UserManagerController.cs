﻿using EventPoint.Business;
using EventPoint.Business.CQRS.EventManager.Commands.AddParticipant;
using EventPoint.Business.CQRS.UserManager.Commands.AddFavorite;
using EventPoint.Business.CQRS.UserManager.Commands.DeleteFavorite;
using EventPoint.Business.CQRS.UserManager.Queries.GetFavoritesByUser;
using EventPoint.Business.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    public class UserManagerController : BaseController
    {
        private readonly IMediator _mediator;
        public UserManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("participate-in-event")]
        public async Task<APIResponse<bool>> Participate(AddParticipantCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpPost("add-favorite")]
        public async Task<APIResponse<bool>> AddFavorite(AddFavoriteCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
        [HttpGet("get-user-favorites/{id}")]
        public async Task<APIResponse<UserDTO>> GetFavoritesOfUser(int id)
        {
            var response = await _mediator.Send(new GetFavoritesByUserQuery { UserId = id });
            return ProduceResponse(response);
        }
        [HttpDelete("delete-favorite")]
        public async Task<APIResponse<bool>> DeleteFavorite(DeleteFavoriteCommand request)
        {
            var response = await _mediator.Send(request);
            return ProduceResponse(response);
        }
    }
}