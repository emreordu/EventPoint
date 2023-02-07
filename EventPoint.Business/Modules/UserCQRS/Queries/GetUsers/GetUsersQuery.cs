using EventPoint.Business.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPoint.Business.Modules.UserCQRS.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<UserDTO>>
    {
    }
}