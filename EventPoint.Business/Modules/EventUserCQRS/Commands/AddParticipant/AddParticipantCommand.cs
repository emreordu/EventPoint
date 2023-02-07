using EventPoint.Business.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPoint.Business.Modules.EventUserCQRS.Commands.AddParticipant
{
    public class AddParticipantCommand:IRequest<bool>
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}