using EventPoint.Business;
using EventPoint.Business.CQRS.Roles.Commands.CreateRole;
using EventPoint.Business.CQRS.Roles.Commands.DeleteRole;
using EventPoint.Business.CQRS.Roles.Commands.UpdateRole;
using EventPoint.Business.CQRS.Roles.Queries.GetRoles;
using EventPoint.Business.Helpers.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    public class RolesController : BaseController
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public async Task<APIResponse<List<RoleViewModel>>> GetRoles(int pageSize = 50, int pageNumber = 1)
        {
            var result = await _mediator.Send(new GetRolesQuery { PageSize = pageSize, PageNumber = pageNumber });
            return ProduceResponse(result);
        }
        [HttpPost]
        public async Task<APIResponse<bool>> CreateRole(CreateRoleCommand request)
        {
            var result = await _mediator.Send(request);
            return ProduceResponse(result);
        }
        [HttpDelete]
        public async Task<APIResponse<bool>> DeleteRole(DeleteRoleCommand request)
        {
            var result = await _mediator.Send(request);
            return ProduceResponse(result);
        }
        [HttpPut]
        public async Task<APIResponse<bool>> UpdateRole(UpdateRoleCommand request)
        {
            var result = await _mediator.Send(request);
            return ProduceResponse(result);
        }
    }
}