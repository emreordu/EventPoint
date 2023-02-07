using EventPoint.Business.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPoint.Business.Modules.EventFavoriteCQRS.Queries.GetFavoritesByUser
{
    public class GetFavoritesByUserQuery : IRequest<UserDTO>
    {
        public int UserId { get; set; }
    }
}