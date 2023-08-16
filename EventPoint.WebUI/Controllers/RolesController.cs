using EventPoint.Business;
using EventPoint.Business.CQRS.Roles.Commands.CreateRole;
using EventPoint.Business.CQRS.Roles.Commands.DeleteRole;
using EventPoint.Business.CQRS.Roles.Commands.UpdateRole;
using EventPoint.Business.CQRS.Roles.Queries.GetRoles;
using EventPoint.Business.Helpers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPoint.WebUI.Controllers
{
    public class RolesController : BaseController
    {
        [HttpGet]
        public async Task<APIResponse<List<RoleViewModel>>> GetRoles(int pageSize = 50, int pageNumber = 1)
        {
            var result = await Mediator.Send(new GetRolesQuery { PageSize = pageSize, PageNumber = pageNumber });
            return ProduceResponse(result);
        }
        [HttpPost]
        [Authorize]
        public async Task<APIResponse<bool>> CreateRole(CreateRoleCommand request)
        {
            var result = await Mediator.Send(request);
            return ProduceResponse(result);
        }
        [HttpDelete]
        [Authorize]
        public async Task<APIResponse<bool>> DeleteRole(DeleteRoleCommand request)
        {
            var result = await Mediator.Send(request);
            return ProduceResponse(result);
        }
        [HttpPut]
        [Authorize]
        public async Task<APIResponse<bool>> UpdateRole(UpdateRoleCommand request)
        {
            var result = await Mediator.Send(request);
            return ProduceResponse(result);
        }
    }
}