using EventPoint.Business;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventPoint.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public APIResponse<T> ProduceResponse<T>(T obj)
        {
            var response = new APIResponse<T>() { Result = obj, IsSuccess = true, ErrorMessages = null, StatusCode = HttpStatusCode.OK };
            return response;
        }
    }
}