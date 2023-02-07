using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPoint.Business.Modules.EventFavoriteCQRS.Commands.AddFavorite
{
    public class AddFavoriteCommand:IRequest<bool>
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
