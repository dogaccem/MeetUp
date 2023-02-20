using MediatR;
using MeetUp.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Application.DomainHandlers.Events.Commands.HardDeleteEventCommand
{
    public class HardDeleteEventCommandRequest : IRequest<Unit>, ISaveableCommand
    {
        public int EventId { get; set; }
    }
}
