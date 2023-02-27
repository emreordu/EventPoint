using EventPoint.Business.Helpers.Models;
using EventPoint.Business.Mediator;

namespace EventPoint.Business.CQRS.Roles.Queries.GetRoles
{
    public class GetRolesQuery:IQuery<List<RoleViewModel>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}