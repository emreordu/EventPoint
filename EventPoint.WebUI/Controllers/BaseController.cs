﻿using EventPoint.Business;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventPoint.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public APIResponse<T> ProduceResponse<T>(T obj)
        {
            var response = new APIResponse<T>() { Result = obj, IsSuccess = true, ErrorMessages = null, StatusCode = HttpStatusCode.OK };
            return response;
        }
    }
}